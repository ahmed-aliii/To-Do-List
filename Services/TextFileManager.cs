using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Task = ConsoleApp1.Models.Task;


namespace ConsoleApp1.Services
{
    class TextFileManager : ITextFileManager
    {




        string textFilePath = "tasks.txt";

        public User user;
        public TextFileManager(User _user)
        {
            user = _user;
        }

        public void DisplayJsonContent()
        {
            string fileContent = File.ReadAllText(textFilePath);
            Console.WriteLine(fileContent);
        }

        public List<Task> LoadAsText()
        {
            // make sure the file exists
            if (!File.Exists(textFilePath))
            {
                Console.WriteLine("file not exists");
                return new List<Task>();
            }

            // Read all lines from the text file
            return user.Tasks;
        }

        public void SaveAsText()
        {
           //make sure the file exists
            if (!File.Exists(textFilePath))
            {
                Console.WriteLine("create new file");
                //create the file
                File.WriteAllLines(textFilePath ,new string[0]);
            }
            
            //Clear the text file before writing new tasks
            File.WriteAllLines(textFilePath, new string[0]);
            
            // Write each task to the text file
            foreach (var task in user.Tasks)
            {
                // Append the task to the text file
                File.AppendAllText(textFilePath, task.ToString() + "\n");
            }
        }
    }
}
