using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSProject
{
    internal class FileReader
    {
        List<Staff> myStaff = new();
        string[] result = new string[2];
        string path = "staff.txt";
        string[] separator = { ", " };
        public List<Staff> ReadFile()
        {

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        result = sr.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        if (result[1] == "Manager")
                            myStaff.Add(new Manager(result[0]));
                        else if (result[1] == "Admin")
                        {
                            myStaff.Add(new Admin(result[0]));
                        }
                    }
                    sr.Close();
                }
            }
            else
                Console.WriteLine("Error: File does not exist");
            return myStaff;
        }
    }
}
