using System.IO;

namespace Develop05
{
    class Player {

        public int points;
        public List<Quest> goals;

        public Player() {
            goals = new List<Quest>();
        }

        public void Menu() {
            string choice = "";
            while (choice != "4") {
                Console.Clear();
                Console.WriteLine("      -- Menu --");
                Console.WriteLine($"Your current score is {points}.");
                Console.WriteLine($"Your current rank is {GetRank()}.");
                Console.WriteLine();
                Console.WriteLine("[1] Create new goal");
                Console.WriteLine("[2] Record an event");
                Console.WriteLine("[3] Show list of goals");
                Console.WriteLine("[4] Save and quit");
                choice = Console.ReadLine();

                if (choice == "1") {
                    CreateGoal();
                }
                if (choice == "2") {
                    RecordEvent();
                }
                if (choice == "3") {
                    ShowQuests();
                }
                if (choice == "4") {
                    Save();
                }
            }
        }

        public string GetRank() {
            string output = "Peasant";
            string[] ranks = new string[] {
                "Peasant", "Knight", "Lord", "Prince", "King", "Emperor", "Demigod", "Deity"
            };
            for (int i = 0; i < ranks.Length; i++) {
                if (points >= Math.Pow(10, i)) {
                    output = ranks[i];
                }
            }
            return output;
        }

        public void CreateGoal() {
            Console.Clear();
            Console.WriteLine("[1] Simple Quest");
            Console.WriteLine("[2] Checklist Quest");
            Console.WriteLine("[3] Eternal Quest");
            string choice = Console.ReadLine();
            Quest quest;
            Console.WriteLine("What is the name of this goal?");
            string name = Console.ReadLine();
            Console.WriteLine("What is the description of this goal?");
            string desc = Console.ReadLine();
            Console.WriteLine("How many points is this goal worth?");
            int points = int.Parse(Console.ReadLine());

            if (choice == "1") {
                
                quest = new SimpleQuest(name, desc, points);
                goals.Add(quest);
            }
            if (choice == "2") {
                
                quest = new ChecklistQuest(name, desc, points);
                goals.Add(quest);
            }
            if (choice == "3") {
                
                quest = new EternalQuest(name, desc, points);
                goals.Add(quest);
            }
            
        }

        public void RecordEvent() {
            Console.Clear();
            List<Quest> filteredQuests = new List<Quest>();
            int i = 0;
            goals.ForEach(q => {
                if (!q.isComplete()) {
                    Console.WriteLine($"{i}: {goals[i].GetTitle()}");
                    filteredQuests.Add(q);
                    i++;
                }
            }); 
            Console.WriteLine();
            Console.WriteLine("What quest did you do? Type x to cancel.");
            string choice = Console.ReadLine();

            if (choice != "x") {
                int pointValue = filteredQuests[int.Parse(choice)].DoQuest();
                if (pointValue > 0) {
                    Console.WriteLine($"Congratulations! You earned {pointValue} points.");
                } else {
                    Console.WriteLine("Congratulations! You made progress toward this quest.");
                }
                Break();
                points += pointValue;
            }
        }

        public void ShowQuests() {
            Console.Clear();
            goals.ForEach(q => {
                Console.WriteLine(q.DisplayQuest());
                
            });
            Break();
        }

        private void Break() {
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        private string Serialize() {
            string output = $"Points:{points}\n";
            for (int i = 0; i < goals.Count; i++) {
                output += goals[i].Serialize()+"\n";
            }
            return output;
        }

        public void Save() {
            string fileName = "player.txt";

            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.Write(Serialize());
                
            }
        }
        
    }
}