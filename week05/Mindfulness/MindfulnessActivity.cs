using System;
using System.Threading;

namespace MindfulnessProgram
{
    // Abstract base class that holds common attributes and behaviors for all activities.
    public abstract class MindfulnessActivity
    {
        protected int _duration;
        protected string _activityName;
        protected string _activityDescription;

        public MindfulnessActivity(string activityName, string activityDescription)
        {
            _activityName = activityName;
            _activityDescription = activityDescription;
        }

        // Display the starting message and get the duration from the user.
        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_activityName}.");
            Console.WriteLine(_activityDescription);
            Console.Write("Enter duration in seconds: ");
            try
            {
                _duration = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                _duration = 30; // fallback default duration
            }
            Console.WriteLine("Get ready...");
            PauseWithSpinner(3);
            Console.Clear();
        }

        // Pauses the execution and shows a spinner animation.
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

        // Displays a countdown on the screen.
        protected void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                // Overwrite the number so it appears to count down.
                Console.Write("\b \b");
            }
        }

        // Display common ending message.
        public void DisplayEndingMessage()
        {
            Console.WriteLine("Well done!");
            PauseWithSpinner(3);
            Console.WriteLine($"You have completed {_duration} seconds of the {_activityName}.");
            PauseWithSpinner(3);
        }

        // Abstract method to force each derived class to implement its activity.
        public abstract void RunActivity();
    }
}
