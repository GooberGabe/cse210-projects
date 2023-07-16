using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.IO;

namespace Final_Project
{
    class Music : Category
    {
        private List<string> _tracksPlayed;

        public Music(string dir, string name)
        {
            _fileDirectory = dir;
            _tracksPlayed = new List<string>();
            _name = name;
        }

        public override string GetName()
        {
            return "(Music) " + _name;
        }

        public override void SetTrack(AudioThread trackContainer)
        {
            base.SetTrack(trackContainer);
            _tracksPlayed.Add(trackContainer.filename);
        }

        public override string FindTrack()
        {
            // Music categories avoid repeating content.
            IEnumerable<string> files;
            try
            {
                files = Directory.EnumerateFiles(_fileDirectory);
            } catch(Exception exception)
            {
                Console.WriteLine("The file location for this category seems to be invalid. [Press Enter]");
                Console.WriteLine(exception.ToString());
                Console.ReadLine();
                return null;
            }
                
            int fileCount = files.Count();

            if (fileCount > 0)
            {
                if (_tracksPlayed.Count >= fileCount)
                {
                    _tracksPlayed.Clear(); // Empty out the list if all tracks in the file have been played already.
                }

                string result = null;
                while (result == null)
                {
                    int i = new Random().Next(0, fileCount - 1);
                    string track = files.ElementAt(i);
                    if (!_tracksPlayed.Contains(track)) // If the specified track hasn't already been played
                    {
                        result = track;
                    }
                }
                return result;
            } else
            {
                return null;
            }
                
        }


    }
}
