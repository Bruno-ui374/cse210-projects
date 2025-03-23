using System;
using System.Collections.Generic;

public class PromptGenerator
{
 
    public List<string> _menuPrompts = new List<string>();
    public List<string> _writingPrompts = new List<string>();

    public void LoadPrompts()
    {
      
        _menuPrompts.Add("1.Write");
        _menuPrompts.Add("2.Display");
        _menuPrompts.Add("3.Load");
        _menuPrompts.Add("4.Save");
        _menuPrompts.Add("5.Search by Date");
        _menuPrompts.Add("6.Search by Keyword");
        _menuPrompts.Add("7.Edit Entry");
        _menuPrompts.Add("8.Delete Entry");
        _menuPrompts.Add("9.Quit");

       
        _writingPrompts.Add("If I had one thing I could do over today, what would it be?");
        _writingPrompts.Add("What was the best part of my day?");
        _writingPrompts.Add("Who was the most interesting person I interacted with today?");
        _writingPrompts.Add("What was the strongest emotion I felt today?");
        _writingPrompts.Add("How did I see the hand of the Lord in my life today?");
    }

    public void DisplayMenu()
    {
        foreach (string prompt in _menuPrompts)
        {
            Console.WriteLine(prompt);
        }
    }


    public string GetMenuChoice()
    {
        Console.Write("What would you like to do?: ");
        return Console.ReadLine().Trim();
    }


    public string GetRandomPrompt()
    {
        if (_writingPrompts.Count == 0)
        {
            return null;
        }
        Random random = new Random();
        int index = random.Next(_writingPrompts.Count);
        return _writingPrompts[index];
    }
}
