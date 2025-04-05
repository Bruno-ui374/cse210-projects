using System;
using System.Collections.Generic;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private List<Scripture> _usedScriptures;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        _usedScriptures = new List<Scripture>();

        
        _scriptures.Add(new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding."));
        _scriptures.Add(new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish but have everlasting life."));
        _scriptures.Add(new Scripture(new Reference("Psalm", 23, 1, 3), "The Lord is my shepherd; I shall not want. He makes me lie down in green pastures. He leads me beside still waters."));
        _scriptures.Add(new Scripture(new Reference("Matthew", 5, 3), "Blessed are the poor in spirit, for theirs is the kingdom of heaven."));
        _scriptures.Add(new Scripture(new Reference("Romans", 8, 28), "And we know that in all things God works for the good of those who love him, who have been called according to his purpose."));
        _scriptures.Add(new Scripture(new Reference("Isaiah", 41, 10), "So do not fear, for I am with you; do not be dismayed, for I am your God. I will strengthen you and help you; I will uphold you with my righteous right hand."));
    }

    public List<Scripture> GetRandomScriptures(int count = 5)
    {
        Random rand = new Random();
        List<Scripture> selectedScriptures = new List<Scripture>();

        
        List<Scripture> unusedScriptures = new List<Scripture>(_scriptures);
        foreach (var usedScripture in _usedScriptures)
        {
            unusedScriptures.Remove(usedScripture);
        }

        
        if (unusedScriptures.Count == 0)
        {
            return selectedScriptures;
        }

        
        var shuffledScriptures = new List<Scripture>(unusedScriptures);
        for (int i = 0; i < shuffledScriptures.Count; i++)
        {
            int j = rand.Next(i, shuffledScriptures.Count);
            var temp = shuffledScriptures[i];
            shuffledScriptures[i] = shuffledScriptures[j];
            shuffledScriptures[j] = temp;
        }

     
        selectedScriptures.AddRange(shuffledScriptures.GetRange(0, Math.Min(count, shuffledScriptures.Count)));

        return selectedScriptures;
    }

 
    public void MarkAsUsed(Scripture scripture)
    {
        if (!_usedScriptures.Contains(scripture))
        {
            _usedScriptures.Add(scripture);
        }
    }

    
    public bool AllScripturesUsed()
    {
        return _usedScriptures.Count == _scriptures.Count;
    }
}
