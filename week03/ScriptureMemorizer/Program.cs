using System;

/// W03: Scripture Memorizer
/// Exceeding requirements:
/// - Words are only hidden if they are not already hidden.
/// - User can type "reset" to start over with the full scripture.
class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";
        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            try
            {
                Console.Clear();
            }
            catch (System.IO.IOException)
            {
                // Ignore if console clear fails (e.g., in some IDEs)
            }
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words, type 'reset' to start over, or 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
            else if (input.ToLower() == "reset")
            {
                scripture = new Scripture(reference, text);
                continue;
            }

            scripture.HideRandomWords(3); // hide 3 words per round

            if (scripture.IsCompletelyHidden())
            {
                try
                {
                    Console.Clear();
                }
                catch (System.IO.IOException)
                {
                    // Ignore if console clear fails
                }
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program ended.");
                break;
            }
        }
    }
}
