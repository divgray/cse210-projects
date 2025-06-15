using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        public List<Goal> Goals { get; private set; } = new List<Goal>();
        public int TotalScore { get; private set; } = 0;

        public void CreateGoal(Goal goal) => Goals.Add(goal);

        public void RecordEvent(int index)
        {
            if (index >= 0 && index < Goals.Count)
            {
                int earned = Goals[index].RecordEvent();
                Console.WriteLine($"You earned {earned} points!");
                TotalScore += earned;
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }
        }

        public void DisplayGoals()
        {
            if (Goals.Count == 0)
            {
                Console.WriteLine("No goals set.");
                return;
            }
            for (int i = 0; i < Goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Goals[i].GetStatus()}");
            }
        }

        public void SaveGoals(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(TotalScore);
                foreach (Goal goal in Goals)
                {
                    writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Description}|{goal.Points}|{goal.IsComplete}");
                }
            }
            Console.WriteLine("Goals saved!");
        }

        public void LoadGoals(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("No saved goals found.");
                return;
            }

            Goals.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                TotalScore = int.Parse(reader.ReadLine());
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string type = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);

                    Goal goal = type switch
                    {
                        "SimpleGoal" => new SimpleGoal(name, description, points),
                        "EternalGoal" => new EternalGoal(name, description, points),
                        "ChecklistGoal" => new ChecklistGoal(name, description, points, int.Parse(parts[5]), int.Parse(parts[6])),
                        _ => null
                    };

                    if (goal != null)
                    {
                        if (isComplete) goal.RecordEvent();
                        Goals.Add(goal);
                    }
                }
            }
            Console.WriteLine("Goals loaded!");
        }
    }
}
