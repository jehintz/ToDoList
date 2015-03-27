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
        private DateTime _dueDate;

        //Public properties
        public string Title
        {
            get { return _title; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentException("Please enter a descriptive title for the task.");
                _title = value;
            }
        }
        public string Description { get; set; }
        public DateTime DueDate
        {
            get { return _dueDate; }
            set
            {
                if (value < DateTime.Now)
                    throw new ArgumentException("The due date must be later than the current date.");
                _dueDate = value;
            }
        }
        public bool IsCompleted { get; set; }

        //Constructors
        public Task(string title, string details)
        {
            Title = title;
            Description = details;
            IsCompleted = false;
        }

        public Task(string title, string details, DateTime dueDate)
        {
            Title = title;
            Description = details;
            DueDate = dueDate;
            IsCompleted = false;
        }
    }
}