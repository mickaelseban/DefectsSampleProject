using Xunit;

namespace TaskManagers.Tests
{
    public class TaskManagerTests
    {
        private readonly TaskManager _taskManager;

        public TaskManagerTests()
        {
            _taskManager = new TaskManager();
        }

        [Fact]
        public void AddTask_ShouldAddTaskToList()
        {
            // Arrange
            var title = "Test Task";
            var description = "This is a test task.";
            var category = "Work";
            var priority = 1;

            // Act
            var task = _taskManager.AddTask(title, description, category, priority);

            // Assert
            Assert.NotNull(task);
            Assert.Equal(title, task.Title);
            Assert.Equal(description, task.Description);
            Assert.Equal(category, task.Category);
            Assert.Equal(priority, task.Priority);
            Assert.False(task.IsCompleted);
        }

        [Fact]
        public void RemoveTask_ShouldRemoveTaskFromList()
        {
            // Arrange
            var task = _taskManager.AddTask("Test Task", "This is a test task.", "Work", 1);

            // Act
            var result = _taskManager.RemoveTask(task.Id);

            // Assert
            Assert.True(result);
            Assert.Null(_taskManager.GetTask(task.Id));
        }

        [Fact]
        public void RemoveTask_ShouldReturnFalse_WhenTaskDoesNotExist()
        {
            // Act
            var result = _taskManager.RemoveTask(999);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetTask_ShouldReturnTask_WhenTaskExists()
        {
            // Arrange
            var task = _taskManager.AddTask("Test Task", "This is a test task.", "Work", 1);

            // Act
            var retrievedTask = _taskManager.GetTask(task.Id);

            // Assert
            Assert.NotNull(retrievedTask);
            Assert.Equal(task.Id, retrievedTask.Id);
        }

        [Fact]
        public void GetTask_ShouldReturnNull_WhenTaskDoesNotExist()
        {
            // Act
            var task = _taskManager.GetTask(999);

            // Assert
            Assert.Null(task);
        }

        [Fact]
        public void GetAllTasks_ShouldReturnAllTasks()
        {
            // Arrange
            _taskManager.AddTask("Task 1", "Description 1", "Work", 1);
            _taskManager.AddTask("Task 2", "Description 2", "Personal", 2);

            // Act
            var tasks = _taskManager.GetAllTasks();

            // Assert
            Assert.Equal(2, tasks.Count);
        }

        [Fact]
        public void GetTasksByCategory_ShouldReturnTasksInCategory()
        {
            // Arrange
            _taskManager.AddTask("Task 1", "Description 1", "Work", 1);
            _taskManager.AddTask("Task 2", "Description 2", "Personal", 2);
            _taskManager.AddTask("Task 3", "Description 3", "Work", 3);

            // Act
            var tasks = _taskManager.GetTasksByCategory("Work");

            // Assert
            Assert.Equal(2, tasks.Count);
            Assert.All(tasks, t => Assert.Equal("Work", t.Category));
        }

        [Fact]
        public void GetTasksByPriority_ShouldReturnTasksWithPriority()
        {
            // Arrange
            _taskManager.AddTask("Task 1", "Description 1", "Work", 1);
            _taskManager.AddTask("Task 2", "Description 2", "Personal", 2);
            _taskManager.AddTask("Task 3", "Description 3", "Work", 1);

            // Act
            var tasks = _taskManager.GetTasksByPriority(1);

            // Assert
            Assert.Equal(2, tasks.Count);
            Assert.All(tasks, t => Assert.Equal(1, t.Priority));
        }

        [Fact]
        public void UpdateTask_ShouldUpdateTaskDetails()
        {
            // Arrange
            var task = _taskManager.AddTask("Original Task", "Original Description", "Work", 1);

            // Act
            var result = _taskManager.UpdateTask(task.Id, "Updated Task", "Updated Description", "Personal", 2);

            // Assert
            Assert.True(result);
            var updatedTask = _taskManager.GetTask(task.Id);
            Assert.Equal("Updated Task", updatedTask.Title);
            Assert.Equal("Updated Description", updatedTask.Description);
            Assert.Equal("Personal", updatedTask.Category);
            Assert.Equal(2, updatedTask.Priority);
        }

        [Fact]
        public void UpdateTask_ShouldReturnFalse_WhenTaskDoesNotExist()
        {
            // Act
            var result = _taskManager.UpdateTask(999, "Updated Task", "Updated Description", "Personal", 2);

            // Assert
            Assert.False(result);
        }
    }
}