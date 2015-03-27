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

        //Add a task
        public void AddTask(Task taskToAdd)
        {
            tasksList.Add(taskToAdd);
        }

        //Remove a specific task from the list
        public bool RemoveTask(Task taskToRemove)
        {
            if (tasksList.Count > 0)
            {
                for (int i = 0; i < tasksList.Count; i++)
                {
                    if (tasksList[i] == taskToRemove)
                    {
                        tasksList.RemoveAt(i);
                        return true;
                    }
                }
            }
            return false;
        }

        //Mark a specific task as completed
        public bool CompleteTask(Task taskToComplete)
        {
            if (tasksList.Count > 0)
            {
                foreach (var t in tasksList)
                {
                    if (t == taskToComplete)
                    {
                        t.IsCompleted = true;
                        return true;
                    }
                }
            }
            return false;
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