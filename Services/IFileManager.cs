using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = ConsoleApp1.Models.Task;


namespace ConsoleApp1.Services
{
    interface IFileManager
    {
        List<Task> LoadAsJson();
        void SaveAsJson();

        void DisplayJsonContent();
    }
}
