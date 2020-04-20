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
        private List<string> changes;

        public string[] GetDiffLoc()
        {
            return diffLoc;
        }
        public List<string> GetChanges()
        {
            return changes;
        }
        public void SetChanges(string file1, string file2)
        {
            SetFiles(file1, file2);
            string[] fileArray1 = GetFile1();
            string[] fileArray2 = GetFile2();
            
            List<String> remove = new List<string>();
            List<String> add = new List<string>();
            foreach (var i in fileArray1)
            {
                remove.Add(i);
            }
            foreach (var i in fileArray2)
            {
                add.Add(i);
            }
            string[] addOrRemove = new string[add.Count+remove.Count];
            int j = 0;
            while (j < fileArray1.Length || j < fileArray2.Length)
            {
                string[] addSplitter = add[j].Split();
                string[] removeSplitter = remove[j].Split();
                int helpme = 0;
                
                //Console.WriteLine(addSplitter[j], removeSplitter[j]);
                IEnumerable<string> notInTwo = removeSplitter.Except(addSplitter);
                IEnumerable<string> notInOne = addSplitter.Except(removeSplitter);
                while (helpme < notInOne.Count() || helpme < notInTwo.Count())
                {
                    if (Array.IndexOf(removeSplitter, notInOne.ElementAt(helpme)) == -1)
                    {
                        if (helpme < notInOne.Count() && helpme < notInTwo.Count())
                        {
                            Console.WriteLine(notInOne.ElementAt(helpme));
                            Console.WriteLine(notInTwo.ElementAt(helpme));
                            changes.Add(notInOne.ElementAt(helpme));
                            changes.Add(notInTwo.ElementAt(helpme));
                        }
                    }
                    helpme++;
                }
                j++;
            }
        }
    }
}
