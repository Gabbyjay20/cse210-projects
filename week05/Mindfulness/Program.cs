using System;
using System.IO;

// Exceeding requirements:
// - Added logging functionality to save each session to a file (mindfulness_log.txt) with activity name, duration, and timestamp.
// - Enhanced breathing animation with growing/shrinking text effect.
// - Ensured all prompts and questions are used before repeating in ReflectionActivity (though spec allows simple random, this adds value).

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("===================");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an activity (1-4): ");
            string choice = Console.ReadLine();

            Activity activity = null;
            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue.");
                    Console.ReadKey();
                    continue;
            }

            // Run the activity
            activity.RunActivity();

            // Log the session
            LogSession(activity.Name, activity.Duration);
        }
    }

    static void LogSession(string activityName, int duration)
    {
        string logEntry = $"{DateTime.Now}: Completed {activityName} for {duration} seconds.";
        File.AppendAllText("mindfulness_log.txt", logEntry + Environment.NewLine);
    }
}