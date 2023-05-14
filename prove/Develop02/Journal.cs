using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Develop02 {    

    /// <summary>
    /// Holds entries.
    /// </summary>
    public class Journal 
    {
        public List<Entry> entries;

        public Journal() {
            entries = new List<Entry>();
        }

        public List<Entry> GetEntries() 
        {
            return entries;
        }

        public void StoreEntry(Entry entry) 
        {
            if (!entries.Contains(entry)) {
                entries.Add(entry);
            }
        }

        public void Display() {
            List<Entry> entries = GetEntries();

            foreach (Entry entry in entries) {
                entry.Display();
                Console.WriteLine();
            }
        }

        public void Menu() {
            PromptGenerator promptGen = new PromptGenerator();
            
            string input = "";
            while (input != "5") {
                Console.WriteLine("-- Journal --");
                Console.WriteLine("[1] Write [2] Display [3] Save [4] Load [5] Quit");
                input = Console.ReadLine();
                if (input == "1") {
                    Write(promptGen);
                }
                if (input == "2") {
                    Display();
                }
                if (input == "3") {
                    Save();
                }

            }
        }

        string GetDate() {
            DateTime theCurrentTime = DateTime.Now;
            return theCurrentTime.ToShortDateString();
        }

        void Write(PromptGenerator promptGen) {
            string prompt = promptGen.GetPrompt();
            Console.WriteLine(prompt);
            Console.WriteLine();
            Console.Write("> ");
            string response = Console.ReadLine();
            
            Entry entry = new Entry();
            entry.StoreResponse(response);
            entry.StoreDate(GetDate());
            entry.StorePrompt(prompt);

            StoreEntry(entry);
        }

        void Save() {

            string json = JsonSerializer.Serialize(entries);
            File.WriteAllText("entries.json", json);
            Console.WriteLine("Saved journal entries!");
        }

        void Load() {
            string text = File.ReadAllText("entries.json");
            entries = JsonSerializer.Deserialize<List<Entry>>(text);
            Console.WriteLine("Loaded journal entries!");
        }
        
    }
}