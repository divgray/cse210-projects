using System;

namespace EternalQuestProgram
{
    public abstract class Goal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PointValue { get; set; }

        public Goal(string name, string description, int pointValue)
        {
            Name = name;
            Description = description;
            PointValue = pointValue;
        }

        // Returns true if the goal is considered complete.
        public abstract bool IsComplete { get; }

        // Records an event for the goal and returns the points awarded.
        public abstract int RecordEvent();

        // Returns a string representing the goal's current status.
        public abstract string Display();

        // Serializes the goal into a string for saving to a file.
        public abstract string Serialize();
    }
}
