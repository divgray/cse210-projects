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
        int percentage = grade;
        string dataStr = percentage.ToString();
        // converting to string so i can use len to determine the second number of the grade.
        int secondDigit = int.Parse(dataStr[1].ToString());
        string sign = "";
        if(secondDigit > 7)
        {
            sign = "+";
        }
        else if(secondDigit < 3)
        {
            sign = "-";
        }
        else if (grade > 97 || grade < 63)
        {
            sign ="";
        }
        else
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
            Console.WriteLine("You did not pass.");
        }
    }
}