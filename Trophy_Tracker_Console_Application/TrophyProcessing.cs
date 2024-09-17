using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trophy_Tracker_Console_Application.Models;

namespace Trophy_Tracker_Console_Application
{
    internal class TrophyProcessing
    {
        public List<Trophy> Trophies { get; set; }

        public TrophyProcessing()
        {
            Trophies = new List<Trophy>();
            if (Utility.Utility.DEV)
            {
                LoadTestData();
            }
        }

        private void LoadTestData()
        {

            Trophies.Add(new()
            {
                Title = "Trophy1",
                Description = "Desc1",
                TrophyType = "Gold"
            });

            Trophies.Add(new()
            {
                Title = "Trophy2",
                Description = "Desc2",
                TrophyType = "Silver"
            });

            Trophies.Add(new()
            {
                Title = "Trophy3",
                Description = "Desc3",
                TrophyType = "Bronze"
            });

        }

        public void ShowMenu(Game game)
        {
            PrintTrophyInfoHeader();
            Console.WriteLine(game.Title + " trophies:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t1. Show all trophies");
            Console.WriteLine("\t2. Add trophy");
            Console.WriteLine("\t3. Delete trophy");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t4. Return to previous menu");
            Console.ForegroundColor = ConsoleColor.White;
            OptionChoosing(game);

        }

        private void OptionChoosing(Game game)
        {

            switch (Utility.Utility.InsertNumberRange("\nChoose an option", 1, 4))
            {
                case 1:
                    Console.Clear();
                    ShowAllTrophies();
                    Utility.Utility.PressAnyKeyToReturn();
                    ShowMenu(game);
                    break;
                case 2:
                    Console.Clear();
                    AddTrophy();
                    ShowMenu(game);
                    break;
                case 3:
                    Console.Clear();
                    DeleteTrophy();
                    ShowMenu(game);
                    break;
                case 4:
                    Console.Clear();
                    break;
            }

        }

        private void ShowAllTrophies()
        {

            PrintTrophyInfoHeader();
            int count = 1;
            foreach (var trophy in Trophies)
            {
                Console.WriteLine("\t" + count + ". " + trophy.ToString());
                count++;
            }

        }

        private void AddTrophy()
        {

            PrintTrophyInfoHeader();
            Trophies.Add(new()
            {
                Title = Utility.Utility.InsertString("Insert trophy title"),
                Description = Utility.Utility.InsertString("Insert trophy description"),
                TrophyType = Utility.Utility.InsertString("Insert trophy type")
            });

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nInsertion complete!");
            Console.ForegroundColor = ConsoleColor.White;
            Utility.Utility.PressAnyKeyToReturn();

        }


        private void DeleteTrophy()
        {

            ShowAllTrophies();
            Trophies.RemoveAt(Utility.Utility.InsertNumberRange("\nInsert a number of a game you want to remove", 1, Trophies.Count) - 1);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTrophy successfully removed!");
            Console.ForegroundColor = ConsoleColor.White;
            Utility.Utility.PressAnyKeyToReturn();

        }

        private void PrintTrophyInfoHeader()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("#####################################");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("          Trophy Info Menu           ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("#####################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
}
