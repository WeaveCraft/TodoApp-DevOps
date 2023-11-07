using System;
using System.Linq;
using Xunit;
using TodoApp.Pages; // Update with your actual namespace

namespace MyTodoApp.Tests
{
    public class TodoAppTests
    {
        [Fact]
        public void AddTask_AddsTaskToList()
        {
            // Arrange
            var page = new TodoApp.Pages.Index();
            var taskDescription = "Test Task";

            // Act
            page.newTask = taskDescription;
            page.AddTask();

            // Assert
            Assert.Single(page.tasks);
            var addedTask = page.tasks.First();
            Assert.Equal(taskDescription, addedTask.Description);
            Assert.False(addedTask.IsCompleted);
        }

        [Fact]
        public void RemoveTask_RemovesTaskFromList()
        {
            // Arrange
            var page = new TodoApp.Pages.Index();
            var taskDescription = "Test Task";
            page.newTask = taskDescription;
            page.AddTask();
            var taskToRemove = page.tasks.First();

            // Act
            page.RemoveTask(taskToRemove);

            // Assert
            Assert.Empty(page.tasks);
        }
    }
}
