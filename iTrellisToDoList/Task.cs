using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTrellisToDoList
{
    public class Task : IComparable<Task>
    {
        //Private fields
        private string _title;
        private static int _id = 0;

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
        public int ID { get; private set; }

        //Constructor
        public Task(string title, string details, DateTime dueDate = new DateTime())
        {
            Title = title;
            Description = details;
            DueDate = dueDate;
            IsCompleted = false;
            ID = ++_id;
        }

        //Implementation of IComparable<Task> - sort by date
        public int CompareTo(Task other)
        {
            if (other == null)
                return 1;

            if (this.DueDate > other.DueDate)
                return 1;
            else if (this.DueDate == other.DueDate)
                return 0;
            else
                return -1;
        }
    }
}