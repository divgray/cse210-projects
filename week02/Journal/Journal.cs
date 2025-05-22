using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    public class Journal
    {

        // Holds all entries.
        private List<Entry> entries { get; set; } = new List<Entry>();

        public Journal()
        {
            entries = new List<Entry>();
        }

        // Add entry to the journal.
        public void AddEntry(Entry entry)
        {
            entries.Add(entry);
        }

        // Display all entries in the journal.
        public void DisplayEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("No journal entries available.");
            }
            else
            {
                foreach (var entry in entries)
                {
                    Console.WriteLine(entry.ToString());
                }
            }
        }

        // Save the current journal entries to a file.
        public void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    // Each entry is stored on its own line using '|' to separate them.
                    foreach (var entry in entries)
                    {
                        // Using ISO 8601 format for the date for easy parsing.
                        writer.WriteLine($"{entry.Date.ToString("o")}|{entry.Prompt}|{entry.Response}");
                    }
                }
                Console.WriteLine("Journal saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving journal: {ex.Message}");
            }
        }

        // Load journal entries from a file.
        public void LoadFromFile(string filename)
        {
            try
            {
                if (!File.Exists(filename))
                {
                    Console.WriteLine("File not found.");
                    return;
                }

                entries.Clear();
                foreach (var line in File.ReadAllLines(filename))
                {
                    // Expecting each line to have 3 parts separated by '|'.
                    var parts = line.Split('|');
                    if (parts.Length >= 3)
                    {
                        DateTime date = DateTime.Parse(parts[0], null, System.Globalization.DateTimeStyles.RoundtripKind);
                        string prompt = parts[1];

                        // In case the response contains the delimiter, join the rest.
                        string response = string.Join("|", parts, 2, parts.Length - 2);
                        AddEntry(new Entry(date, prompt, response));
                    }
                }
                Console.WriteLine("Journal loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading journal: {ex.Message}");
            }
        }

        public void DisplayLastEntryReminder()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("No previous entries found. Why not start your journal today?");
                return;
            }

            // Assumes the most recent entry is the last one added.
            Entry lastEntry = entries[entries.Count - 1];

            // Calculate how much time has passed since the last entry.
            TimeSpan timeSinceLastEntry = DateTime.Now - lastEntry.Date;

            if (timeSinceLastEntry.TotalDays < 1)
            {
                Console.WriteLine("You've already written an entry today! Good Work!");
            }
            else if (timeSinceLastEntry.TotalDays < 3)
            {
                Console.WriteLine($"It's been {timeSinceLastEntry.Days} day(s) since your last entry. C'mon keep up the momentum!");
            }
            else
            {
                Console.WriteLine($"It's been {timeSinceLastEntry.Days} day(s) since your last entry. We would love to read your thoughts.");
            }

            // all entries are saved in the bin.
        }
    }
}
