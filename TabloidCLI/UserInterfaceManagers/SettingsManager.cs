using System;
using System.Collections.Generic;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    public class SettingsManager
    {
        private IUserInterfaceManager _parentUI;

        List<Settings> scheme = new List<Settings>();

        Settings defaultColor = new Settings()
        {
            theme = "default",
            foregroundColor = "white",
            backgroundColor = "black"
        };
								
								
      

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Settings Menu");
            Console.WriteLine();
            Console.WriteLine("Select a prompt color:");
            Console.WriteLine("1) Blue");
            Console.WriteLine("2) Green");
            Console.WriteLine("3) Red");
            Console.WriteLine("4) Black");
            Console.WriteLine(" 0) Go Back");

            Console.Write(">> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    throw new NotImplementedException();
                case "2":
                    throw new NotImplementedException();
                case "3":
                    throw new NotImplementedException();
                case "4":
                    throw new NotImplementedException();
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return null;

            }
        }
    }
}

