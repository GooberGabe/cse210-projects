using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.IO;


namespace Final_Project
{
    abstract class Category
    {
        protected string _fileDirectory; // Name of the folder containing tracks relevant to the category. 
        protected string _name;

        protected AudioThread audioThread = null;

        public abstract string GetName();

        public void SetName(string name)
        {
            _name = name;
        }

        public void SetVolume(double volume)
        {
            if (audioThread != null) audioThread.media.Volume = volume;
        }

        public double GetVolume()
        {
            if (audioThread != null) return audioThread.media.Volume;
            else return 0;
        }

        public bool IsPlaying()
        {
            return audioThread != null;
        }

        public AudioThread GetAudioThread()
        {
            return audioThread;
        }

        public abstract string FindTrack();

        public void DropTrack()
        {
            audioThread.media.Stop();
            audioThread = null;
        }

        public virtual void SetTrack(AudioThread trackContainer)
        {
            audioThread = trackContainer;
        }

        public void Play()
        {
            string trackPath = FindTrack();

            if (trackPath != null)
            {
                MediaPlayer media = new MediaPlayer();
                trackPath = Path.GetFullPath(trackPath);
                media.Open(new Uri(trackPath));
                media.Play();

                AudioThread trackContainer = new AudioThread(media, trackPath);

                SetTrack(trackContainer);
            } else
            {
                Console.WriteLine("Could not find a track to play. Is the destination folder empty? (Press Enter)");
                Console.ReadLine();
            }

        }

        public string ShowStatus()
        {
            return $"{(IsPlaying() ? (new DirectoryInfo(GetAudioThread().filename).Name + ", " + GetVolume() + " Volume") : "Not Playing")}";
        }

        public void Interact()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"Interact with {_name} -- {ShowStatus()}");
                Console.WriteLine($"Store .wav or .mp3 files at: {_fileDirectory}");
                Console.WriteLine();
                Console.WriteLine("[0] Toggle on/off");
                Console.WriteLine("[1] Adjust volume");
                Console.WriteLine("[2] Back");
                string choose = Console.ReadLine();
                switch (choose)
                {
                    case "0":
                        if (IsPlaying())
                        {
                            DropTrack();
                        } 
                        else
                        {
                            Play();
                        }
                        break;
                    case "1":
                        Console.WriteLine("Set volume (0 - 1): ");
                        SetVolume(double.Parse(Console.ReadLine()));
                        break;
                    default:
                        exit = true;
                        break;
                }
            }
        }

        public string Serialize()
        {
            return $"Name#{_name}+Location#{_fileDirectory}+Type#{this.GetType().ToString()}";
        }


    }

    class AudioThread
    {
        // Associates the MediaPlayer object with its corresponding filename

        public MediaPlayer media;
        public string filename;

        public AudioThread(MediaPlayer _media, string _filename)
        {
            media = _media;
            filename = _filename;
        }
    }
}


