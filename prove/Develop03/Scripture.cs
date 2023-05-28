using System;

namespace Develop02 {
    class Scripture {
        private Reference reference;
        private List<Word> words;

        public Scripture(Reference _reference, string text) {
            reference = _reference;
            words = new List<Word>();
            foreach (string word in text.Split(' ')) {
                words.Add(new Word(word));
            }
        }

        public void HideWord() {
            var rnd = new Random();
            foreach (Word word in words) {
                int random = rnd.Next(words.Count-1);
                if (random == 0) {
                    word.Hide();
                    Console.WriteLine("Yeah");
                }
            }
        }

        public bool AllWordsHidden() {
            foreach (Word word in words) {
                if (!word.IsHidden()) {
                    return false;
                }
            }
            return true;
        }

        public void Display() {
            reference.Display();
            string output = "";
            foreach (Word word in words) {
                output += word.GetWord()+" ";
            }
            Console.WriteLine(output);
        }
    }
}