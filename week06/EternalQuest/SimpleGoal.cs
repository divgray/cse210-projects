using System;
using System.Reflection;

namespace EternalQuestProgram
{
    // SimpleGoal can be marked complete once to gain its point value.
    public class SimpleGoal : Goal
    {
        private bool _completed;

        public SimpleGoal(string name, string description, int pointValue)
            : base(name, description, pointValue)
        {
            _completed = false;
        }

        public override bool IsComplete => _completed;

        public override int RecordEvent()
        {
            if (!_completed)
            {
                _completed = true;
                return PointValue;
            }
            else
            {
                Console.WriteLine("This goal has already been completed.");
                return 0;
            }
        }

        public override string Display()
        {
            return $"[ {(_completed ? "X" : " ")} ] {Name} ({Description})";
        }

        public override string Serialize()
        {
            // Format: SimpleGoal;Name;Description;PointValue;completed
            return $"SimpleGoal;{Name};{Description};{PointValue};{_completed}";
        }

        public static SimpleGoal Deserialize(string[] parts)
        {
            string name = parts[1];
            string description = parts[2];
            int pointValue = int.Parse(parts[3]);
            bool completed = bool.Parse(parts[4]);

            SimpleGoal goal = new SimpleGoal(name, description, pointValue);
            typeof(SimpleGoal).GetField("_completed", BindingFlags.NonPublic | BindingFlags.Instance)
                             .SetValue(goal, completed);
            return goal;
        }
    }
}
