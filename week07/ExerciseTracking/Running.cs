using System;

public class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int length, double distance) : base(date, length)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / (GetLength() / 60.0));
    }

    public override double GetPace()
    {
        return (GetLength() / _distance);
    }
}