using System;

class Program
{
    static void Main()
    {
        string playAgain = "yes"; // Variable to check if the user wants to play again

        // Loop to keep playing the game
        while (playAgain.ToLower() == "yes")
        {
            // Generate a random number between 1 and 100 for the magic number
            Random rand = new Random();
            int magicNumber = rand.Next(1, 101); // Random number between 1 and 100

            int guess;
            bool guessedCorrectly = false;
            int guessCount = 0;

            // Loop until the user guesses the correct number
            while (!guessedCorrectly)
            {
                // Ask the user for their guess
                Console.Write("What is your guess? ");
                string input = Console.ReadLine(); // Read the input as a string

                // Try to parse the input to an integer
                if (int.TryParse(input, out guess)) // If the input is a valid number
                {
                    guessCount++; // Increment guess count after each valid guess

                    // Determine if the guess is higher, lower, or correct
                    if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine("You guessed it!");
                        Console.WriteLine($"It took you {guessCount} guesses.");
                        guessedCorrectly = true; // Exit the loop when the correct guess is made
                    }
                }
                else
                {
                    // If input is not a valid number
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                }
            }

            // Ask if the user wants to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine(); // Get user response
        }

        Console.WriteLine("Thanks for playing!");
    }
}
