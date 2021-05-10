using System;

namespace TabloidCLI.UserInterfaceManagers
{

				/// <summary>
				///     Ticket Application Background Color #19
				///     
				///         Created SettingsManager Class using IUserInterfaceManager interface.
				///         Settings manager receives the parentUI it's passed as parameter and
				///         prompts user to select their preferred display color using a switch case.
				///         User can select option [0] to return to previous menu and retain selected
				///         background/foreground colors.
				/// </summary>
				public class SettingsManager : IUserInterfaceManager
				{
        private readonly IUserInterfaceManager _parentUI;

								public SettingsManager(IUserInterfaceManager parentUI)
								{
												_parentUI = parentUI;
								}

								//private static object ColorPicker(ConsoleColor SampleBG, ConsoleColor SampleFG)
								//{
								//				return SampleFG & SampleBG;
								//}

								public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Settings Menu");
            Console.WriteLine();
            Console.WriteLine("Select a prompt color:");
            Console.WriteLine(" 1) Blue");
            Console.WriteLine(" 2) Green");
            Console.WriteLine(" 3) Red");
            Console.WriteLine(" 4) Black");
            Console.WriteLine(" 0) Go Back");

            Console.Write(" >> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
																				Console.BackgroundColor = ConsoleColor.Blue;
																				Console.ForegroundColor = ConsoleColor.White;
																				Console.Clear();
																				return this;
																case "2":
																				Console.BackgroundColor = ConsoleColor.DarkGreen;
																				Console.ForegroundColor = ConsoleColor.White;
																				Console.Clear();
																				return this;
																case "3":
																				Console.BackgroundColor = ConsoleColor.DarkRed;
																				Console.ForegroundColor = ConsoleColor.White;
																				Console.Clear();
																				return this;
																case "4":
																				Console.BackgroundColor = ConsoleColor.Black;
																				Console.ForegroundColor = ConsoleColor.White;
																				Console.Clear();
																				return this;
																case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return null;

            }

        }

    }
}

