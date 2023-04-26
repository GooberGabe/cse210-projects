using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");
    }

    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName() {
        Console.Write("What is your username?");
        return Console.ReadLine();
    }

    static int PromptUserNumber() {
        Console.Write("What is your favorite number?");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number) {
        return (int)Math.Pow(number, 2);
    }

    static void DisplayResult() {
        string name = PromptUserName();
        int sqn = SquareNumber(PromptUserNumber());
        Console.WriteLine($"{name}, the square of your number is {sqn}");
    }
}