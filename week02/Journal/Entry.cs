using System;

namespace JournalApp
{
    public class Entry
    {
        public DateTime Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }

        public Entry(DateTime date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }

        // Override ToString() to present the entry nicely. oh
        public override string ToString()
        {
            return $"Date: {Date.ToShortDateString()}\nPrompt: {Prompt}\nResponse: {Response}\n";
        }
    }
}
