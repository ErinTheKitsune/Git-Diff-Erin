using GitDiff.Classes;
using System;
using System.IO;

namespace GitDiff
{
    class Program
    {
        static void Main(string[] args)
        {
            bool contProg = false;
            Console.WriteLine("Use \"help\" for information on the available commands");
            while (contProg == false)
            {
                //sets up the visual elements of the command line
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("$ ");
                Console.ResetColor();
                string command = Console.ReadLine();
                Call callCommand = new Call();
                //takes a command input and passes it to Call.cs to handle
                callCommand.CallCommand(command);
            }
        }
    }
}
