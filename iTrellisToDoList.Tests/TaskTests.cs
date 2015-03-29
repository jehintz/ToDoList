﻿using System;
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
            Assert.AreEqual(testTask.Title, "Write novel");
        }

        [TestMethod]
        public void Can_Set_Description_Property()
        {
            Task testTask = LoadSampleTask();
            Assert.AreEqual(testTask.Description, "Vampires are popular");
        }

        [TestMethod]
        public void Can_Set_DueDate_Property()
        {
            Task testTask = LoadSampleTask();
            Assert.AreEqual(testTask.DueDate, new DateTime(2020, 01, 01));
        }

        [TestMethod]
        public void Can_Set_IsCompleted_Property()
        {
            Task testTask = LoadSampleTask();
            testTask.IsCompleted = true;
            Assert.AreEqual(testTask.IsCompleted, true);
        }

        [TestMethod]
        public void IsCompleted_Defaults_To_False()
        {
            Task testTask = LoadSampleTask();
            Assert.AreEqual(testTask.IsCompleted, false);
        }

        public Task LoadSampleTask()
        {
            Task sampleTask = new Task("Write novel", "Vampires are popular", new DateTime(2020, 01, 01));
            return sampleTask;
        }
    }
}
