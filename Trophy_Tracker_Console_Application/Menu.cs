using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trophy_Tracker_Console_Application
{
    internal class Menu
    {

        public PlayerProcessing PlayerProcessing { get; set; }

        public Menu()
        {
            Utility.Utility.DEV = true;
            PlayerProcessing = new PlayerProcessing();
            ShowMenu();
        }

        private void PrintMenuHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("#####################################");
            Console.WriteLine("     Trophy Tracker Application      ");
            Console.WriteLine("#####################################");
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal void ShowMenu()
        {

            PrintMenuHeader();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Main menu:");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t1. Player Profile");
            Console.WriteLine("\t2. Game Info");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t3. Exit application");

            Console.ForegroundColor = ConsoleColor.White;
            OptionChoosing();

        }

        private void OptionChoosing()
        {

            switch(Utility.Utility.InsertNumberRange("\nChoose a menu option", 1, 3))
            {
                case 1:
                    Console.Clear();
                    PlayerProcessing.ShowMenu();
                    ShowMenu();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Game Info");
                    ShowMenu();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\tThank you for using Trophy Tracker! Goodbye! o/");
                    Console.ForegroundColor = ConsoleColor.White;
                    Environment.Exit(0);
                    break;
            }

        }
    }
}
