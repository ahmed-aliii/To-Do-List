using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;
using Task = ConsoleApp1.Models.Task;

namespace ConsoleApp1.Services
{
    interface ITaskManager
    {
        void Add(Task task);
        void Update(Task task);
        void Delete(int taskId);
        Task GetById(int taskId);
        List<Task> GetAll();
        List<Task> GetByCategory(string category);
        List<Task> GetByPriority(Priority priority);
        void DisplayTasks(List<Task> tasks);
        void DisplayUserTasks();


    }
}
