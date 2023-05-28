using System;

namespace Develop02
{
    class Word {
        private string text;
        private bool isHidden;

        public void Hide() {
            isHidden = true;
        }

        public void Unhide() {
            isHidden = false;
        }

        public bool IsHidden() {
            return isHidden;
        }

        public string GetWord() {
            if (isHidden) {
                return "__";
            } else {
                return text;
            }
        }

        public override string ToString() {
            return GetWord();
        }

        public Word(string _text) {
            text = _text;
        }
    }
}