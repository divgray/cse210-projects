using System;
using System.Collections.Generic;

namespace JournalApp
{
    public class PromptGenerator
    {
        private List<string> prompts;
        private Random random;

        public PromptGenerator()
        {
            // Define at least five different prompts. pfft
            prompts = new List<string>()
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",

                "How are you feeling right now?",
                "What did you eat today?",
                "What music best describes your day?"
            };

            random = new Random();
        }

        // Returns a random prompt from the list.
        public string GetRandomPrompt()
        {
            int index = random.Next(prompts.Count);
            return prompts[index];
        }
    }
}
