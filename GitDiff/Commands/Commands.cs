using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GitDiff
{
    class Commands
    {
        public void diff(string file1, string file2)
        {
            //checks if the contents of both files are equal by reading the lines, then assigns the result as a boolean
            bool diffEqual = File.ReadLines($"Assets/{file1}").SequenceEqual(File.ReadLines($"Assets/{file2}")); //checks if the contents of both files are equal by reading the lines, then assigns the result as a boolean
            //outputs the correct statement based on whether or not the files are equal or not
            switch (diffEqual)
            {
                case true:
                    Console.WriteLine($"{file1} and {file2} are equal");
                    break;
                case false:
                    Console.WriteLine($"{file1} and {file2} are not equal");
                    break;
            }
        }
    }
}
