using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        if (_currentCount >= _targetCount)
        {
            _isCompleted = true;
            return _points + _bonusPoints;
        }
        return _points;
    }

    public override string GetDisplayString()
    {
        string status = _isCompleted ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description}) -- Completed {_currentCount}/{_targetCount} times";
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal:{_name}:{_description}:{_points}:{_targetCount}:{_bonusPoints}:{_currentCount}:{_isCompleted}";
    }
}