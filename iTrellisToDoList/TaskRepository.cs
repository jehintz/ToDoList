using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTrellisToDoList
{
    public class TaskRepository
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
            tasksList.Sort();
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
                        tasksList.Remove(taskToRemove);
                        return true;
                    }
                }
            }
            return false;
        }

        public void RemoveTask(int taskID)
        {
            foreach (var t in tasksList)
            {
                if (t.ID == taskID)
                {
                    tasksList.Remove(t);
                    break;
                }
            }
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

        public void CompleteTask(int taskID)
        {
            foreach (var t in tasksList)
            {
                if (t.ID == taskID)
                {
                    t.IsCompleted = true;
                    break;
                }
            }
        }

        //Get a list of all tasks
        public List<Task> GetAllTasks()
        {
            return tasksList;
        }

        //Get a list of only pending tasks
        public List<Task> GetPendingTasks()
        {
            List<Task> pendingTaskList = new List<Task>();
            foreach (var t in tasksList)
            {
                if (!t.IsCompleted)
                    pendingTaskList.Add(t);
            }
            return pendingTaskList;
        }

        //Get a list of only completed tasks
        public List<Task> GetCompletedTasks()
        {
            List<Task> completedTaskList = new List<Task>();
            foreach (var t in tasksList)
            {
                if (t.IsCompleted)
                    completedTaskList.Add(t);
            }
            return completedTaskList;
        }
    }
}