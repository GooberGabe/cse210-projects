namespace Develop05 {
    class EternalQuest : Quest {

        private int _timesCompleted;

        public override int DoQuest()
        {
            _timesCompleted += 1;
            return _pointValue * _timesCompleted;
        }

        public EternalQuest(string title, string description, int pointValue) {
            _title = title;
            _description = description;
            _pointValue = pointValue;
        }

        public override string Serialize()
        {
            return base.Serialize()+$"+TimesCompleted:{_timesCompleted}+Type:EternalQuest";
        }

        public override void Deserialize(string[] attributes)
        {
            base.Deserialize(attributes);
            _timesCompleted = int.Parse(Program.ParseAttribute(attributes, 4));
        }

        public override string DisplayQuest()
        {
            return base.DisplayQuest();
        }
    }
}