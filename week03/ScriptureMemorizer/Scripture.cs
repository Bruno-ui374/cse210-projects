using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorization
{
    public class Scripture
    {
        public Reference Reference { get; set; }
        public List<Word> Words { get; set; }
        private static Random rand = new Random();
        public Scripture(Reference reference, string text)
        {
            Reference = reference;
            Words = text.Split(' ').Select(word => new Word(word)).ToList();
        }
        public void DisplayFullScripture()
        {
            Console.Clear();
            Console.WriteLine(Reference.ToString());
            foreach (var word in Words)
                Console.Write(word.Text + " ");
            Console.WriteLine();
        }
        public void DisplayScripture()
        {
            Console.Clear();
            Console.WriteLine(Reference.ToString());
            foreach (var word in Words)
                Console.Write((word.IsHidden ? new string('_', word.Text.Length) : word.Text) + " ");
            Console.WriteLine();
        }
        public void HideRandomWord()
        {
            var visibleWords = Words.Where(w => !w.IsHidden).ToList();
            if (visibleWords.Count > 0)
            {
                int index = rand.Next(visibleWords.Count);
                visibleWords[index].IsHidden = true;
            }
        }
        public bool AllWordsHidden()
        {
            return Words.All(w => w.IsHidden);
        }
    }
}
