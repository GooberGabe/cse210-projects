using System;

namespace Develop02
{    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Book: ");
            string book = Console.ReadLine();
            Console.WriteLine("Chapter: ");
            int chapter = int.Parse(Console.ReadLine());
            Console.WriteLine("Verse(s): ");
            string verses = Console.ReadLine();
            Console.WriteLine("Text: ");
            string text = Console.ReadLine();

            Reference reference = new Reference(book, chapter, verses);
            Scripture scripture = new Scripture(reference, text);

            string input = "";
            while (input != "Quit" && !scripture.AllWordsHidden()) {
                Console.Clear();
                scripture.Display();
                Console.Write("Press spacebar to continue or Quit to exit the program.");
                Console.ReadLine();
                scripture.HideWord();
            }
        }


    }
}