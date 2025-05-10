using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        int sum = 0;
        int count = 0;
        double average = 0.0;

        int? largestNumber = null; // Using a nullable int to handle uninitialized state
        int? lowestPositive = null;


        List<int> numbers = new List<int>();
        // for Stretch # 2
        var sortedNumbers = numbers.OrderBy(n => n);
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        // int number = int.Parse(Console.ReadLine());

        while (true)
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Wrong data input. please enter whole numbers.");
                continue;
            }
            if (number == 0)
            {
                break;
            }

            numbers.Add(number);
            sum += number;
            count ++;
            average = (double)sum / count;

            if (!largestNumber.HasValue || number > largestNumber.Value)
            {
                largestNumber = number;
            }

            if (number > 0)
            {
                // For stretch # 1 For lowest Positive (the positive number closest to zero)
                if (!lowestPositive.HasValue || number < lowestPositive.Value)
                {
                    lowestPositive = number;
                }
            }

        }
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"The largest number is {largestNumber}");
        if (lowestPositive.HasValue)
        {
            Console.WriteLine($"The smallest positive number is {lowestPositive}");
        }
        // Stretch # 2
        Console.WriteLine("The following numbers you provided from lowest to highest:");
        foreach (int num in sortedNumbers)
        {
            Console.WriteLine(num);
        }
    }
}
