using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace InventoryProjects.Common
{
    public class FileHandler
    {
        //Load products at startup
        //Save after additions, edits and deletions
        //Handle a missing file and invalid file contents
        private readonly string _fullFilePath;
        public FileHandler(string filePath, string fileName)
        {
            _fullFilePath = Path.Combine(filePath, fileName);
        }

        public void EnsureFileExists()
        {
            Console.WriteLine("asd");
            string? directory = Path.GetDirectoryName(_fullFilePath);
            Console.WriteLine(_fullFilePath);
            Console.WriteLine(directory);
            if (!string.IsNullOrEmpty(directory))
            { 
                if (!File.Exists(_fullFilePath)==false)
                {
                    File.WriteAllText(_fullFilePath, "[]");
                    Console.WriteLine("Ili tuk");
                    Console.ReadLine();
                }
            }
            
        }
        
        public string ReadAllText()
        {
            EnsureFileExists();
            return File.ReadAllText(_fullFilePath);
        }
        public void WriteAllText(string content)
        {
            EnsureFileExists();
            File.WriteAllText(_fullFilePath, content);
        }
    }
}
