using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = ConsoleApp1.Models.Task;

namespace ConsoleApp1.Services
{
    public class TaskManager : ITaskManager
    {

        public User User;
        public TaskManager(User user) 
        {
            User = user;
        }

        public void Add(Task task)
        {
            task.Id = User.Tasks.Count + 1; // ID generation logic
            User.Tasks.Add(task);
        }

        public void Update(Task task)
        {
            for (int i = 0; i < User.Tasks.Count; i++)
            {
                if (User.Tasks[i].Id == task.Id)
                {
                    User.Tasks[i] = task; // Update the task
                    return; // Exit after updating the task
                }
            }   
        }
        public void Delete(int taskId)
        {
            foreach(var task in User.Tasks)
            {
                if (task.Id == taskId)
                {
                    User.Tasks.Remove(task);
                    return; // Exit after removing the task
                }
            }
        }

        public List<Task> GetAll()
        {
            return User.Tasks ;
        }

        public List<Task> GetByCategory(string category)
        {
            List<Task> categorisedTasksList = new List<Task>();
            foreach (var task in User.Tasks)
            {
                if (task.Category == category)
                {
                    categorisedTasksList.Add(task);
                }
            }
            return categorisedTasksList;
        }

        public Task GetById(int taskId)
        {
            foreach(var task in User.Tasks)
            {
                if (task.Id == taskId)
                {
                    return task; // Return the task if found
                }
            }
            return null; // Return null if not found
        }

        public List<Task> GetByPriority(Priority priority)
        {
            List<Task> priorityTasksList = new List<Task>();
            foreach (var task in User.Tasks)
            {
                if (task.Priority == priority)
                {
                    priorityTasksList.Add(task);
                }
            }
            return priorityTasksList;
        }

        public void DisplayTasks(List<Task> tasks)
        {
            foreach (var task in tasks)
            {
                Console.WriteLine(task.ToString());
            }
        }

        public void DisplayUserTasks()
        {
            foreach (var task in User.Tasks)
            {
                Console.WriteLine(task.ToString());
            }
        }
    }
}
