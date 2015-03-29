using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTrellisToDoList
{
    public class Task
    {
        //Private fields
        private string _title;

        //Public properties
        public string Title
        {
            get { return _title; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Please enter a descriptive title for the task.");
                _title = value;
            }
        }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        //Constructor
        public Task(string title, string details, DateTime dueDate = new DateTime())
        {
            Title = title;
            Description = details;
            DueDate = dueDate;
            IsCompleted = false;
        }
    }
}