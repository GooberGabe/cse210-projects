namespace Develop04 {
    class Activity {
        protected string _description;
        protected string _activityName;
        protected int _duration;

        protected List<string> _prompts;

        protected void LoadingTimer(int duration) {
            DateTime startTime = DateTime.Now;
            DateTime stopTime = startTime.AddSeconds(duration);
            int i = 0;
            while (DateTime.Now < stopTime) {
                i++;
                if (i > 2) i = 0;
                Console.Write(new string[] {"|", "/", "-"} [i] );
                Thread.Sleep(100);
                Console.Write("\b");
            }
        }

        protected void CountdownTimer(int i) {
            while (i > 0) {
                i--;
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b");
            }
        }

        protected void ActivityIntro() {
            Console.WriteLine($"Welcome to the {_activityName}.");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("How long, in seconds, would you like for your session? ");
            _duration = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Get ready... ");
            LoadingTimer(3);
            Console.WriteLine();
        }

        protected void ActivityOutro() {
            Console.WriteLine();
            Console.WriteLine($"You have completed another {_duration} seconds of the {_activityName}.");
            LoadingTimer(3);
        }

        protected string GetRandomPrompt(List<string> prompts) {

            return GetRandomPrompt(prompts, new List<string>()); // Call GetRandomPrompt with an empty list of exclusions
        }

        protected string GetRandomPrompt(List<string> prompts, List<string> exclusions) {
            string x = "";
            var random = new Random();
            while (x == "" || (exclusions.Contains(x) && exclusions.Count < prompts.Count)) {
                x = prompts[random.Next(0, prompts.Count-1)];
            }
            return x;

        }

    }
}