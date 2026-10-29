using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace InventoryProjects.Common
{
    public class FileHandler
    {
        private readonly string _fullFilePath;

        // Sent the desired folder and file name and combine them in a filePath. 
        public FileHandler(string filePath, string fileName)
        {
            _fullFilePath = Path.Combine(filePath, fileName);
        }

        // Create a file if it doesn't exist.
        public void EnsureFileExists()
        {
            string? directory = Path.GetDirectoryName(_fullFilePath);
            
            if (!string.IsNullOrEmpty(directory))
            {
                if (!File.Exists(_fullFilePath))
                {
                    try
                    {
                        File.WriteAllText(_fullFilePath, "[]");
                    } catch (Exception ex)
                    {
                        UI.showMessage(ex.ToString(), "error");
                    }
                }
            } else
            {
                throw new Exception("The project directory does not exist");
            }
        }
        
        // Always check if the file exists. Then open it.
        public string ReadAllText()
        {
            EnsureFileExists();
            return File.ReadAllText(_fullFilePath);
        }

        
        public void WriteAllText(string content)
        {
            EnsureFileExists();
            try
            {
                using (StreamWriter sw = new StreamWriter(_fullFilePath, true))
                {
                    sw.WriteLine(_fullFilePath, content);
                }
            }
            catch (Exception ex)
            {
                UI.showMessage(ex.ToString(), "error");
            }
        }
    }
}
