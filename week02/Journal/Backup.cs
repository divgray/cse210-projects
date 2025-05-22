// using System;

// namespace JournalApp
// {
//     class Backup
//     {
//         static void Main(string[] args)
//         {
//             Journal journal = new Journal();
//             PromptGenerator promptGenerator = new PromptGenerator();
//             bool exit = false;

//             while (!exit)
//             {
//                 // Menu options for the user.
//                 Console.WriteLine("\nJournal Menu:");
//                 Console.WriteLine("1. Write a new entry");
//                 Console.WriteLine("2. Display the journal");
//                 Console.WriteLine("3. Save the journal to a file");
//                 Console.WriteLine("4. Load the journal from a file");
//                 Console.WriteLine("5. Exit");
//                 Console.Write("Enter your choice: ");
//                 string choice = Console.ReadLine();

//                 switch (choice)
//                 {
//                     case "1":
//                         // Generate a random prompt and capture the user's answer.
//                         string prompt = promptGenerator.GetRandomPrompt();
//                         Console.WriteLine($"\nPrompt: {prompt}");
//                         Console.Write("Enter your response: ");
//                         string response = Console.ReadLine();
//                         Entry newEntry = new Entry(DateTime.Now, prompt, response);
//                         journal.AddEntry(newEntry);
//                         Console.WriteLine("Entry added.");
//                         break;
//                     case "2":
//                         // Display all journal entries.
//                         Console.WriteLine("\nJournal Entries:");
//                         journal.DisplayEntries();
//                         break;
//                     case "3":
//                         // Save journal to a file.
//                         Console.Write("Enter filename to save the journal: ");
//                         string saveFilename = Console.ReadLine();
//                         journal.SaveToFile(saveFilename);
//                         break;
//                     case "4":
//                         // Load journal from a file.
//                         Console.Write("Enter filename to load the journal: ");
//                         string loadFilename = Console.ReadLine();
//                         journal.LoadFromFile(loadFilename);
//                         break;
//                     case "5":
//                         exit = true;
//                         Console.WriteLine("Exiting the application.");
//                         break;
//                     default:
//                         Console.WriteLine("Invalid choice, please try again.");
//                         break;
//                 }
//             }
//         }
//     }
// }
