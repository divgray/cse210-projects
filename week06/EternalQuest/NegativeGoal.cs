using System;
using System.Reflection;

namespace EternalQuestProgram
{
    // A NegativeGoal represents a counterproductive or bad habit.
    // When its event is recorded, it deducts points from the users total.
    public class NegativeGoal : Goal
    {
        private bool _recorded;  // Using underscoreCamelCase for private field

        public NegativeGoal(string name, string description, int pointDeduction)
            : base(name, description, pointDeduction)
        {
            _recorded = false;
        }

        public override bool IsComplete => _recorded;

        public override int RecordEvent()
        {
            if (!_recorded)
            {
                _recorded = true;
                // Deduct the given point value (which represents the penalty) from the total score
                return -PointValue;
            }
            else
            {
                Console.WriteLine("This negative goal has already been recorded.");
                return 0;
            }
        }

        public override string Display()
        {
            return $"[ {(_recorded ? "X" : " ")} ] {Name} (Negative: {Description})";
        }

        public override string Serialize()
        {
            // Format: NegativeGoal;Name;Description;PointValue;recorded
            return $"NegativeGoal;{Name};{Description};{PointValue};{_recorded}";
        }

        public static NegativeGoal Deserialize(string[] parts)
        {
            string name = parts[1];
            string description = parts[2];
            int pointValue = int.Parse(parts[3]);
            bool recorded = bool.Parse(parts[4]);

            NegativeGoal negativeGoal = new NegativeGoal(name, description, pointValue);
            typeof(NegativeGoal)
                .GetField("_recorded", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(negativeGoal, recorded);
            return negativeGoal;
        }
    }
}
