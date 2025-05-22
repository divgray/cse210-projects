using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    public class Journal
    {
        // Private member (abstraction) that holds all entries.
        private List<Entry> entries;

        public Journal()
        {
            entries = new List<Entry>();
        }

        // Add an entry to the journal.
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
                    // Each entry is stored on its own line using '|' as a delimiter.
                    foreach (var entry in entries)
                    {
                        // Using ISO 8601 format for the date for easy parsing.
                        writer.WriteLine($"{entry.Date.ToString("o")} | {entry.Prompt}|{entry.Response}");
                    }
                }
                Console.WriteLine("Journal saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving journal: {ex.Message}");
            }
        }

        // Load journal entries from a file. This replaces the current entries. hmm
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
    }
}
