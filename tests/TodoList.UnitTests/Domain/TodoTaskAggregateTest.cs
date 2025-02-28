

namespace TodoList.UnitTests.Domain
{
    public class TodoTaskAggregateTest
    {
        [Fact]
        public void Create_todoTask_item_success()
        {
            //Arrange
            string title = "抢5080显卡";
            string taskContent = "urlXXX;点击抢购；时间2025-02-28 10：00：00；提前十五分钟提醒";
            DateTime SubTime = new DateTime(2025, 3, 1, 10, 0, 0).AddMinutes(-15);
            Priority priority = Priority.高;
            string IdentityId = "2";
            //Act
            var fakeTodoTask = new TodoTask(IdentityId, title, taskContent, SubTime, priority);

            //Assert
            Assert.NotNull(fakeTodoTask);
        }

        [Fact]
        public void Set_task_down_success()
        {
            //Arrange
            string title = "抢5080显卡";
            string taskContent = "urlXXX;点击抢购；时间2025-02-28 10：00：00；提前十五分钟提醒";
            DateTime SubTime = new DateTime(2025, 3, 1, 10, 0, 0).AddMinutes(-15);
            Priority priority = Priority.高;
            string IdentityId = "2";
            var fakeTodoTask = new TodoTask(IdentityId, title, taskContent, SubTime, priority);

            //Act
            fakeTodoTask.TaskOverDown();

            //Assert
            Assert.Equal(fakeTodoTask.TodoTaskStatus, TodoTaskStatus.已完成);
        }


    }
}
