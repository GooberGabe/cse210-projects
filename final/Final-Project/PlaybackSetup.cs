using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class PlaybackSetup
    {
        private List<Category> _categoryList; // All of the categories the user has created for this PlaybackSetup

        public PlaybackSetup()
        {
            _categoryList = new List<Category>();
        }

        public void Save()
        {
            string output = "";
            foreach (var category in _categoryList)
            {
                output += (category.Serialize() + "\n");
            }
            string fileName = "setup.txt";

            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.Write(output);

            }
        }

        public void Load()
        {
            string filename = "setup.txt";

            try
            {
                string[] lines = File.ReadAllLines(filename);
                for (int i = 0; i < lines.Length; i++)
                {

                    string[] attributes = lines[i].Split('+');
                    string type = ParseAttribute(attributes, 2);
                    string name = ParseAttribute(attributes, 0);
                    string dir = ParseAttribute(attributes, 1);
                    if (type == "Final_Project.Ambience")
                    {
                        Ambience category = new Ambience(dir, name);
                        AddCategory(category);
                    }
                    if (type == "Final_Project.Music")
                    {
                        Music category = new Music(dir, name);
                        AddCategory(category);
                    }

                }
            }
            catch(Exception ex)
            {
                File.Create(filename);
            }
        }

        private string ParseAttribute(string[] attributes, int index)
        {
            return attributes[index].Split('#')[1];
        }

        public List<Category> GetCategories()
        {
            return _categoryList;
        }

        public void RemoveCategory(Category category)
        {
            _categoryList.Remove(category);
        }

        public void RemoveCategory(int index)
        {
            _categoryList.RemoveAt(index);
        }

        public void AddCategory(Category category)
        {
            _categoryList.Add(category);
        }
    }
}
