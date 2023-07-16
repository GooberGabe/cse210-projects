namespace DungeonMaestro {
    class Music : Category {

        public Music() {
            _exclusive = true;
        }
        private List<string> _tracksPlayed;

        public override string GetTrack()
        {
            return base.GetTrack();

        }
    }

}
