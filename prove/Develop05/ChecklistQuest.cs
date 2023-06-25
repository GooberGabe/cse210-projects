namespace Develop05 {
    class ChecklistQuest : Quest {

        private int _completionThreshold;
        private int _completionProgress;
        public override int DoQuest()
        {
            _completionProgress += 1;
            if (_completionProgress >= _completionThreshold) {
                _isComplete = true;
                return _pointValue;
            } else {
                return 0;
            }
        }

        public ChecklistQuest(string title, string description, int pointValue) {
            _title = title;
            _description = description;
            _pointValue = pointValue;
        }

        public override string Serialize()
        {
            return base.Serialize()+$"+CT:{_completionThreshold}+CP:{_completionProgress}+Type:ChecklistQuest";
        }

        public override void Deserialize(string[] attributes)
        {
            base.Deserialize(attributes);
            _completionThreshold = int.Parse(Program.ParseAttribute(attributes, 4));
            _completionProgress = int.Parse(Program.ParseAttribute(attributes, 5));
        }

        public override string DisplayQuest()
        {
            return base.DisplayQuest()+$" -- Progress: {_completionProgress}/{_completionThreshold}";
        }
    }
}