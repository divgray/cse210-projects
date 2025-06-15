using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public bool IsComplete { get; protected set; }

        public Goal(string name, string description, int points)
        {
            Name = name;
            Description = description;
            Points = points;
            IsComplete = false;
        }

        public abstract int RecordEvent();
        public abstract string GetStatus();
    }

    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points) : base(name, description, points) { }

        public override int RecordEvent()
        {
            if (!IsComplete)
            {
                IsComplete = true;
                return Points;
            }
            return 0;
        }

        public override string GetStatus() => IsComplete ? $"[X] {Name}: {Description}" : $"[ ] {Name}: {Description}";
    }

    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) : base(name, description, points) { }

        public override int RecordEvent() => Points;
        public override string GetStatus() => $"[ ] {Name}: {Description} (Earn {Points} points per occurrence)";
    }

    public class ChecklistGoal : Goal
    {
        public int TargetCount { get; set; }
        public int CurrentCount { get; set; }
        public int Bonus { get; set; }

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
            : base(name, description, points)
        {
            TargetCount = targetCount;
            Bonus = bonus;
            CurrentCount = 0;
        }

        public override int RecordEvent()
        {
            if (!IsComplete)
            {
                CurrentCount++;
                int earnedPoints = Points;
                if (CurrentCount >= TargetCount)
                {
                    earnedPoints += Bonus;
                    IsComplete = true;
                }
                return earnedPoints;
            }
            return 0;
        }

        public override string GetStatus() => IsComplete
            ? $"[X] {Name}: {Description} (Completed {TargetCount}/{TargetCount})"
            : $"[ ] {Name}: {Description} (Progress: {CurrentCount}/{TargetCount}, Bonus: {Bonus})";
    }
}
