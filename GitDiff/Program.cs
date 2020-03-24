using System;
using System.IO;

namespace GitDiff
{
    class Program
    {
        static void Main(string[] args)
        {
            bool filesValid = false;
            string file;
            Console.WriteLine("Command: diff file1 file2 (include .txt)");
            //loops until two existing files are selected
            while(filesValid == false)
            {
                file = Console.ReadLine();
                //splits the string entered to ensure that the file names can be accessed
                string[] files = file.Split(" ");
                //checks if the two files exist so that they can be accessed
                if (File.Exists($"Assets/{files[1]}") && File.Exists($"Assets/{files[2]}"))
                {
                    //checks the difference between the two files
                    Commands commands = new Commands();
                    commands.diff(files[1], files[2]);
                    filesValid = true;
                }
                else
                {
                    Console.WriteLine("Error: Files not found, please try again");
                }

            }
        }
    }
}
