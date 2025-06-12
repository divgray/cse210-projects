using System;
using System.Threading;

namespace MindfulnessProgram
{
    public class BreathingActivity : MindfulnessActivity
    {
        public BreathingActivity()
            : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing.")
        {
        }

        private void AnimateLetter(bool isGrowing, int cycles, int delay)
        {
            if (isGrowing)
            {
                for (int i = 1; i <= cycles; i++)
                {
                    // To fix the flickering from before.
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write("Breathe in... " + new string('O', i));
                    Thread.Sleep(delay);
                }
            }
            else
            {
                for (int i = cycles; i > 0; i--)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write("Breathe out... " + new string('O', i));
                    Thread.Sleep(delay);
                }
            }
        }


        public override void RunActivity()
        {
            DisplayStartingMessage();

            int cycles = 10;
            int delay = 300;
            DateTime startTime = DateTime.Now;

            while ((DateTime.Now - startTime).TotalSeconds < _duration)
            {
                AnimateLetter(true, cycles, delay);
                AnimateLetter(false, cycles, delay);
            }

            DisplayEndingMessage();
        }

    }
}
