using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MindfulnessProgram
{
    public class ListingActivity : MindfulnessActivity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are your personal strengths?",
            "Who are people you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity()
            : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many items as possible in a certain area.")
        {
        }

        public override void RunActivity()
        {
            DisplayStartingMessage();

            Random random = new Random();
            // Select a random prompt.
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            Console.WriteLine("You will have a few seconds to think about this.");
            Countdown(5);
            Console.WriteLine("Now, list as many items as you can. Press Enter after each item:");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int itemCount = 0;
            List<string> items = new List<string>();

            // Accept entries until the specified duration is reached.
            while (stopwatch.Elapsed.TotalSeconds < _duration)
            {
                double remainingTime = _duration - stopwatch.Elapsed.TotalSeconds;
                Console.Write(">> ");
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
}
