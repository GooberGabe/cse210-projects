using System;

namespace Develop05 {
    class Program
    {
        static void Main(string[] args)
        {
            Player player = ReadPlayerFile();
            player.Menu();
        }

        public static string ParseAttribute(string[] attributes, int index) {
            return attributes[index].Split(":")[1];
        }

        public static Player ReadPlayerFile() {
            string filename = "player.txt";
            Player output = new Player();

            try {
                string[] lines = System.IO.File.ReadAllLines(filename);
                for (int i = 0; i < lines.Length; i++) {
                    if (i == 0) {
                        output.points = int.Parse(lines[i].Split(":")[1]);
                    } else {
                        string[] attributes = lines[i].Split("+");
                        string type = ParseAttribute(attributes, attributes.Length - 1);
                        string title = ParseAttribute(attributes, 0);
                        string desc = ParseAttribute(attributes, 1);
                        int points = int.Parse(ParseAttribute(attributes, 2));
                        if (type == "SimpleQuest") {
                            SimpleQuest quest = new SimpleQuest(title, desc, points);
                            quest.Deserialize(attributes);
                            output.goals.Add(quest);
                        }
                        if (type == "EternalQuest") {
                            EternalQuest quest = new EternalQuest(title, desc, points);
                            quest.Deserialize(attributes);
                            output.goals.Add(quest);
                        }
                        if (type == "ChecklistQuest") {
                            ChecklistQuest quest = new ChecklistQuest(title, desc, points);
                            quest.Deserialize(attributes);
                            output.goals.Add(quest);
                        }
                    }
                }
            } catch {
                File.Create(filename);
            }
            return output;
        }
    }
}