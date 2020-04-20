using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GitDiff.Classes
{
    class FileLoad
    {
        private string[] textFromFile1;
        private string[] textFromFile2;

        //sets the contents of the two file arrays to the lines in the text files provided
        protected void SetFiles(string file1, string file2)
        {
            this.textFromFile1 = File.ReadAllLines(file1);
            this.textFromFile2 = File.ReadAllLines(file2);
        }

        //getters to obtain the file arrays
        protected string[] GetFile1() => textFromFile1;
        protected string[] GetFile2() => textFromFile2;
    }
}
