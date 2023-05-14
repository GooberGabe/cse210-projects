using System;
using System.Collections.Generic;

namespace Develop02 {
    class PromptGenerator {

        public List<string> prompts = new List<string> {

            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the best conversation I had today?",
            "What did I spend the most time worrying about today?"
            
        };

        public string GetPrompt() {
            Random rnd = new Random();
            return prompts[rnd.Next(0, prompts.Count)];
        }

    }
}