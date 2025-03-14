using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            int magicNumberInt = randomGenerator.Next(1, 101);
            int guessInt = -1;
            int guessCount = 0;

            while (guessInt != magicNumberInt)
            {
                Console.Write("What is your guess? ");
                string guess = Console.ReadLine();
                guessInt = int.Parse(guess);
                guessCount++;

                if (guessInt == magicNumberInt)
                {
                    Console.WriteLine("Congratulations! You guessed the magic number!");
                }
                else if (guessInt < magicNumberInt)
                {
                    Console.WriteLine("Higher");
                }
                else if (guessInt > magicNumberInt)
                {
                    Console.WriteLine("Lower");
                }
            }

            Console.WriteLine($"You made {guessCount} guesses.");
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("Thanks for playing! Goodbye!");
    }
}
