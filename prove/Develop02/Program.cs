using System;
using System.Collections.Generic;

//Write a new entry - Show the user a random prompt (from a list that you create), and save their response, the prompt, and the date as an Entry.
//Display the journal - Iterate through all entries in the journal and display them to the screen.
//Save the journal to a file - Prompt the user for a filename and then save the current journal (the complete list of entries) to that file location.
//Load the journal from a file - Prompt the user for a filename and then load the journal (a complete list of entries) from that file. This should replace any entries currently stored the journal.
//Provide a menu that allows the user choose these options
//Your list of prompts must contain at least five different prompts. Make sure to add your own prompts to the list, but the following are examples to help get you started

namespace Develop02 {
    class Program
    {
        static void Main(string[] args)
        {

            // create a journal to test
            Journal journal = new Journal();

            journal.Menu();

        }
    }
}