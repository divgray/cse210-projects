using System;
using System.Threading;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");
                Console.Write("Select a choice from the menu: ");
                string choice = Console.ReadLine();

                MindfulnessActivity activity = null;
                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("Till next time. Goodbye!");
                        Thread.Sleep(2000);
                        continue;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        Thread.Sleep(2000);
                        continue;
                }

                activity.RunActivity();
                Console.WriteLine("Press Enter to return to the main menu...");
                Console.ReadLine();
            }
        }
    }
}
