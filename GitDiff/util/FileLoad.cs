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

        protected void SetFiles(string file1, string file2)
        {
            this.textFromFile1 = File.ReadAllLines(file1);
            this.textFromFile2 = File.ReadAllLines(file2);
            //string[] extendedText;
            
            
        }
        protected string[] GetFile1()
        {
            return textFromFile1;
        }
        protected string[] GetFile2()
        {
            return textFromFile2;
        }
    }
}
