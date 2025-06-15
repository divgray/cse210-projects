using System;
using System.Reflection;

namespace EternalQuestProgram
{
    // A ChecklistGoal must be recorded several times before it is complete.
    public class ChecklistGoal : Goal
    {
        private int _currentCount;  // private counts using underscore
        public int TargetCount { get; set; }
        public int BonusValue { get; set; }

        public ChecklistGoal(string name, string description, int pointValue, int bonusValue, int targetCount)
            : base(name, description, pointValue)
        {
            BonusValue = bonusValue;
            TargetCount = targetCount;
            _currentCount = 0;
        }

        public override bool IsComplete => _currentCount >= TargetCount;

        public override int RecordEvent()
        {
            if (_currentCount < TargetCount)
            {
                _currentCount++;
                if (_currentCount == TargetCount)
                {
                    return PointValue + BonusValue;
                }
                return PointValue;
            }
            else
            {
                Console.WriteLine("This checklist goal is already complete.");
                return 0;
            }
        }

        public override string Display()
        {
            return $"[ {(IsComplete ? "X" : " ")} ] {Name} ({Description}) -- Completed: {_currentCount}/{TargetCount}";
        }

        public override string Serialize()
        {
            // Format: ChecklistGoal;Name;Description;PointValue;BonusValue;TargetCount;currentCount
            return $"ChecklistGoal;{Name};{Description};{PointValue};{BonusValue};{TargetCount};{_currentCount}";
        }

        public static ChecklistGoal Deserialize(string[] parts)
        {
            string name = parts[1];
            string description = parts[2];
            int pointValue = int.Parse(parts[3]);
            int bonusValue = int.Parse(parts[4]);
            int targetCount = int.Parse(parts[5]);
            int currentCount = int.Parse(parts[6]);

            ChecklistGoal goal = new ChecklistGoal(name, description, pointValue, bonusValue, targetCount);
            typeof(ChecklistGoal).GetField("_currentCount", BindingFlags.NonPublic | BindingFlags.Instance)
                                 .SetValue(goal, currentCount);
            return goal;
        }
    }
}
