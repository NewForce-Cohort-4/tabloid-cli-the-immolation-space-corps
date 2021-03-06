using System;

namespace TabloidCLI.UserInterfaceManagers
{
    public class MainMenuManager : IUserInterfaceManager
    {


    private const string CONNECTION_STRING = 
            @"Data Source=localhost\SQLEXPRESS;Database=TabloidCLI;Integrated Security=True";

        public IUserInterfaceManager Execute()
        {

												/// <summary>
												///     Ticket Application Background Color #19
												///         Sample code to change console background/foreground color:
												///         
												///									var SampleBG = ConsoleColor.Black;
												///									var SampleFG = ConsoleColor.White;
												///									Console.BackgroundColor = SampleBG;
												///									Console.ForegroundColor = SampleFG;
												///									Console.Clear();
												///									
												///					- Added Option [7] for Settings sub-menu.
												/// </summary>


												Console.WriteLine("");
            Console.WriteLine("------- Tabloid - Content Management Platform -------");
            Console.WriteLine("");
            Console.WriteLine(" [❓] Choose an option from the main menu to get started.");
            Console.WriteLine("");

            Console.WriteLine("Main Menu");

            Console.WriteLine(" 1) Journal Management");
            Console.WriteLine(" 2) Blog Management");
            Console.WriteLine(" 3) Author Management");
            Console.WriteLine(" 4) Post Management");
            Console.WriteLine(" 5) Tag Management");
            Console.WriteLine(" 6) Search by Tag");
												Console.WriteLine(" 7) Modify Settings");
            Console.WriteLine(" 0) Exit");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": return new JournalManager(this, CONNECTION_STRING);
                case "2": return new BlogManager(this, CONNECTION_STRING);
                case "3": return new AuthorManager(this, CONNECTION_STRING);
                case "4": return new PostManager(this, CONNECTION_STRING);
                case "5": return new TagManager(this, CONNECTION_STRING);
                case "6": return new SearchManager(this, CONNECTION_STRING);
																case "7": return new SettingsManager(this);
                case "0":
                    Console.WriteLine("Good bye");
                    return null;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }
    }
}
