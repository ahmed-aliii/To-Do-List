using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = ConsoleApp1.Models.Task;

namespace ConsoleApp1.Services
{
    interface ITextFileManager
    {
        List<Task> LoadAsText();
        void SaveAsText();

        void DisplayJsonContent();
    }
}
