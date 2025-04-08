using System;
using System.Collections.Generic;

namespace ScriptureMemorization
{
    public class ScriptureLibrary
    {
        private List<Scripture> scriptures;
        private Random rand = new Random();
        public ScriptureLibrary()
        {
            scriptures = new List<Scripture>
            {
                new Scripture(new Reference("John", "3", "16"), "For God so loved the world that he gave his one and only Son that whoever believes in him shall not perish but have eternal life"),
                new Scripture(new Reference("Proverbs", "3", "5-6"), "Trust in the Lord with all your heart and lean not on your own understanding"),
                new Scripture(new Reference("Philippians", "4", "13"), "I can do all this through him who gives me strength"),
                new Scripture(new Reference("Psalm", "23", "1-3"), "The Lord is my shepherd I shall not want He makes me lie down in green pastures"),
                new Scripture(new Reference("Jeremiah", "29", "11"), "For I know the plans I have for you declares the Lord plans to prosper you and not to harm you")
            };
        }
        public Scripture GetRandomScripture()
        {
            int index = rand.Next(scriptures.Count);
            return scriptures[index];
        }
    }
}
