using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trophy_Tracker_Console_Application.Models;

namespace Trophy_Tracker_Console_Application
{
    internal class PlayerProcessing
    {
        public List<Player> Players { get; set; }
        public GameProcessing GameProcessing { get; set; }

        public PlayerProcessing()
        {
            Players = new List<Player>();
            GameProcessing = new GameProcessing();
            if (Utility.Utility.DEV)
            {
                LoadTestData();
            }
        }

        private void LoadTestData()
        {

            Players.Add(new() { Username = "Remba15", Region = "Croatia", RegistrationDate = DateTime.Now });
            Players.Add(new() { Username = "Sweqsq2512", Region = "UK", RegistrationDate = DateTime.Now });
            Players.Add(new() { Username = "Wfqoklas436", Region = "France", RegistrationDate = DateTime.Now });

        }

        private void PrintPlayerInfoHeader()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("#####################################");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("          Player Info Menu           ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("#####################################");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ShowMenu()
        {
            PrintPlayerInfoHeader();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t1. Show all players");
            Console.WriteLine("\t2. Insert new player");
            Console.WriteLine("\t3. Update player info");
            Console.WriteLine("\t4. Delete player");
            Console.WriteLine("\t5. Select player profile");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t6. Return to main menu");
            Console.ForegroundColor = ConsoleColor.White;
            OptionChoosing();

        }

        private void OptionChoosing()
        {
            switch (Utility.Utility.InsertNumberRange("\nChoose an option", 1, 6))
            {
                case 1:
                    Console.Clear();
                    ShowAllPlayers();
                    Utility.Utility.PressAnyKeyToReturn();
                    ShowMenu();
                    break;
                case 2:
                    Console.Clear();
                    InsertPlayer();
                    ShowMenu();
                    break;
                case 3:
                    Console.Clear();
                    UpdatePlayer();
                    ShowMenu();
                    break;
                case 4:
                    Console.Clear();
                    DeletePlayer();
                    ShowMenu();
                    break;
                case 5:
                    Console.Clear();
                    ShowAllPlayers();
                    SelectPlayer();
                    break;
                case 6:
                    Console.Clear();
                    break;
            }
        }

        private void SelectPlayer()
        {
            Player chosenPlayer = Players[Utility.Utility.InsertNumberRange("Choose your player profile", 1, Players.Count) - 1];
            Console.Clear();
            GameProcessing.ShowMenu(chosenPlayer);
            ShowMenu();
        }

        

        private void DeletePlayer()
        {
            ShowAllPlayers();
            Players.RemoveAt(Utility.Utility.InsertNumberRange("\nChoose a player for deletion", 1, Players.Count) - 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPlayer succesfully removed!");
            Console.ForegroundColor = ConsoleColor.White;
            Utility.Utility.PressAnyKeyToReturn();
        }

        private void UpdatePlayer()
        {
            ShowAllPlayers();
            int choiceCount = Players.Count + 1;
            int choice = Utility.Utility.InsertNumberRange("\nChoose a player for info update or press "
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
                var chosenPlayer = Players[choice - 1];
                chosenPlayer.Username = Utility.Utility.InsertString("Update username");
                chosenPlayer.Region = Utility.Utility.InsertString("Update region");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nPlayer successfully updated!");
                Console.ForegroundColor = ConsoleColor.White;
                Utility.Utility.PressAnyKeyToReturn();
            }
        }

        private void InsertPlayer()
        {
            PrintPlayerInfoHeader();
            Players.Add(new()
            {
                Username = Utility.Utility.InsertString("Insert username"),
                Region = Utility.Utility.InsertString("Insert region"),
                RegistrationDate = DateTime.Now
            });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nInsertion complete!");
            Console.ForegroundColor = ConsoleColor.White;
            Utility.Utility.PressAnyKeyToReturn();
        }

        private void ShowAllPlayers()
        {

            PrintPlayerInfoHeader();
            int count = 1;
            foreach (var player in Players)
            {
                Console.WriteLine("\t" + count + ". " + player.ToString());
                count++;
            }
        }

        
    }
}
