using System;
using System.Collections.Generic;
using System.IO;

// To exceed requirements, I added a leveling system where the user's score determines their level and title.
// Levels: Novice (0-999), Apprentice (1000-2499), Journeyman (2500-4999), Expert (5000-9999), Master (10000+)

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            DisplayScore();
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void DisplayScore()
    {
        string level = GetLevelTitle(score);
        Console.WriteLine($"Score: {score} - Level: {level}");
    }

    static string GetLevelTitle(int score)
    {
        if (score < 1000) return "Novice";
        if (score < 2500) return "Apprentice";
        if (score < 5000) return "Journeyman";
        if (score < 10000) return "Expert";
        return "Master";
    }

    static void CreateGoal()
    {
        Console.WriteLine("Goal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose type: ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;
        if (type == "1")
        {
            goal = new SimpleGoal(name, desc, points);
        }
        else if (type == "2")
        {
            goal = new EternalGoal(name, desc, points);
        }
        else if (type == "3")
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            goal = new ChecklistGoal(name, desc, points, target, bonus);
        }

        if (goal != null)
        {
            goals.Add(goal);
            Console.WriteLine("Goal created!");
        }
        else
        {
            Console.WriteLine("Invalid type.");
        }
        Console.ReadKey();
    }

    static void ListGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
        }
        else
        {
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetDisplayString()}");
            }
        }
        Console.ReadKey();
    }

    static void RecordEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            Console.ReadKey();
            return;
        }

        ListGoals();
        Console.Write("Choose goal number to record: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= goals.Count)
        {
            int pointsEarned = goals[index - 1].RecordEvent();
            score += pointsEarned;
            Console.WriteLine($"Recorded! Earned {pointsEarned} points.");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
        Console.ReadKey();
    }

    static void SaveGoals()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                writer.WriteLine(score);
                foreach (var goal in goals)
                {
                    writer.WriteLine(goal.GetSaveString());
                }
            }
            Console.WriteLine("Goals saved!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving: {e.Message}");
        }
        Console.ReadKey();
    }

    static void LoadGoals()
    {
        try
        {
            if (!File.Exists("goals.txt"))
            {
                Console.WriteLine("No save file found.");
                Console.ReadKey();
                return;
            }

            goals.Clear();
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                string line = reader.ReadLine();
                score = int.Parse(line);

                while ((line = reader.ReadLine()) != null)
                {
                    Goal goal = CreateGoalFromString(line);
                    if (goal != null)
                    {
                        goals.Add(goal);
                    }
                }
            }
            Console.WriteLine("Goals loaded!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading: {e.Message}");
        }
        Console.ReadKey();
    }

    static Goal CreateGoalFromString(string line)
    {
        string[] parts = line.Split(':');
        string type = parts[0];
        string name = parts[1];
        string desc = parts[2];
        int points = int.Parse(parts[3]);

        if (type == "SimpleGoal")
        {
            bool completed = bool.Parse(parts[4]);
            var goal = new SimpleGoal(name, desc, points);
            if (completed) goal.RecordEvent(); // To set completed
            return goal;
        }
        else if (type == "EternalGoal")
        {
            return new EternalGoal(name, desc, points);
        }
        else if (type == "ChecklistGoal")
        {
            int target = int.Parse(parts[4]);
            int bonus = int.Parse(parts[5]);
            int current = int.Parse(parts[6]);
            bool completed = bool.Parse(parts[7]);
            var goal = new ChecklistGoal(name, desc, points, target, bonus);
            for (int i = 0; i < current; i++)
            {
                goal.RecordEvent(); // To increment count
            }
            return goal;
        }
        return null;
    }
}