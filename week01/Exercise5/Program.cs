using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayResult();
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int UserNumber)
    {
        return UserNumber * UserNumber;
    }

    static void DisplayResult()
    {
        DisplayWelcome();
        string name = PromptUserName();
        int UserNumber = PromptUserNumber();
        int squared = SquareNumber(UserNumber);
        Console.WriteLine($"{name}, the square of your number is {squared}");

    }
}