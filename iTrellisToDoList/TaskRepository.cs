using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTrellisToDoList
{
    public class TaskRepository : IEnumerable<Task>
    {
        private List<Task> tasksList;

        //Constructor
        public TaskRepository()
        {
            tasksList = new List<Task>();
        }

        //Add a task with NO due date
        private void AddTask(string title, string description)
        {
            Task newTask = new Task(title, description);
            tasksList.Add(newTask);
        }

        //Add a task WITH a due date
        private void AddTask(string title, string description, DateTime dueDate)
        {
            Task newTask = new Task(title, description, dueDate);
            tasksList.Add(newTask);
        }

        //Remove a specific task from the list
        private void RemoveTask(Task taskToRemove)
        {
            if (tasksList.Count > 0)
            {
                for (int i = 0; i < tasksList.Count; i++)
                {
                    if (tasksList[i] == taskToRemove)
                    {
                        tasksList.RemoveAt(i);
                        break;
                    }
                }
            }
            throw new ArgumentException("Task not found.");
        }

        //Mark a specific task as completed
        private void CompleteTask(Task taskToComplete)
        {
            if (tasksList.Count > 0)
            {
                foreach (var t in tasksList)
                {
                    if (t == taskToComplete)
                    {
                        t.IsCompleted = true;
                        break;
                    }
                }
            }
            throw new ArgumentException("Task not found.");
        }

        //Get a list of all tasks
        private List<Task> GetTasks()
        {
            return tasksList;
        }

        //Implementation of IEnumerable<Task> interface
        public IEnumerator<Task> GetEnumerator()
        {
            return tasksList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return tasksList.GetEnumerator();
        }
    }
}