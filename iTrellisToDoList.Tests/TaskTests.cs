using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iTrellisToDoList;

namespace iTrellisToDoList.Tests
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void Can_Set_Title_Property()
        {
            Task testTask = LoadSampleTask();
            testTask.Title = "Write money making novel";
            Assert.AreEqual("Write money making novel", testTask.Title);
        }

        [TestMethod]
        public void Can_Set_Description_Property()
        {
            Task testTask = LoadSampleTask();
            testTask.Description = "Vampires are IN";
            Assert.AreEqual("Vampires are IN", testTask.Description);
        }

        [TestMethod]
        public void Can_Set_DueDate_Property()
        {
            Task testTask = LoadSampleTask();
            testTask.DueDate = DateTime.Today.AddMonths(2);
            Assert.AreEqual(DateTime.Today.AddMonths(2), testTask.DueDate);
        }

        [TestMethod]
        public void Can_Set_IsCompleted_Property()
        {
            Task testTask = LoadSampleTask();
            testTask.IsCompleted = true;
            Assert.AreEqual(true, testTask.IsCompleted);
        }

        [TestMethod]
        public void IsCompleted_Defaults_To_False()
        {
            Task testTask = LoadSampleTask();
            Assert.AreEqual(false, testTask.IsCompleted);
        }

        [TestMethod]
        public void ID_Is_Unique_Across_Tasks()
        {
            Task task1 = LoadSampleTask();
            Task task2 = LoadSampleTask();
            Assert.AreNotEqual(task1.ID, task2.ID);
        }

        [TestMethod]
        public void Title_Cannot_Be_An_Empty_String()
        {
            try
            {
                Task testTask = new Task("", "Task without a title");
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }

        [TestMethod]
        public void Title_Cannot_Be_Over_50_Characters()
        {
            try
            {
                Task testTask = new Task("This is a title and it is very long titles should be shorter", "Details are better off here");
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }

        public Task LoadSampleTask()
        {
            Task sampleTask = new Task("Write novel", "Vampires are popular", new DateTime(2020, 01, 01));
            return sampleTask;
        }
    }
}
