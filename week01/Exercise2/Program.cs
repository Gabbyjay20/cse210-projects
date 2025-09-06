using System;

class Program
{
    static void Main()
    {
        // Prompt the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int gradePercentage;

        // Validate the input
        if (int.TryParse(input, out gradePercentage) && gradePercentage >= 0 && gradePercentage <= 100)
        {
            // Determine the letter grade
            string letter = gradePercentage >= 90 ? "A" :
                            gradePercentage >= 80 ? "B" :
                            gradePercentage >= 70 ? "C" :
                            gradePercentage >= 60 ? "D" : "F";

            // Determine the sign (+ or -)
            string sign = "";
            if (letter != "F" && letter != "A")
            {
                int lastDigit = gradePercentage % 10; // Get the last digit of the grade
                sign = lastDigit >= 7 ? "+" : lastDigit < 3 ? "-" : "";
            }

            // Handle the edge case for "A+" and "F"
            if (letter == "A" && sign == "+") sign = ""; // No "A+" grade
            if (letter == "F") sign = ""; // No "F+" or "F-" grade

            // Output the final grade
            Console.WriteLine($"Your grade is: {letter}{sign}");

            // Check if the student passed
            if (gradePercentage >= 70)
            {
                Console.WriteLine("You passed!");
            }
            else
            {
                Console.WriteLine("Better luck next time!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid grade percentage between 0 and 100.");
        }
    }
}

