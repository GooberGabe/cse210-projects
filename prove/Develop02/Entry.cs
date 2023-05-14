using System;

namespace Develop02 {    
    public class Entry {
        
        public string response {get; set;}
        public string prompt {get; set;}
        public string date {get; set;}

        public string GetPrompt() {
            return prompt;
        }

        public string GetResponse() {
            return response;
        }

        public string GetDate() {
            return date;
        }

        public void StorePrompt(string prompt) {
            this.prompt = prompt;
        }

        public void StoreResponse(string response) {
            this.response = response;
        }

        public void StoreDate(string date) {
            this.date = date;
        }

        public void Display() {
            string message = $"{GetDate()}\n{GetPrompt()}\n{GetResponse()}\n";
            Console.WriteLine(message);
        }
    }
}