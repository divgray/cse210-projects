using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace MindfulnessProgram
{
    public class ReflectionActivity : MindfulnessActivity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
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
            : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. Recognize your power and how you can use it in other aspects of your life.")
        {
        }

        public override void RunActivity()
        {
            DisplayStartingMessage();

            Random random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            Console.WriteLine("\nWhen you have something in mind, press Enter to continue...");
            Console.ReadLine();

            Console.WriteLine("Now, reflect on each of the following questions as they relate to your experience.");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (stopwatch.Elapsed.TotalSeconds < _duration)
            {
                string question = _questions[random.Next(_questions.Count)];
                Console.WriteLine($"> {question}");
                PauseWithSpinner(5); // allow 5 seconds for reflection per question
                Console.WriteLine();
            }
            stopwatch.Stop();

            DisplayEndingMessage();
        }
    }
}
