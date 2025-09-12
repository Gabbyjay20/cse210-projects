public class Job
{
    private string _jobTitle;
    private string _company;
    private int _startYear;
    private int _endYear;

    // Constructor to initialize the job details
    public Job(string jobTitle, string company, int startYear, int endYear)
    {
        _jobTitle = jobTitle;
        _company = company;
        _startYear = startYear;
        _endYear = endYear;
    }

    // Method to display the job details in the correct format
    public void DisplayJobDetails()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}
