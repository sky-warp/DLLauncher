/*
 This programm will launch any games which specifed in GetAppPath
function. F.e. I want to launch DOTA on my PC. I just run this programm and input 
relevant alias for this game. Input "dota" will return path for any Steam game, which contain 
game ID (steam://rungameid/<game ID>). Any other game on your machine can be launch 
by specified the absolute path for this game.

Its kinda difficult, because when you install any new game you 
must indicate it in function. Plus you need to remember every alias in programm.

Anyway, this is my first program.
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace DLLauncher
{
    class Program
    {
        //Main function which prompt user to input alias. Here also declare and initialize appPath variable
        //which stored returned result of GetAppPath function with input parameter.
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string appPath = GetAppPath(input);

            if (input == null)
            {
                Console.WriteLine("Command is unknown");
            }
            else
            {
                Console.WriteLine($"Launching path: {appPath}");
            }

            //This code launching game by using appPath parameter for LaunchApplication.
            //Noticed, that it will be executed only if returned value of appPath != null or its dosent empty.
            if (!string.IsNullOrEmpty(appPath))
            {
                LaunchApplication(appPath);
            }
        }

        //Alias code.
        //Here you can add games for launch. Dont forget to specified the path.
        static string GetAppPath(string command)
        {
            switch(command.ToLower())
            {
                case "deadlock":
                    return @"steam://rungameid/1422450";
                default:
                    return null; 
            }
        }

        static void LaunchApplication(string appPath)
        {
            Process.Start(appPath);
        }
    }
}