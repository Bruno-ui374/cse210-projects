using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        promptGenerator.LoadPrompts();

        string choice = "";
        while (choice != "9")
        {
            Console.WriteLine("\nWelcome to the Journal Program!");
            promptGenerator.DisplayMenu();
            Console.Write("Select an option: ");
            choice = Console.ReadLine().Trim();

            switch (choice)
            {
                case "1":
                case "Write":
                  
                    Entry entry = new Entry();
                    string prompt = promptGenerator.GetRandomPrompt();
                    if (prompt == null)
                    {
                        Console.WriteLine("No writing prompts available.");
                    }
                    else
                    {
                        entry._promptText = prompt;
                        Console.WriteLine($"\nWriting entry for: {entry._promptText}");
                        Console.Write("Enter your response: ");
                        entry._entryText = Console.ReadLine();
                       
                        entry._date = DateTime.Now.ToString("dd/MM/yyyy");
                        journal.AddEntry(entry);
                        Console.WriteLine("Entry saved.");
                    }
                    break;

                case "2":
                case "Display":
                    journal.DisplayAll();
                    break;

                case "3":
                case "Load":
                    Console.Write("Enter the filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.Load(loadFilename);
                    break;

                case "4":
                case "Save":
                    Console.Write("Enter the filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.Save(saveFilename);
                    break;

                case "5":
                case "Search by Date":
                    journal.ViewEntriesByDate();
                    break;

                case "6":
                case "Search by Keyword":
                    journal.SearchEntriesByKeyword();
                    break;

                case "7":

                case "Edit Entry":
                    journal.EditEntry();
                    break;

                case "8":
                case "Delete Entry":
                    journal.DeleteEntry();
                    break;

                case "9":
                case "Quit":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
