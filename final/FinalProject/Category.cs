namespace DungeonMaestro {
    abstract class Category {
        protected string _fileDirectory; // Name of the folder containing tracks relevant to the category. 
        protected bool _exclusive; // Can multiple tracks within this category play at the same time? 
        private float _volume;

        public void SetVolume() {

        }

        public void GetVolume(float volume) {
            _volume = volume;
        }

        public virtual string GetTrack() {
            return null;
        }

        public void DropTrack() {
            
        }


    }
}