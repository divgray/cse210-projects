using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MindfulnessProgram
{
    abstract class MindfulnessActivity
    {
        protected int Duration;
        protected string ActivityName;
        protected string ActivityDescription;

        public MindfulnessActivity(string activityName, string activityDescription)
        {
            ActivityName = activityName;
            ActivityDescription = activityDescription;
        }

        // Displays the common starting message plus asks the user for a duration.
        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {ActivityName}.");
            Console.WriteLine(ActivityDescription);
            Console.Write("Enter duration in seconds: ");
            try
            {
                Duration = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Duration = 30; // fallback default duration
            }
            Console.WriteLine("Get Ready...");
            PauseWithSpinner(3);
            Console.Clear();
        }

        // Displays a spinner animation.
        protected void PauseWithSpinner(int seconds)
        {
            int spinnerIterations = seconds * 10;
            string[] spinner = { "|", "/", "-", "\\" };
            for (int i = 0; i < spinnerIterations; i++)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(100);
                Console.Write("\b");
            }
        }

        // Displays a numeric countdown on the screen.
        protected void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b"); // erase number
            }
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine("Well done!");
            PauseWithSpinner(3);
            Console.WriteLine($"You have completed {Duration} seconds of the {ActivityName}.");
            PauseWithSpinner(3);
        }
        public abstract void RunActivity();
    }

    class BreathingActivity : MindfulnessActivity
    {
        public BreathingActivity()
            : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        public override void RunActivity()
        {
            DisplayStartingMessage();

            // Loop until the selected duration is reached.
            DateTime startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < Duration)
            {
                Console.Write("Breathe in... ");
                Countdown(4); // breathe in for 4 seconds
                Console.WriteLine();

                Console.Write("Breathe out... ");
                Countdown(6); // breathe out for 6 seconds
                Console.WriteLine();
            }

            DisplayEndingMessage();
        }
    }
    class ReflectionActivity : MindfulnessActivity
    {
        private List<string> Prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> Questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity()
            : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
        }

        public override void RunActivity()
        {
            DisplayStartingMessage();
            Random random = new Random();

            // Display a random prompt.
            string prompt = Prompts[random.Next(Prompts.Count)];
            Console.WriteLine(prompt);
            Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
            Console.ReadLine();

            Console.WriteLine("Now, reflect on each of the following questions as they relate to your experience.");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Loop until the overall duration is met.
            while (stopwatch.Elapsed.TotalSeconds < Duration)
            {
                string question = Questions[random.Next(Questions.Count)];
                Console.WriteLine($"> {question}");
                PauseWithSpinner(5); // allow 5 seconds of reflection per question
                Console.WriteLine();
            }
            stopwatch.Stop();

            DisplayEndingMessage();
        }
    }
    class ListingActivity : MindfulnessActivity
    {
        private List<string> Prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity()
            : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        public override void RunActivity()
        {
            DisplayStartingMessage();
            Random random = new Random();

            string prompt = Prompts[random.Next(Prompts.Count)];
            Console.WriteLine(prompt);
            Console.WriteLine("You will have a few seconds to think about it.");
            Countdown(5);
            Console.WriteLine("Start listing items. Press Enter after each item:");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int itemCount = 0;
            List<string> items = new List<string>();

            // Loop to accept entries until the time is up.
            while (stopwatch.Elapsed.TotalSeconds < Duration)
            {
                double remainingTime = Duration - stopwatch.Elapsed.TotalSeconds;
                Console.Write(">> ");
                // Use Task.Run with Wait to allow input until timeout.
                Task<string> inputTask = Task.Run(() => Console.ReadLine());
                if (inputTask.Wait(TimeSpan.FromSeconds(remainingTime)))
                {
                    string input = inputTask.Result;
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        items.Add(input);
                        itemCount++;
                    }
                }
                else
                {
                    break;
                }
            }
            stopwatch.Stop();

            Console.WriteLine($"\nYou listed {itemCount} items.");
            DisplayEndingMessage();
        }
    }

    // Main program with a menu system to choose the mindfulness activity.
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("-----------------------");
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
                        Console.WriteLine("Goodbye!");
                        continue;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        Thread.Sleep(2000);
                        continue;
                }

                activity.RunActivity();
                Console.WriteLine("Press Enter to return to the main menu.");
                Console.ReadLine();
            }
        }
    }
}
