/*
 So I rebuild this programm for now, so it can only accept Steam ID of any Steam game and launch it.
 Just input any Steam game ID in CMD and you launch specified game!

 Now Im trying to implement a feature which would give access to search game by its name and automatically
 Take its ID from SteamDB web site.

 IDK how much would it take. Just dont wanna lose this prototype for Steam-only)
 */
using System;
using System.Diagnostics;

namespace DLLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //Base nvigation
                Console.Write("Navigation:\tc-Clear\t\tq-Quit\t\ts-Search\nEnter the Steam ID: ");
                string input = Console.ReadLine();

                //Some validation variables, f.e. if validationID = false which means that input is not an integer data type 
                //and obviously it cannot be numerical ID
                int validationIDNumber = 0;
                bool validationID = int.TryParse(input, out validationIDNumber);

                //Switch alias to clear and terminate CMD window
                switch (input.ToLower().Trim())
                {
                    case "q":
                        Environment.Exit(0);

                        break;

                    case "c":
                        Console.Clear();

                        break;

                    case "s":
                        Console.Write("Enter the game name: ");
                        string searchGame = Console.ReadLine();

                        string url = GenerateUrl(searchGame);
                        Console.WriteLine($"Try to search game ID on {url}\n");

                        break;

                    default:
                        input = null;

                        break;
                }

                //Getting path to launch SteamID with Steam API command 
                string appPath = GetAppPath(@"steam://rungameid/" + input);

                //Another validation steps, I want to be sure that input is not null and it is int data type 
                if (!string.IsNullOrEmpty(input) && validationID == true)
                {
                    Console.WriteLine($"Launching {input} SteamID...");

                    LaunchGame(appPath);

                    Console.Write("Press Enter to exit...");
                    Console.ReadLine();

                    break;
                }
                //Try again)
                else if (validationID == false && input != "s" && input != "c")
                {
                    Console.WriteLine("Unknown command, try again.\n");
                    continue;
                }
            }
        }

        //Method to return the input, I know that I can ommit it, but I guess that look cooler
        static string GetAppPath(string command)
        {
            return command;
        }

        //Method which launching game with SteamAPI command (can be ommited to)
        static void LaunchGame(string appPath)
        {
            Process.Start(appPath);
        }

        //Method to generate the URL
        static string GenerateUrl(string query)
        {
            //Uri class allows us to get acces to URI parts (include URL) 
            //EscapeDataString method translate our Unicode and special characters to coded-string which uses in URL
            string codedQuery = Uri.EscapeDataString(query);

            return $"https://steamdb.info/search/?a=all&q={codedQuery}";

        }
    }
}