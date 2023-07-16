using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Final_Project
{
    class Player
    {
        private PlaybackSetup _current; // The setup that’s currently being used

        public Player()
        {
            _current = new PlaybackSetup();
            _current.Load();
        }

        public void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("      -- Menu --");
                int i = 0;
                foreach (Category category in _current.GetCategories())
                {
                    Console.WriteLine($"[{i}] {category.GetName()}: {category.ShowStatus()} ");
                    i++;
                }
                Console.WriteLine();
                Console.WriteLine("[a] Add category [s] Save playback setup [x] Exit");
                Console.WriteLine("Enter the number of a category to toggle it or adjust volume.");
                string inp = Console.ReadLine();
                switch (inp)
                {
                    case "a":
                        AddCategory();
                        break;
                    case "s":
                        _current.Save(); // Ideally the user would be able to save multiple differnet PlaybackSetups (that's the whole point of having a dedicated class for
                        break;           // PlaybackSetups) but due to time constraints I have not implemented this.
                    case "x":
                        exit = true;
                        break;
                    default:
                        int categorySelect = int.Parse(inp);
                        _current.GetCategories()[categorySelect].Interact();
                        break;

                }
            }
        }

        private void AddCategory()
        {
            Console.Clear();
            Console.WriteLine("What kind of category would you like to create?");
            Console.WriteLine("[0] Ambience [1] Music");
            string categoryType = Console.ReadLine();
            Console.WriteLine("What is the name of this new category?");
            string name = Console.ReadLine();
            Console.WriteLine("To use this category, you need to manually create a folder to store the audio tracks in.");
            Console.WriteLine("Where is the file location where tracks of this category will be stored?");
            string location = Console.ReadLine();

            Category category;
            if (categoryType == "0")
            {
                category = new Ambience(location, name);
                _current.AddCategory(category);
            } 
            if (categoryType == "1")
            {
                category = new Music(location, name);
                _current.AddCategory(category);
            }
            
        }

    }
}
