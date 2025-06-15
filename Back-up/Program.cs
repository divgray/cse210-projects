using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager manager = new GoalManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n----- Eternal Quest -----");
                Console.WriteLine("1. Create Goal");
                Console.WriteLine("2. Record Event");
                Console.WriteLine("3. Display Goals");
                Console.WriteLine("4. Show Score");
                Console.WriteLine("5. Save Goals");
                Console.WriteLine("6. Load Goals");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreateGoal(manager);
                        break;
                    case "2":
                        manager.DisplayGoals();
                        Console.Write("Select goal number: ");
                        int index = int.Parse(Console.ReadLine()) - 1;
                        manager.RecordEvent(index);
                        break;
                    case "3":
                        manager.DisplayGoals();
                        break;
                    case "4":
                        Console.WriteLine($"Total Score: {manager.TotalScore}");
                        break;
                    case "5":
                        manager.SaveGoals("goals.txt");
                        break;
                    case "6":
                        try
                        {
                            manager.LoadGoals("goals.txt");
                            Console.WriteLine("Goals loaded successfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error loading goals: {ex.Message}");
                        }
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection.");
                        continue;
                }
            }
        }

        static void CreateGoal(GoalManager manager)
        {
            Console.WriteLine("Goal Type: (1) Simple, (2) Eternal, (3) Checklist");
            string type = Console.ReadLine();
            Console.Write("Goal Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string desc = Console.ReadLine();
            Console.Write("Points: ");
            int points = int.Parse(Console.ReadLine());

            Goal goal = null;

            if (type == "3")
            {
                Console.Write("Target Count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, desc, points, targetCount, bonus);
            }
            else
            {
                goal = type switch
                {
                    "1" => new SimpleGoal(name, desc, points),
                    "2" => new EternalGoal(name, desc, points),
                    _ => null
                };
            }

            if (goal != null)
            {
                manager.CreateGoal(goal);
                Console.WriteLine("Goal successfully created!");
            }
            else
            {
                Console.WriteLine("Invalid goal type!");
            }
        }

    }
}
