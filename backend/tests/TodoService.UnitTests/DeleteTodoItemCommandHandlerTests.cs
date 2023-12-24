using FluentAssertions;
using Moq;
using TodoService.Biz.Abastractions;
using TodoService.Biz.Commands;
using TodoService.Biz.Models;
using Xunit;

namespace TodoService.UnitTests;

public class DeleteTodoItemCommandHandlerTests
{
    [Fact]
    public async Task GivenRequestWithValidIdShouldCallRepositoryAndReturnTrue()
    {
        string id = "id";
        var mockRepository = new Mock<ITodoRepository>();

        mockRepository.Setup(repository =>
            repository.DeleteAsync(id))
            .ReturnsAsync(1);

        var handler = new DeleteTodoItemCommandHandler(mockRepository.Object);

        bool succeeded = await handler.Handle(
            new DeleteTodoItemCommand(id), new CancellationToken());

        succeeded.Should().Be(true);

        mockRepository.Verify(repository =>
            repository.DeleteAsync(id), Times.Once);

        mockRepository.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task GivenRequestWithNotPresentIdShouldCallRepositoryAndReturnFalse()
    {
        string id = "id";

        var mockRepository = new Mock<ITodoRepository>();

        mockRepository.Setup(repository =>
            repository.DeleteAsync(id))
            .ReturnsAsync(0);

        var handler = new DeleteTodoItemCommandHandler(mockRepository.Object);

        bool succeeded = await handler.Handle(
            new DeleteTodoItemCommand(id), new CancellationToken());

        succeeded.Should().Be(false);

        mockRepository.Verify(repository =>
            repository.DeleteAsync(id), Times.Once);

        mockRepository.VerifyNoOtherCalls();
    }
}