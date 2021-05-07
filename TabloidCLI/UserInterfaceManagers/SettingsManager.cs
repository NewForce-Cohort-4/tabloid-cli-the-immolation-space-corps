using System;
using System.Collections.Generic;
using System.Text;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    class SettingsManager
    {
        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Settings Menu");
            Console.WriteLine();
            Console.WriteLine("Select a prompt color:");
            Console.WriteLine("1) Blue");
            Console.WriteLine("2) Green");
            Console.WriteLine("3) Red");
            Console.WriteLine("4) Black");

            Console.Write(">> ");

        }
    }
}
