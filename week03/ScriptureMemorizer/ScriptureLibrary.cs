using System;
using System.Collections.Generic;

namespace ScriptureMemorization
{
    public class ScriptureLibrary
    {
        private List<Scripture> scriptures;
        private List<Scripture> usedScriptures;

        public ScriptureLibrary()
        {
            scriptures = new List<Scripture>
            {
                new Scripture(new Reference("John", "3", "16"), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
                new Scripture(new Reference("Proverbs", "3", "5-6"), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
                new Scripture(new Reference("Philippians", "4", "13"), "I can do all this through him who gives me strength."),
                new Scripture(new Reference("Jeremiah", "29", "11"), "For I know the plans I have for you, declares the Lord, plans for welfare and not for evil, to give you a future and a hope."),
                new Scripture(new Reference("Matthew", "5", "14"), "You are the light of the world. A town built on a hill cannot be hidden.")
            };
            usedScriptures = new List<Scripture>();
        }

        public List<Scripture> GetRandomScriptures()
        {
            var randomScriptures = new List<Scripture>(scriptures);
            randomScriptures.RemoveAll(s => usedScriptures.Contains(s));

            var random = new Random();
            for (int i = randomScriptures.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = randomScriptures[i];
                randomScriptures[i] = randomScriptures[j];
                randomScriptures[j] = temp;
            }

            return randomScriptures;
        }

        public void MarkAsUsed(Scripture scripture)
        {
            usedScriptures.Add(scripture);
        }

        public bool AllScripturesUsed()
        {
            return scriptures.Count == usedScriptures.Count;
        }
    }
}
