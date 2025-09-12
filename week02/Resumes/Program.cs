using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating job instances
        Job job1 = new Job("Software Engineer", "Microsoft", 2019, 2022);
        Job job2 = new Job("Manager", "Apple", 2022, 2023);

        // Creating a resume and adding jobs to it
        Resume myResume = new Resume("Allison Rose");
        myResume.AddJob(job1);
        myResume.AddJob(job2);

        // Displaying the complete resume
        myResume.DisplayResume();
    }
}

// Definition for Resume class
internal class Resume
{
    private string _name;
    private List<Job> _jobs = new List<Job>();

    public Resume(string name)
    {
        _name = name;
    }

    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }

    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.DisplayJob();
        }
    }
}

