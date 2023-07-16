using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.IO;

namespace Final_Project
{
    class Ambience : Category
    {

        public Ambience(string dir, string name)
        {
            _fileDirectory = dir;
            _name = name;
        }

        public override string GetName()
        {
            return "(Ambience) " + _name;
        }

        public override string FindTrack()
        {
            // Ambience categories don't care about repeating content.

            IEnumerable<string> files;
            try
            {
                files = Directory.EnumerateFiles(_fileDirectory);
            }
            catch (Exception exception)
            {
                Console.WriteLine("The file location for this category seems to be invalid. [Press Enter]");
                Console.WriteLine(exception.ToString());
                Console.ReadLine();
                return null;
            }

            int fileCount = files.Count();
            if (fileCount > 0)
            {
                int i = new Random().Next(0, fileCount - 1);
                return files.ElementAt(i);
            } else
            {
                return null;
            }
                
        }

    }
}
