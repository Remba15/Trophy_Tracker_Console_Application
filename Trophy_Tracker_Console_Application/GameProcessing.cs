using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trophy_Tracker_Console_Application.Models;

namespace Trophy_Tracker_Console_Application
{
    internal class GameProcessing
    {

        public List<Game> Games { get; set; }

        public GameProcessing()
        {
            Games = new List<Game>();
            if (Utility.Utility.DEV)
            {
                LoadTestData();
            }
        }

        private void LoadTestData()
        {

            Games.Add(new()
            {
                Title = "Resident evil",
                Developer = "Capcom",
                Description = "Survive zombie outbreak.",
                Platforms = new List<string> { "Playstation 1", "PC", "Gamecube" }
            });

            Games.Add(new()
            {
                Title = "Jak and Daxter: The Precursor Legacy",
                Developer = "Naughty Dog",
                Description = "Save your village",
                Platforms = new List<string> { "Playstation 2", "Playstation 3", "Playstation 4", "Playstation 5" }
            });

            Games.Add(new()
            {
                Title = "Counter-strike 2",
                Developer = "Valve",
                Description = "PVP Multiplayer",
                Platforms = new List<string> { "Steam" }
            });

        }

        public void ShowMenu(Player player)
        {
            PrintGameInfoHeader();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nHello " + player.Username + "!");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\t1. Show games");
            Console.WriteLine("\t2. Add game");
            Console.WriteLine("\t3. Update game");
            Console.WriteLine("\t4. Delete game");
            Console.WriteLine("\t5. Show game trophy list");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t6. Return to previous menu");
            Console.ForegroundColor = ConsoleColor.White;
            OptionChoosing(player);
        }

        private void OptionChoosing(Player player)
        {

            switch (Utility.Utility.InsertNumberRange("\nChoose an option", 1, 6))
            {
                case 1:
                    Console.Clear();
                    ShowAllGames();
                    Utility.Utility.PressAnyKeyToReturn();
                    ShowMenu(player);
                    break;
                case 2:
                    Console.Clear();
                    AddGame();
                    ShowMenu(player);
                    break;
                case 3:
                    Console.Clear();
                    UpdateGame();
                    ShowMenu(player);
                    break;
                case 4:
                    Console.Clear();
                    DeleteGame();
                    ShowMenu(player);
                    break;
                case 5:
                    Console.Clear();
                    
                    break;
                case 6:
                    Console.Clear();
                    break;
            }

        }

        private void ShowAllGames()
        {
            PrintGameInfoHeader();
            int count = 1;
            foreach (var game in Games)
            {
                Console.WriteLine("\t" + count + ". " + game.ToString());
                count++;
            }
        }

        private void AddGame()
        {

            PrintGameInfoHeader();
            Games.Add(new()
            {
                Title = Utility.Utility.InsertString("Insert game title"),
                Developer = Utility.Utility.InsertString("Insert game developer"),
                Description = Utility.Utility.InsertString("Insert game description"),
                Platforms = new List<string>() { Utility.Utility.InsertString("Insert game platform") }
            });

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nInsertion complete!");
            Console.ForegroundColor = ConsoleColor.White;
            Utility.Utility.PressAnyKeyToReturn();
        }

        private void UpdateGame()
        {

            ShowAllGames();
            int choiceCount = Games.Count + 1;
            int choice = Utility.Utility.InsertNumberRange("\nChoose a game for info update or press "
                + choiceCount + " to cancel", 1, choiceCount);

            if (choice == choiceCount)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nUpdate canceled!");
                Console.ForegroundColor = ConsoleColor.White;
                Utility.Utility.PressAnyKeyToReturn();
            }
            else
            {
                var chosenGame = Games[choice - 1];
                chosenGame.Title = Utility.Utility.InsertString("Update title");
                chosenGame.Developer = Utility.Utility.InsertString("Update developer");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nGame successfully updated!");
                Console.ForegroundColor = ConsoleColor.White;
                Utility.Utility.PressAnyKeyToReturn();
            }
        }

        private void DeleteGame()
        {

            ShowAllGames();
            Games.RemoveAt(Utility.Utility.InsertNumberRange("\nInsert a number of a game you want to remove", 1, Games.Count) - 1);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nGame successfully removed!");
            Console.ForegroundColor = ConsoleColor.White;
            Utility.Utility.PressAnyKeyToReturn();
        }

        private void PrintGameInfoHeader()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("#####################################");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("           Game Info Menu            ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("#####################################");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
