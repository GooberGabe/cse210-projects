namespace Develop04 {
    class BreathingActivity : Activity {
        public BreathingActivity(string activityName, string description) {
            _activityName = activityName;
            _description = description;

        }

        public void DoActivity() {
            base.ActivityIntro();

            DateTime startTime = DateTime.Now;
            DateTime stopTime = startTime.AddSeconds(base._duration);
            while (DateTime.Now < stopTime) {
                Console.WriteLine("");
                Console.WriteLine("Breathe in... ");
                LoadingTimer(4);
                Console.WriteLine("");
                Console.WriteLine("Breathe out... ");
                LoadingTimer(4);
            }

            base.ActivityOutro();
        }
    }
}