using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuestProgram
{
    class Program
    {
        static int totalScore = 0;
        static int userLevel = 1;  // Exceeding requirement
        static List<Goal> goals = new List<Goal>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine($"\n--- Eternal Quest Program ---\nLevel: {userLevel}  Score: {totalScore}");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Load Goals");
                Console.WriteLine("6. Quit");
                Console.Write("Select an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        SaveGoals();
                        break;
                    case "5":
                        LoadGoals();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose between 1 and 6.");
                        break;
                }
                UpdateLevel(); // Update users level after each operation based on totalScore.
            }

            Console.WriteLine("See you soon. Goodbye");
        }

        static void CreateGoal() // case 1
        {
            Console.WriteLine("\nSelect Goal Type to Create:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.WriteLine("4. Negative Goal");  // For exceeding requirement.
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            Console.Write("Enter the name of the goal: ");
            string name = Console.ReadLine();
            Console.Write("Enter a short description of the goal: ");
            string description = Console.ReadLine();

            int pointValue = ReadInteger("Enter the point value for this goal: ");

            switch (choice)
            {
                case "1":
                    goals.Add(new SimpleGoal(name, description, pointValue));
                    break;
                case "2":
                    goals.Add(new EternalGoal(name, description, pointValue));
                    break;
                case "3":
                    int targetCount = ReadInteger("Enter the number of completions for the bonus: ");
                    int bonusValue = ReadInteger("Enter the bonus point value on full completion: ");
                    goals.Add(new ChecklistGoal(name, description, pointValue, bonusValue, targetCount));
                    break;
                case "4":
                    // NegativeGoal which deducts points when recorded
                    goals.Add(new NegativeGoal(name, description, pointValue));
                    break;
                default:
                    Console.WriteLine("Invalid choice. Goal not created.");
                    return;
            }
            Console.WriteLine("Goal successfully created!");
        }


        // Lists all the goals along with their current status.
        static void ListGoals()
        {
            Console.WriteLine("\n--- List of Goals ---");
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals available.");
                return;
            }

            int index = 1;
            foreach (Goal goal in goals)
            {
                Console.WriteLine($"{index}. {goal.Display()}");
                index++;
            }
        }

        // Record events for a selected goal and updates the total score.
        static void RecordEvent()
        {
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals available to record an event.");
                return;
            }

            Console.WriteLine("\nSelect the goal number to record an event:");
            ListGoals();

            int selectedIndex = ReadInteger("Enter goal number: ");
            if (selectedIndex < 1 || selectedIndex > goals.Count)
            {
                Console.WriteLine("Invalid goal number.");
                return;
            }

            Goal selectedGoal = goals[selectedIndex - 1];
            int pointsEarned = selectedGoal.RecordEvent();
            totalScore += pointsEarned;

            // Message when score is below 0.
            if (totalScore < 0)
            {
                Console.WriteLine("Oh no. Your total score is below 0! Consider focusing on positive goals to rebuild your progress.");
            }

            Console.WriteLine($"Event recorded! You earned {pointsEarned} points. Your total score is now {totalScore}.");
        }


        // Saves the score and goals to a file.
        static void SaveGoals()
        {
            Console.Write("Enter filename to save goals (e.g., goals.txt): ");
            string filename = Console.ReadLine();

            // Saved in the same directory.
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.Combine(folder, filename);

            try
            {
                using (StreamWriter writer = new StreamWriter(fullPath))
                {
                    // Write total score on first line.
                    writer.WriteLine(totalScore);
                    // Save each goal using its Serialize method.
                    foreach (Goal goal in goals)
                    {
                        writer.WriteLine(goal.Serialize());
                    }
                }
                Console.WriteLine($"Goals successfully saved at: {fullPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving goals: {ex.Message}");
            }
        }


        // Loads the score and goals from a file.
        static void LoadGoals()
        {
            Console.Write("Enter filename to load goals (e.g., goals.txt): ");
            string filename = Console.ReadLine();

            // Searches the fine from the base directory.
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.Combine(folder, filename);

            Console.WriteLine("Looking for file at: " + fullPath);
            if (!File.Exists(fullPath))
            {
                Console.WriteLine("File does not exist. Please ensure the file is in the same folder as the program.");
                return;
            }

            try
            {
                using (StreamReader reader = new StreamReader(fullPath))
                {
                    // Read total score and clear any existing data.
                    totalScore = int.Parse(reader.ReadLine());
                    goals.Clear();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        string[] parts = line.Split(';');
                        string goalType = parts[0];
                        switch (goalType)
                        {
                            case "SimpleGoal":
                                goals.Add(SimpleGoal.Deserialize(parts));
                                break;
                            case "EternalGoal":
                                goals.Add(EternalGoal.Deserialize(parts));
                                break;
                            case "ChecklistGoal":
                                goals.Add(ChecklistGoal.Deserialize(parts));
                                break;
                            case "NegativeGoal":
                                goals.Add(NegativeGoal.Deserialize(parts));
                                break;
                            default:
                                Console.WriteLine("Unknown goal type encountered in file.");
                                break;
                        }
                    }
                }
                Console.WriteLine("Goals successfully loaded!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading goals: {ex.Message}");
            }
        }



        // Helper method to read an integer with error checking.
        static int ReadInteger(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value))
                    return value;
                else
                    Console.WriteLine("Please enter a valid integer value.");
            }
        }

        // Exceeding Requirement: A simple leveling system based on total points.
        static void UpdateLevel()
        {
            // Every 1000 points increases the user level by 1.
            int newLevel = (totalScore / 1000) + 1;
            if (newLevel > userLevel)
            {
                userLevel = newLevel;
                string levelMessage = GetLevelMessage(userLevel);
                Console.WriteLine($"Congratulations! You've reached Level {userLevel}! {levelMessage}");
            }
        }

        static string GetLevelMessage(int level)
        {
            // Customize the messages for each level as desired.
            switch (level)
            {
                case 2:
                    return "Great job! You're off to a strong start.";
                case 3:
                    return "Awesome work! Your progress is on fire.";
                case 4:
                    return "Excellent! You're making a huge impact.";
                case 5:
                    return "Impressive! You've reached a milestone.";
                case 6:
                    return "Fantastic! Your quest is truly epic.";
                // Add more cases as needed.
                default:
                    return "Keep pushing for new heights!";
            }
        }

    }
}
