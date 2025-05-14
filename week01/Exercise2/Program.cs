using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int grade = int.Parse(answer);

        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else if (grade < 60)
        {
            letter = "F";
        }

        // trying stretch
        // converting to string so i can use len to determine the second number of the grade.
        string sign = "";
        string dataStr = grade.ToString();
        if (dataStr.Length > 1)
        {
            int secondDigit = int.Parse(dataStr[1].ToString());
            if (secondDigit > 7)
            {
                sign = "+";
            }
            else if (secondDigit < 3)
            {
                sign = "-";
            }
        }

        if (grade > 97 || grade < 60)
        {
            sign = "";
        }

        Console.Write($"Your grade is {sign}{letter}. "); // if i added Line in Write, it will be in a different line.

        if (letter == "A" || letter == "B")
        {
            Console.WriteLine("Congratulations! You have passed.");
        }
        else
        {
            Console.WriteLine("You did not pass. Goodluck next time.");
        }
    }
}