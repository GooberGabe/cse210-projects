using System;

class Program
{
    static void Main(string[] args)
    {
        int guess = -1;
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1,11);
        int guesses = 0;

        while (guess != number) {
            Console.Write("What is the magic number? ");
            guess = int.Parse(Console.ReadLine());
            if (guess > number) {
                Console.WriteLine("Lower!");
            }
            if (guess < number) {
                Console.WriteLine("Higher!");
            }
            guesses +=1; 
        }
        Console.WriteLine("You guessed it!");
        Console.WriteLine($"It took you {guesses} tries.");
    }
}