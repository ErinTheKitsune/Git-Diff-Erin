using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GitDiff.Classes
{
    class DiffCheck : FileLoad
    {
        private string[] diffLoc;
        private List<string> changes = new List<string> { };
        public string[] newLine;

        //getters for the difference location and the changes made
        public string[] GetDiffLoc() => diffLoc;
        public List<string> GetChanges() => changes;
        

        //setter to find the changes made between the two provided files
        public void SetChanges(string file1, string file2)
        {
            SetFiles(file1, file2);
            string[] fileArray1 = GetFile1();
            string[] fileArray2 = GetFile2();
            List<String> remove = new List<string>();
            List<String> add = new List<string>();

            //adds the values of both file arrays to a list to allow for easier use
            foreach (var item in fileArray1)
            {
                remove.Add(item);
                //Console.WriteLine(remove.First());
            }
            foreach (var item in fileArray2)
            {
                add.Add(item);
            }

            int i = 0;
            while (i < fileArray1.Length || i < fileArray2.Length)
            {
                //splits the two files into individual words
                string[] addSplitter = add[i].Split(new char[] { ',', ' ' });
                string[] removeSplitter = remove[i].Split(new char[] { ',', ' ' });
                int j = 0;
                int x = 0;
                int x2 = 0;
                //checks for members of the array that are not in the other array
                while (j < addSplitter.Length && j < removeSplitter.Length)
                {
                    int changeNum = 0;
                    if (Array.IndexOf(addSplitter, removeSplitter[j]) == -1 || Array.IndexOf(removeSplitter, addSplitter[j]) == -1)
                    {
                        /*if (addSplitter.Length == removeSplitter.Length)
                        {
                            changes.Add(addSplitter[j]);
                            changes.Add(removeSplitter[j]);
                        }*/
                        
                        //changes.Add(addSplitter[j]);
                        //Checks for additional words in order to include them in the changes
                        while (Array.IndexOf(removeSplitter, addSplitter[j + x]) == -1)
                        {
                            //Console.WriteLine(addSplitter[j + x]);
                            changes.Add(addSplitter[j + x]);
                            /*if (addSplitter.Length> removeSplitter.Length)
                            {
                                
                            }*/
                            x++;
                        }
                        
                        while (Array.IndexOf(addSplitter, removeSplitter[j + x2]) == -1)
                        {
                            //Console.WriteLine(removeSplitter[j + x2]);
                            changes.Add(removeSplitter[j + x2]);
                            /*if (removeSplitter.Length > addSplitter.Length)
                            {
                                
                            }*/
                            x2++;
                        }
                    }
                    j++;
                }
                i++;
            }
        }
    }
}
