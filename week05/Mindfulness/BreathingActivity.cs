using System;

namespace MindfulnessProgram
{
    public class BreathingActivity : MindfulnessActivity
    {
        public BreathingActivity()
            : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing.")
        {
        }

        public override void RunActivity()
        {
            DisplayStartingMessage();

            DateTime startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < _duration)
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
}
