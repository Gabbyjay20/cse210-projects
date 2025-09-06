using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();  // List to store the numbers
        int number;

        // Ask the user to enter a series of numbers, stopping when 0 is entered
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());  // Read the input from the user

            if (number == 0)
            {
                break;  // Stop if the user enters 0
            }

            numbers.Add(number);  // Add the number to the list
        }

        // Compute the sum of the numbers
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        // Compute the average
        double average = (double)sum / numbers.Count;

        // Find the maximum number
        int max = int.MinValue;
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }

        // Display the results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}
