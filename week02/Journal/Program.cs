using System;

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            PromptGenerator promptGenerator = new PromptGenerator();
            bool exit = false;

            while (!exit)
            {
                // Menu options.
                Console.WriteLine("\nJournal Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Load the journal from a file");
                Console.WriteLine("4. Save the journal to a file");
                Console.WriteLine("5. Exit");
                Console.Write("Enter the number of your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Generate a random prompt and get the users answer.
                        string prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine($"\nPrompt: {prompt}");
                        Console.Write("Enter your response: ");
                        string response = Console.ReadLine();
                        Entry newEntry = new Entry(DateTime.Now, prompt, response);
                        journal.AddEntry(newEntry);
                        Console.WriteLine("Entry added.");
                        break;
                    case "2":
                        // Display all journal entries.
                        Console.WriteLine("\nJournal Entries:");
                        journal.DisplayEntries();
                        break;
                    case "3":
                        // Load journal from a file.
                        Console.Write("Enter filename to load the journal: ");
                        string loadFilename = Console.ReadLine();
                        journal.LoadFromFile(loadFilename);
                        journal.DisplayEntries();
                        break;
                    case "4":
                        // Save journal to a file.
                        Console.Write("Enter filename to save the journal: ");
                        string saveFilename = Console.ReadLine();
                        journal.SaveToFile(saveFilename);
                        journal.DisplayEntries();
                        break;

                    case "5":
                        // Before exiting, display the last entry message.
                        journal.DisplayLastEntryReminder();
                        exit = true;
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}
