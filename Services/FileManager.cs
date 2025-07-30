using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using Task = ConsoleApp1.Models.Task;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    class FileManager : IFileManager
    {
        public User user;
        public FileManager(User _user) 
        {
            user = _user;
        }


        string filePathAsJson = "tasks.json";


        public void SaveAsJson()
        {
            // Serialize the list of Task objects to JSON format
            string jsonContent = JsonSerializer.Serialize(user.Tasks, new JsonSerializerOptions { WriteIndented = true });

            // make sure the file exists
            if (!File.Exists(filePathAsJson))
            {
                Console.WriteLine("file not exists");
                //create the file
                File.WriteAllText(filePathAsJson, jsonContent);

            }
            else
            {
                //write the JSON content to the file
                File.WriteAllText(filePathAsJson, jsonContent);
            }
        }


        List<Task> IFileManager.LoadAsJson()
        {
            // make sure the file exists
            if (!File.Exists(filePathAsJson))
            {
                Console.WriteLine("file not exists");
                return new List<Task>();
            }

            string jsonContent = File.ReadAllText(filePathAsJson);
            // Deserialize the JSON content to a list of Task objects
            List<Task> tasks = JsonSerializer.Deserialize<List<Task>>(jsonContent);

            // Check if the deserialization was successful
            if (tasks == null)
            {
                Console.WriteLine("No tasks found in the file.");
                return new List<Task>();
            }
            return tasks;
        }

        public void DisplayJsonContent()
        {
            // Read the JSON content from the file
            if (!File.Exists(filePathAsJson))
            {
                Console.WriteLine("file not exists");
                return;
            }
            string jsonContent = File.ReadAllText(filePathAsJson);
            Console.WriteLine(jsonContent);
        }
    }
}
