using GitDiff.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GitDiff
{
    class Commands
    {
        protected void diff(string file1, string file2)
        {
            //checks if the contents of both files are equal by reading the lines, then assigns the result as a boolean
            bool diffEqual = File.ReadLines(file1).SequenceEqual(File.ReadLines(file2));
            //outputs the correct statement based on whether or not the files are equal or not
            switch (diffEqual)
            {
                case true:
                    Console.WriteLine($"{file1} and {file2} are equal");
                    break;
                case false:
                    Console.WriteLine($"{file1} and {file2} are not equal");
                    DiffCheck difference = new DiffCheck();
                    //passes the two files to the change setter so that changes can be found
                    difference.SetChanges(file1, file2);
                    List<string> changes = difference.GetChanges();
                    foreach (var i in changes)
                    {
                        Console.Write(i + "\n");
                    }
                    break;
            }
        }
        protected void help()
        {
            //writes the information and syntax of the commands to the console
            Console.WriteLine("diff: Checks the difference between two files, include the file extension.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("diff <fileA> <fileB>");
            Console.ResetColor();
        }


    }
}
