namespace Develop05 {
    abstract class Quest {
        protected int _pointValue;
        protected string _title;
        protected string _description;

        protected bool _isComplete;

        public abstract int DoQuest();

        public virtual string Serialize() {
            return $"Title:{GetTitle()}+Desc:{GetDescription()}+Points:{_pointValue}+IsComp:{_isComplete}";
        }

        public virtual void Deserialize(string[] attributes) {
            _isComplete = bool.Parse(Program.ParseAttribute(attributes, 3));
        }

        public virtual string DisplayQuest() {
            return $"[{(_isComplete ? "X" : " ")}] {_title}: {_pointValue} pts";
        }

        public string GetTitle() {
            return _title;
        }

        public string GetDescription() {
            return _description;
        }   

        public bool isComplete() {
            return _isComplete;
        }

    }
}