namespace Develop05 {
    class SimpleQuest : Quest {
        public override int DoQuest()
        {
            _isComplete = true;
            return _pointValue;
        }

        public SimpleQuest(string title, string description, int pointValue) {
            _title = title;
            _description = description;
            _pointValue = pointValue;
        }

        public override string Serialize()
        {
            return base.Serialize()+"+Type:SimpleQuest";
        }

        public override void Deserialize(string[] attributes)
        {
            base.Deserialize(attributes);
        }

        public override string DisplayQuest()
        {
            return base.DisplayQuest();
        }
    }
}