using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int input = -1;
        List<int> numbers = new List<int>();

        while (input != 0) {
            Console.Write("Enter a number: ");
            input = int.Parse(Console.ReadLine());
            if (input != 0) numbers.Add(input);
        }

        int sum = 0;
        int largest = 0;

        foreach (int n in numbers) {
            sum+=n;
            if (n > largest) {
                largest = n;
            }
        }

        Console.WriteLine($"The sum is {sum}.");
        Console.WriteLine($"The average is {sum / numbers.Count}.");
        Console.WriteLine($"The largest number is {largest}.");

    }
}