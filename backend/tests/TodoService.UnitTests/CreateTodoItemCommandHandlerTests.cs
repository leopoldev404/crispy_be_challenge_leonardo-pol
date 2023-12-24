using FluentAssertions;
using Moq;
using TodoService.Biz.Abastractions;
using TodoService.Biz.Commands;
using TodoService.Biz.Models;
using Xunit;

namespace TodoService.UnitTests;

public class CreateTodoItemCommandHandlerTests
{
    [Fact]
    public async Task GivenValidRequestShouldCallRepository()
    {
        string todoText = "todo";
        var mockRepository = new Mock<ITodoRepository>();

        mockRepository.Setup(repository =>
            repository.AddAsync(It.IsAny<TodoItem>()));

        var handler = new CreateTodoItemCommandHandler(mockRepository.Object);

        TodoItem todoItem = await handler.Handle(
            new CreateTodoItemCommand(todoText), new CancellationToken());

        todoItem.Text.Should().Be(todoText);
        todoItem.CreatedAt.Should().Be(todoItem.UpdatedAt);

        mockRepository.Verify(repository =>
            repository.AddAsync(It.IsAny<TodoItem>()), Times.Once);

        mockRepository.VerifyNoOtherCalls();
    }
}