using System;

class Program
{
    static void Main(string[] args)
    {
        // Stretch #2 keep playing loop if the user wants to continue
        string answer;
        do 
        {
            Random randomGenerator = new Random();
            int magic_number = randomGenerator.Next(1, 100);
            // Console.Write("What is the magic number? ");
            // int magic_number = int.Parse(Console.ReadLine());

            int your_guess;
            int guessCount = 0;
            bool guessedCorrectly = false;

            while (!guessedCorrectly) // Stretch #1 Keeping track of the guesses the user made.
            {
                Console.Write("What is your guess? ");
                your_guess = int.Parse(Console.ReadLine()); // directly saving the data from user as int
                guessCount ++;
                if (your_guess > magic_number)
                {
                    Console.WriteLine("Lower");
                }
                else if (your_guess < magic_number)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine($"You guessed right! It took you {guessCount} guesses.");
                    guessedCorrectly = true;
                }
            }

        Console.WriteLine("Do you want to continue? ");
        answer = Console.ReadLine();
        } while (answer == "yes");
        Console.WriteLine("Thank you for playing!");
    }
}