using System;

class Program
{
    static void Main(string[] args)
    {
        // For multiple scripture mastery
        ScriptureCollection collection = new ScriptureCollection();

        // Given Example 1
        Reference ref1 = new Reference("John", 3, 16);
        string text1 = "For God so loved the world that he gave his one and only Son.";
        Scripture scripture1 = new Scripture(ref1, text1);
        collection.AddScripture(scripture1);

        // Given Example 2
        Reference ref2 = new Reference("Proverbs", 3, 5, 6);
        string text2 = "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.";
        Scripture scripture2 = new Scripture(ref2, text2);
        collection.AddScripture(scripture2);

        // Scripture Mastery 3
        Reference ref3 = new Reference("2 Nephi", 2, 25);
        string text3 = "Adam fell that men might be; and men are, that they might have joy.";
        Scripture scripture3 = new Scripture(ref3, text3);
        collection.AddScripture(scripture3);

        // Scripture Mastery 4
        Reference ref4 = new Reference("2 Nephi", 32, 3);
        string text4 = "Angels speak by the power of the Holy Ghost; wherefore, they speak the words of Christ. Wherefore, I said unto you, feast upon the words of Christ; for behold, the words of Christ will tell you all things what ye should do.";
        Scripture scripture4 = new Scripture(ref4, text4);
        collection.AddScripture(scripture4);

        // Scripture Mastery 5
        Reference ref5 = new Reference("Mosiah", 2, 17);
        string text5 = "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God.";
        Scripture scripture5 = new Scripture(ref5, text5);
        collection.AddScripture(scripture5);

        // Scripture Mastery 6
        Reference ref6 = new Reference("Alma", 32, 21);
        string text6 = "And now as I said concerning faith—faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true.";
        Scripture scripture6 = new Scripture(ref6, text6);
        collection.AddScripture(scripture6);

        // Scripture Mastery 7
        Reference ref7 = new Reference("Alma", 37, 35);
        string text7 = "O, remember, my son, and learn wisdom in thy youth; yea, learn in thy youth to keep the commandments of God.";
        Scripture scripture7 = new Scripture(ref7, text7);
        collection.AddScripture(scripture7);

        // Scripture Mastery 8
        Reference ref8 = new Reference("Ether", 12, 6);
        string text8 = "And now, I, Moroni, would speak somewhat concerning these things; I would show unto the world that faith is things which are hoped for and not seen; wherefore, dispute not because ye see not, for ye receive no witness until after the trial of your faith.";
        Scripture scripture8 = new Scripture(ref8, text8);
        collection.AddScripture(scripture8);

        // Scripture Mastery 9
        Reference ref9 = new Reference("3 Nephi", 11, 29);
        string text9 = "For verily, verily I say unto you, he that hath the spirit of contention is not of me, but is of the devil, who is the father of contention, and he stirreth up the hearts of men to contend with anger, one with another.";
        Scripture scripture9 = new Scripture(ref9, text9);
        collection.AddScripture(scripture9);

        // Scripture Mastery 10
        Reference ref10 = new Reference("Moroni", 7, 45);
        string text10 = "And charity suffereth long, and is kind, and envieth not, and is not puffed up, seeketh not her own, is not easily provoked, thinketh no evil, and rejoiceth not in iniquity but rejoiceth in the truth, beareth all things, believeth all things, hopeth all things, endureth all things.";
        Scripture scripture10 = new Scripture(ref10, text10);
        collection.AddScripture(scripture10);


        // Pick random from the collection
        Scripture currentScripture = collection.GetRandomScripture();

        // Continues until the user types "quit"
        while (true)
        {
            // Safely attempt to clear the console so it continues running smoothly/.
            if (!Console.IsOutputRedirected)
            {
                try
                {
                    Console.Clear();
                }
                catch (Exception) { }
            }

            // Display the current scripture (with hidden words if any)
            Console.WriteLine(currentScripture.ToString());

            // If the scripture is fully hidden, notify the user
            if (currentScripture.AllWordsHidden())
            {
                Console.WriteLine("\nThis scripture verse is fully hidden.");
            }

            Console.WriteLine("\nPress Enter to hide more words, type 'next' for a new scripture verse, or type 'quit' to exit the program:");
            string userInput = Console.ReadLine().Trim().ToLower(); // Returns user input as string, removes excess spaces and all in lower case

            if (userInput == "quit")
            {
                // Exit only when user typed quit
                Console.WriteLine("\nExiting the Program. Good Bye.\n");
                break;
            }
            else if (userInput == "next")
            {
                // Load a new scripture verse
                currentScripture = collection.GetRandomScripture();
            }
            else if (userInput == "")
            {
                // When Enter is pressed
                if (!currentScripture.AllWordsHidden())
                {
                    // Hide three random words if not all are already hidden.
                    currentScripture.HideRandomWords(3);
                }
                else
                {
                    // If the scripture is fully hidden, remind the user to choose a new scripture or quit.
                    Console.WriteLine("This scripture is already fully hidden. Please type 'next' for a new scripture or 'quit' to exit program.");
                    Console.ReadLine(); // Does nothing, wait for the user to acknowledge the message.
                }
            }
            else
            {
                // Handle unrecognized input.
                Console.WriteLine("Unrecognized command. Please type 'quit', 'next', or simply press Enter.");
                Console.ReadLine(); // Does nothing, pauses so the user can read the message.
            }
        }
    }
}
