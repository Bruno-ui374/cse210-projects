using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorization
{
    public class Scripture
    {
        public Reference Reference { get; set; }
        public List<Word> Words { get; set; }

        public Scripture(Reference reference, string text)
        {
            Reference = reference;
            Words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        public void DisplayFullScripture()
        {
            Console.Clear();
            Console.WriteLine($"{Reference}");
            foreach (var word in Words)
            {
                Console.Write(word.Text + " ");
            }
            Console.WriteLine();
        }

        public void DisplayScripture()
        {
            Console.Clear();
            Console.WriteLine($"{Reference}");
            foreach (var word in Words)
            {
                if (word.IsHidden)
                {
                    Console.Write(new string('_', word.Text.Length) + " ");
                }
                else
                {
                    Console.Write(word.Text + " ");
                }
            }
            Console.WriteLine();
        }

        public void HideRandomWords()
        {
            var random = new Random();
            var visibleWords = Words.Where(w => !w.IsHidden).ToList();

            if (visibleWords.Count > 0)
            {
                var randomIndex = random.Next(visibleWords.Count);
                visibleWords[randomIndex].IsHidden = true;
            }
        }

        public bool AllWordsHidden()
        {
            return Words.All(w => w.IsHidden);
        }
    }
}
