using System;

namespace MindfulnessApp
{
    class Program
    {
        
        static int breathingCount = 0;
        static int reflectingCount = 0;
        static int listingCount = 0;
        static int gratitudeCount = 0;

        static void Main(string[] args)
        {
            bool exitApp = false;
            while (!exitApp)
            {
                Console.Clear();
                Console.WriteLine();
                Console.Write("********** Menu Options **********");
                Console.WriteLine();
                Console.WriteLine("Please choose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflecting Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Gratitude Activity");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                Console.Write("Select an option from the menu: ");
                string choice = Console.ReadLine();

                Activity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        breathingCount++;
                        break;
                    case "2":
                        activity = new ReflectingActivity();
                        reflectingCount++;
                        break;
                    case "3":
                        activity = new ListingActivity();
                        listingCount++;
                        break;
                    case "4":
                        activity = new GratitudeActivity();
                        gratitudeCount++;
                        break;
                    case "5":
                        exitApp = true;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Press Enter to try again.");
                        Console.ReadLine();
                        continue;
                }

                if (activity != null)
                {
                    activity.Run();
                  
                }
            }

            
            Console.Clear();
            Console.WriteLine("Thank you for using the Mindfulness Program!");
            Console.WriteLine("Activity Summary:");
            Console.WriteLine($"Breathing Activity performed: {breathingCount} time(s).");
            Console.WriteLine($"Reflecting Activity performed: {reflectingCount} time(s).");
            Console.WriteLine($"Listing Activity performed: {listingCount} time(s).");
            Console.WriteLine($"Gratitude Activity performed: {gratitudeCount} time(s).");
            Console.WriteLine();
            Console.WriteLine("Well Done!");
        }
    }
}
