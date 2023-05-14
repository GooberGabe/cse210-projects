using System;
using System.Collections.Generic;

// To exceed requirements, I implemented the save/load functions with JSON instead of CSV. I felt that this was a reasonable change because 
// JSON formats the data in terms of class objects, which this program is built around. It was challenging to figure out how to get it to
// work at first, but I eventually figured out that I had to add get/set to the entry variables in order to make it work. 

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