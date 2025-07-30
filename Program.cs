using ConsoleApp1.Models;
using ConsoleApp1.Services;
using Task = ConsoleApp1.Models.Task;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //User Service
            IUserManager userManager = new UserManager();
            
            
            //Admin
            User Admin = new User()
            {
                Name = "Ahmed Ali",
                Email = "a@a.com",
                Password = "pass",
            };
            userManager.Register(Admin.Name, Admin.Password, Admin.Email);



            //Authentication
            User user = null;

            #region Authentication

            while (user == null)
            {
                Console.WriteLine("1. Register\n2. Login");
                string choice = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Password: ");
                string pass = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    user = userManager.Register(name, email, pass);
                    if (user == null)
                        Console.WriteLine("Email already exists!");
                }
                else if (choice == "2")
                {
                    user = userManager.Login(email, pass);
                    if (user == null)
                        Console.WriteLine("Invalid login.");
                }
            }

            #endregion


            #region Services
            //Services
            ITaskManager taskManager = new TaskManager(user);
            IFileManager fileManager = new FileManager(user);
            ITextFileManager textFileManager = new TextFileManager(user);

            #endregion


            #region Program
            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Add Task\n2. Edit Task\n3. Delete Task\n4. View All\n5. Filter by Category\n6. Filter by Priority\n7. View All As Json\n8. View All As Text\n9 Exit\n ");
                Console.WriteLine();
                string option = Console.ReadLine();

                //Add Task
                if (option == "1")
                {
                    Task task = new Task();
                    Console.Write("Title: ");
                    task.Title = Console.ReadLine();
                    Console.Write("Description: ");
                    task.Description = Console.ReadLine();
                    Console.Write("Due Date (yyyy-MM-dd): ");
                    task.DueDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Category: ");
                    task.Category = Console.ReadLine();
                    Console.Write("Priority (Low/Medium/High): ");
                    string value = Console.ReadLine();
                    task.Priority = (Priority)Enum.Parse(typeof(Priority), value);
                    task.IsCompleted = false;

                    taskManager.Add(task);
                }



                //Edit Task
                else if (option == "2")
                {
                    Console.Write("Enter Task ID to edit: ");
                    int taskId = int.Parse(Console.ReadLine());
                    Task taskToUpdate = taskManager.GetById(taskId);
                    if (taskToUpdate != null)
                    {
                        Console.Write("New Title: ");
                        taskToUpdate.Title = Console.ReadLine();
                        Console.Write("New Description: ");
                        taskToUpdate.Description = Console.ReadLine();
                        Console.Write("New Due Date (yyyy-MM-dd): ");
                        taskToUpdate.DueDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("New Category: ");
                        taskToUpdate.Category = Console.ReadLine();
                        Console.Write("New Priority (Low/Medium/High): ");
                        string value = Console.ReadLine();
                        taskToUpdate.Priority = (Priority)Enum.Parse(typeof(Priority), value);
                        taskManager.Update(taskToUpdate);
                    }
                    else
                    {
                        Console.WriteLine("Task not found.");
                    }
                }

                //Delete Task
                else if (option == "3")
                {
                    Console.Write("Enter Task ID to delete: ");
                    int taskId = int.Parse(Console.ReadLine());
                    taskManager.Delete(taskId);
                }

                //View All Tasks
                else if (option == "4")
                {
                    List<Task> tasks = taskManager.GetAll();
                    if (tasks.Count > 0)
                    {
                        taskManager.DisplayUserTasks();
                    }
                    else
                    {
                        Console.WriteLine("No tasks available.");
                    }
                }

                //Filter by Category
                else if (option == "5")
                {
                    Console.Write("Enter Category to filter: ");
                    string category = Console.ReadLine();
                    List<Task> filteredTasks = taskManager.GetByCategory(category);
                    if (filteredTasks.Count > 0)
                    {
                        foreach (var task in filteredTasks)
                        {
                            Console.WriteLine(task.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("No tasks found in this category.");
                    }
                }

                //Filter by Priority
                else if (option == "6")
                {
                    Console.Write("Enter Priority to filter (Low/Medium/High): ");
                    string value = Console.ReadLine();
                    List<Task> filteredTasks = taskManager.GetByCategory(value);
                    Priority priority = (Priority)Enum.Parse(typeof(Priority), value);
                    if (filteredTasks.Count > 0)
                    {
                        foreach (var task in filteredTasks)
                        {
                            Console.WriteLine(task.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("No tasks found with this priority.");
                    }
                }

                //View All As Json
                else if (option == "7")
                {
                    fileManager.SaveAsJson();
                    fileManager.DisplayJsonContent();
                }

                //View All As Text
                else if (option == "8")
                {
                    textFileManager.SaveAsText();
                    textFileManager.DisplayJsonContent();
                }

                //Exit
                else if (option == "9")
                {
                    Console.WriteLine("Good Bye <3 <3 <3...");
                    break;
                }



            }

            #endregion



        }
    }
}
