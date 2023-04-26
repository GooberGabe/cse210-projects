using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? ");
        int grade = int.Parse(Console.ReadLine());
        string letter = "";

        if (grade >= 90)
            letter = "A";
        else if (grade >= 80)
            letter = "B";
        else if (grade >= 70)
            letter = "C";
        else if (grade >= 60)
            letter = "D";
        else
            letter = "F";

        int second_digit = grade % 10;
        if (letter != "F" && grade < 97) {
            if (second_digit >= 7)
                letter+="+";
            if (second_digit <= 3)
                letter+="-";
        }

        Console.WriteLine($"You got a {letter}.");
        if (grade >= 70) {
            Console.WriteLine("Congratulations, you passed!");
        } else {
            Console.WriteLine("You didn't pass the class. Better luck next time!");
        }
    }
}