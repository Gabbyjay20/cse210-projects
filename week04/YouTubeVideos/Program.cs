using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create first video
        Video video1 = new Video("How to Learn Programming", "CodeMaster", 720);
        video1.AddComment(new Comment("Alice", "Great tutorial! Very helpful for beginners."));
        video1.AddComment(new Comment("Bob", "I wish I had found this video earlier."));
        video1.AddComment(new Comment("Charlie", "Clear explanations and good examples."));
        video1.AddComment(new Comment("Diana", "Thanks for sharing this knowledge!"));
        videos.Add(video1);

        // Create second video
        Video video2 = new Video("Advanced C# Techniques", "TechGuru", 1200);
        video2.AddComment(new Comment("Eve", "Mind-blowing techniques! Learned so much."));
        video2.AddComment(new Comment("Frank", "This changed how I write C# code."));
        video2.AddComment(new Comment("Grace", "Please make more videos like this!"));
        videos.Add(video2);

        // Create third video
        Video video3 = new Video("Web Development Basics", "WebWizard", 900);
        video3.AddComment(new Comment("Henry", "Perfect introduction to web development."));
        video3.AddComment(new Comment("Ivy", "The examples were really practical."));
        video3.AddComment(new Comment("Jack", "Can't wait for the next part!"));
        video3.AddComment(new Comment("Kate", "Bookmarked for future reference."));
        videos.Add(video3);

        // Create fourth video
        Video video4 = new Video("Database Design Fundamentals", "DataExpert", 1500);
        video4.AddComment(new Comment("Liam", "Finally understand database normalization!"));
        video4.AddComment(new Comment("Mia", "This will help me in my current project."));
        video4.AddComment(new Comment("Noah", "Excellent explanation of complex concepts."));
        videos.Add(video4);

        // Display information for each video
        Console.WriteLine("YouTube Videos Information:");
        Console.WriteLine("==========================");
        Console.WriteLine();

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}