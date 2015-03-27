using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iTrellisToDoList;

namespace iTrellisToDoList.Tests
{
    [TestClass]
    public class TaskRepositoryTests
    {
        [TestMethod]
        public void RemoveTask_Method_Should_Return_False_When_Removing_Nonexistant_Task()
        {
            TaskRepository fakeRepo = new TaskRepository();
            Task testTask = new Task("Do Laundry", "Clean clothes smell nice", DateTime.Now.AddDays(1));
            Assert.IsFalse(fakeRepo.RemoveTask(testTask));
        }

        [TestMethod]
        public void RemoveTask_Method_Should_Return_True_When_Existing_Task_Is_Successfully_Removed()
        {
            TaskRepository fakeRepo = new TaskRepository();
            Task testTask = new Task("Vacuum", "Not with the Roomba", DateTime.Now.AddDays(1));
            fakeRepo.AddTask(testTask);
            Assert.IsTrue(fakeRepo.RemoveTask(testTask));
        }

        private void LoadTestRepoData (TaskRepository repo)
        {
            repo.AddTask(new Task("Go to the grocery store", "Buy milk, eggs, and French bread.", DateTime.Now.AddDays(2)));
            repo.AddTask(new Task("Attend sister's wedding", "In Hawaii. Must wear black.", new DateTime(2015, 10, 31)));
            repo.AddTask(new Task("Learn guitar", "Especially Wonderwall - popular at parties!"));
        }
    }
}
