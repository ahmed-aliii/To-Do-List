using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    //Task – id, title, description, dueDate, priority, isCompleted

    // This enum represents the priority levels for tasks.
    public enum Priority
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
    //task class representing model class.
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; } 
        public bool IsCompleted { get; set; }
        public string Category { get; set; }

        public override string ToString()
            => $"[Id: {Id}, Title: {Title}, Description: {Description}, DueDate: {DueDate.ToShortDateString()}, Priority: {Priority}, IsCompleted: {IsCompleted}, Category: {Category}]";
    }
}
