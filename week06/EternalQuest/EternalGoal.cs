using System;
using System.Reflection;

namespace EternalQuestProgram
{
    // EternalGoal is never "complete". You earn points each time you record an event.
    public class EternalGoal : Goal
    {
        private int _timesRecorded;

        public EternalGoal(string name, string description, int pointValue)
            : base(name, description, pointValue)
        {
            _timesRecorded = 0;
        }

        public override bool IsComplete => false;

        public override int RecordEvent()
        {
            _timesRecorded++;
            return PointValue;
        }

        public override string Display()
        {
            return $"[∞] {Name} ({Description}) -- Recorded {_timesRecorded} time(s)";
        }

        public override string Serialize()
        {
            // Format: EternalGoal;Name;Description;PointValue;timesRecorded
            return $"EternalGoal;{Name};{Description};{PointValue};{_timesRecorded}";
        }

        public static EternalGoal Deserialize(string[] parts)
        {
            string name = parts[1];
            string description = parts[2];
            int pointValue = int.Parse(parts[3]);
            int timesRecorded = int.Parse(parts[4]);

            EternalGoal goal = new EternalGoal(name, description, pointValue);
            typeof(EternalGoal).GetField("_timesRecorded", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                               .SetValue(goal, timesRecorded);
            return goal;
        }
    }
}