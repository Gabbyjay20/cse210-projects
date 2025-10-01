using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public string Name { get { return _name; } }
    public int Duration { get { return _duration; } }

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();
    }

    public void EndActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(5);
    }

    public virtual void RunActivity()
    {
        // Base implementation, but will be overridden
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinner[i % 4]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected void ShowBreathingAnimation(int seconds)
    {
        // Enhanced animation: text grows and shrinks
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("Breathe in...");
            for (int j = 0; j < 5; j++)
            {
                Console.Write(" .");
                Thread.Sleep(200);
            }
            Console.WriteLine();
            Console.Write("Breathe out...");
            for (int j = 5; j > 0; j--)
            {
                Console.Write(" .");
                Thread.Sleep(200);
            }
            Console.WriteLine();
        }
    }
}