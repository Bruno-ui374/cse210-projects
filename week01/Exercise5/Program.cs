using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string username = PromptUsername();
        int number = PromptUserNumber();
        int squareNumber = SquareNumber(number);
        string result = DisplayResult(username, squareNumber);

        Console.WriteLine(result);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUsername()
    {
        Console.Write("Please enter your name: ");
        string username = Console.ReadLine();
        return username;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter a number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static string DisplayResult(string username, int squareNumber)
    {
        return $"{username}, the square of your number is {squareNumber}";
    }
}
