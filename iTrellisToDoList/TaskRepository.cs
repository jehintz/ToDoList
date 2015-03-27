using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTrellisToDoList
{
    public class TaskRepository : IEnumerable<Task>
    {
        private List<Task> tasksList;

        private void AddTask(string title, string description)
        {
            throw new NotImplementedException();
        }

        private void AddTask(string title, string description, DateTime dueDate)
        {
            throw new NotImplementedException();
        }

        private void RemoveTask(Task taskToRemove)
        {
            throw new NotImplementedException();
        }

        private void CompleteTask(Task taskToComplete)
        {
            throw new NotImplementedException();
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