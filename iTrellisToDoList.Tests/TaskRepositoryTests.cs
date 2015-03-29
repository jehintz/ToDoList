using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iTrellisToDoList;

namespace iTrellisToDoList.Tests
{
    [TestClass]
    public class TaskRepositoryTests
    {
        [TestMethod]
        public void AddTask_Method_Successfully_Adds_A_Task_To_The_Repository()
        {
            TaskRepository testRepo = new TaskRepository();
            Task testTask = LoadSampleTask();
            testRepo.AddTask(testTask);
            List<Task> taskList = testRepo.GetAllTasks();
            Assert.AreEqual(1, taskList.Count);
        }

        [TestMethod]
        public void RemoveTask_Method_Should_Return_False_When_Removing_Nonexistant_Task()
        {
            TaskRepository testRepo = LoadSampleRepoWithTasks();
            Task testTask = LoadSampleTask();
            Assert.IsFalse(testRepo.RemoveTask(testTask.ID));
        }

        [TestMethod]
        public void RemoveTask_Method_Should_Return_True_When_Existing_Task_Is_Successfully_Removed()
        {
            TaskRepository testRepo = new TaskRepository();
            Task testTask = LoadSampleTask();
            testRepo.AddTask(testTask);
            Assert.IsTrue(testRepo.RemoveTask(testTask.ID));
        }

        [TestMethod]
        public void RemoveTask_Method_Successfully_Removes_A_Task()
        {
            TaskRepository testRepo = new TaskRepository();
            Task testTask = LoadSampleTask();
            testRepo.AddTask(testTask);
            testRepo.RemoveTask(testTask.ID);
            List<Task> taskList = testRepo.GetAllTasks();
            Assert.AreEqual(0, taskList.Count);
        }

        [TestMethod]
        public void CompleteTask_Method_Should_Return_True_When_Task_Is_Successfully_Marked_Completed()
        {
            TaskRepository testRepo = new TaskRepository();
            Task testTask = LoadSampleTask();
            testRepo.AddTask(testTask);
            Assert.IsTrue(testRepo.CompleteTask(testTask.ID));
        }

        [TestMethod]
        public void CompleteTask_Method_Should_Return_False_When_Task_Not_Found()
        {
            TaskRepository testRepo = LoadSampleRepoWithTasks();
            Task testTask = LoadSampleTask();
            Assert.IsFalse(testRepo.CompleteTask(testTask.ID));
        }

        [TestMethod]
        public void CompleteTask_Method_Marks_Given_Tasks_IsCompleted_Property_as_True()
        {
            TaskRepository testRepo = new TaskRepository();
            Task testTask = LoadSampleTask();
            testRepo.AddTask(testTask);
            testRepo.CompleteTask(testTask.ID);
            Assert.AreEqual(true, testTask.IsCompleted);
        }

        [TestMethod]
        public void GetPendingTasks_Method_Should_Return_A_List_With_In_Progress_Tasks_Only()
        {
            TaskRepository testRepo = LoadSampleRepoWithTasks();
            List<Task> testForPending = testRepo.GetPendingTasks();
            foreach (var t in testForPending)
            {
                if (t.IsCompleted)
                    Assert.Fail();
            }
        }

        [TestMethod]
        public void GetCompletedTasks_Method_Should_Return_A_List_With_Completed_Tasks_Only()
        {
            TaskRepository testRepo = LoadSampleRepoWithTasks();
            List<Task> testForPending = testRepo.GetCompletedTasks();
            foreach (var t in testForPending)
            {
                if (!t.IsCompleted)
                    Assert.Fail();
            }
        }

        private TaskRepository LoadSampleRepoWithTasks()
        {
            TaskRepository repo = new TaskRepository();
            repo.AddTask(new Task("Go to the grocery store", "Buy milk, eggs, and French bread.", DateTime.Today.AddDays(2)));
            repo.AddTask(new Task("Attend sister's wedding", "In Hawaii. Must wear black.", new DateTime(2015, 10, 31)));
            repo.AddTask(new Task("Learn guitar", "Especially Wonderwall - popular at parties!"));
            Task completedTask = new Task("Walk dog", "Happy dog is happy person", DateTime.Today);
            completedTask.IsCompleted = true;
            return repo;
        }

        private Task LoadSampleTask()
        {
            Task testTask = new Task("Do Laundry", "Clean clothes smell nice", DateTime.Now.AddDays(1));
            return testTask;
        }
    }
}
