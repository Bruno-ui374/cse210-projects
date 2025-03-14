using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int inputInt = -1; 

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (inputInt != 0)
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            inputInt = int.Parse(input);

            if (inputInt != 0)
            {
                numbers.Add(inputInt);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

    float average = (float)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The largest number is: {max}");
    }
}
