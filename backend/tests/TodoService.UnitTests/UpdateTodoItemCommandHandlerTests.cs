using FluentAssertions;
using Moq;
using TodoService.Biz.Abastractions;
using TodoService.Biz.Commands;
using TodoService.Biz.Models;
using Xunit;

namespace TodoService.UnitTests;

public class UpdateTodoItemCommandHandlerTests
{
    [Fact]
    public async Task GivenRequestWithValidIdShouldCallRepositoryAndReturnTrue()
    {
        var todoItem = new TodoItem("id", "text", true, null, null);

        var mockRepository = new Mock<ITodoRepository>();

        mockRepository.Setup(repository =>
            repository.UpdateAsync(It.IsAny<TodoItem>()))
            .ReturnsAsync(1);

        var handler = new UpdateTodoItemCommandHandler(mockRepository.Object);

        bool succeeded = await handler.Handle(
            new UpdateTodoItemCommand(todoItem), new CancellationToken());

        succeeded.Should().Be(true);

        mockRepository.Verify(repository =>
            repository.UpdateAsync(It.IsAny<TodoItem>()), Times.Once);

        mockRepository.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task GivenRequestWithNotPresentIdShouldCallRepositoryAndReturnFalse()
    {
        var todoItem = new TodoItem("id", "text", true, null, null);

        var mockRepository = new Mock<ITodoRepository>();

        mockRepository.Setup(repository =>
            repository.UpdateAsync(It.IsAny<TodoItem>()))
            .ReturnsAsync(0);

        var handler = new UpdateTodoItemCommandHandler(mockRepository.Object);

        bool succeeded = await handler.Handle(
            new UpdateTodoItemCommand(todoItem), new CancellationToken());

        succeeded.Should().Be(false);

        mockRepository.Verify(repository =>
            repository.UpdateAsync(It.IsAny<TodoItem>()), Times.Once);

        mockRepository.VerifyNoOtherCalls();
    }
}