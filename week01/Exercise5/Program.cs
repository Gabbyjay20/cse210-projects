using System;

class Program
{
    // Function to display welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function to prompt the user for their name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Function to prompt the user for their favorite number and return it
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favoriteNumber;

        // Ensuring valid integer input
        while (!int.TryParse(Console.ReadLine(), out favoriteNumber))
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
        }

        return favoriteNumber;
    }

    // Function to square the number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the result
    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }

    // Main function that coordinates the calls to other functions
    static void Main()
    {
        // Call the DisplayWelcome function
        DisplayWelcome();

        // Call PromptUserName and store the result
        string userName = PromptUserName();

        // Call PromptUserNumber and store the result
        int userNumber = PromptUserNumber();

        // Call SquareNumber to get the squared number
        int squaredNumber = SquareNumber(userNumber);

        // Call DisplayResult to show the final result
        DisplayResult(userName, squaredNumber);
    }
}
