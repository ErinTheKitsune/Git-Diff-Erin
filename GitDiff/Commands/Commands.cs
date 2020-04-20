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
                    //checks the difference between the two files
                    DiffCheck difference = new DiffCheck();
                    difference.SetChanges(file1, file2);
                    List<string> changes = difference.GetChanges();
                    /*foreach (var i in changes)
                    {
                        Console.WriteLine(i);
                    }*/

                    /*FileLoader fileLoad = new FileLoader();
                    int lineCount = File.ReadAllLines(filePath1).Count()-1;
                    Console.WriteLine(lineCount);
                    for (int i = 0; i < lineCount; i++)
                    {
                        Console.WriteLine("fucking end me");
                        string[] text1 = fileLoad.LoadFile(filePath1, lineCount);
                        string[] text2 = fileLoad.LoadFile(filePath2, lineCount);
                        string[] changes = fileLoad.UpdateText(text1, text2);
                        string updatedText = string.Join(" ", changes);
                        Console.WriteLine(updatedText);
                    }*/

                    /*DiffCheck store = new DiffCheck();
                    store.setFiles(filePath1, filePath2);
                    store.setChanges();
                    string[] changes = store.getChanges();
                    foreach(var i in changes)
                    {
                        Console.WriteLine(i);
                    }*/
                    break;
            }
        }


    }
}
