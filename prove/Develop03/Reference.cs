using System;

namespace Develop02 {
    public class Reference {
        private string bookName;
        private int chapter;
        private string verse;

        public void Display() {
            Console.WriteLine(bookName+" "+chapter.ToString()+":"+verse.ToString());
        }

        public Reference(string _bookname, int _chapter, string _verse) {
            bookName = _bookname;
            chapter = _chapter;
            verse = _verse;
        }

    }
}