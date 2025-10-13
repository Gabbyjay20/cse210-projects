using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override string GetSaveString()
    {
        return $"EternalGoal:{_name}:{_description}:{_points}:{_isCompleted}";
    }
}