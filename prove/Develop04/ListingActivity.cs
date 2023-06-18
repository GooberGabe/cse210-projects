namespace Develop04 {
    class ListingActivity : Activity {
        private List<string> _userEntries;

        public ListingActivity(string activityName, string description, List<string> prompts) {
            _activityName = activityName;
            _description = description;
            _prompts = prompts;
            _userEntries = new List<string>();

        }

        public void DoActivity () {
            base.ActivityIntro();
            Console.WriteLine("Write as many responses as you can to the following prompt: ");
            Console.WriteLine();
            Console.WriteLine($"--- {GetRandomPrompt(_prompts)} ---");
            Console.WriteLine();
            Console.WriteLine("You may begin in ");
            CountdownTimer(5);

            DateTime startTime = DateTime.Now;
            DateTime stopTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < stopTime) {
                Console.Write("> ");
                _userEntries.Add(Console.ReadLine());
            }

            base.ActivityOutro();
        }
    }
}