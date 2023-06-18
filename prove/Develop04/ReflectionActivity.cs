namespace Develop04 {
    class ReflectionActivity : Activity {
        private List<string> _reflectionEntries;

        public ReflectionActivity(string activityName, string description, List<string> prompts, List<string> reflections) {
            _activityName = activityName;
            _description = description;
            _prompts = prompts;
            _reflectionEntries = reflections;

        }

        public void DoActivity () {
            base.ActivityIntro();
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine();
            Console.WriteLine($"--- {GetRandomPrompt(_prompts)} ---");
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.WriteLine();
            Console.WriteLine("Now, ponder on each of the following questions as they relate to your experience.");
            Console.WriteLine("You may begin in ");
            CountdownTimer(5);
            Console.Clear();
            List<string> previousReflections = new List<string>();

            DateTime startTime = DateTime.Now;
            DateTime stopTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < stopTime) {
                string prompt = GetRandomPrompt(_reflectionEntries, previousReflections);
                previousReflections.Add(prompt);
                Console.WriteLine($"> {prompt} ");
                LoadingTimer(5);
            }
            base.ActivityOutro();
        }

    }
}