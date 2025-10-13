using System;

public abstract class Activity
{
    private DateTime _date;
    private int _length; // in minutes

    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public int GetLength()
    {
        return _length;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public abstract double GetDistance(); // in miles
    public abstract double GetSpeed(); // mph
    public abstract double GetPace(); // min per mile

    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_length} min)- Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}