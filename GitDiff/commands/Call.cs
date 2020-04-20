using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GitDiff.Classes
{
    class Call : Commands
    {
        public void CallCommand(string command)
        {

            string[] splitCommand = command.Split(" ");
            string usedCommand = splitCommand[0];
            //checks the command used
            switch (usedCommand)
            {
                case "diff":
                    //checks the command has the correct number of parameters and that the files exist
                    if (splitCommand.Length == 3 && File.Exists($"Assets/{splitCommand[1]}") && File.Exists($"Assets/{splitCommand[2]}"))
                    {
                        diff($"Assets/{splitCommand[1]}", $"Assets/{splitCommand[2]}");
                    }
                    else
                    {
                        Console.WriteLine("Error: File entry invalid, check file names and try again.");
                    }
                    break;
                case "help":
                    Console.WriteLine("diff: Checks the difference between two files, include the file extension.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("diff <fileA> <fileB>");
                    Console.ResetColor();
                    break;
                case "dir":
                    break;
                default:
                    Console.WriteLine("Error: Command is not valid, type 'help' for a list of valid commands");
                    break;
            }
        }
    }
}
