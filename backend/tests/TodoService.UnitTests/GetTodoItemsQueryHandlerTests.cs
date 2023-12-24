using FluentAssertions;
using Moq;
using TodoService.Biz.Abastractions;
using TodoService.Biz.Commands;
using TodoService.Biz.Queries;
using Xunit;

namespace TodoService.UnitTests;

public class GetTodoItemsQueryHandlerTests
{
    [Fact]
    public async Task GivenRequestCallRepository()
    {
        var mockRepository = new Mock<ITodoRepository>();

        mockRepository.Setup(repository =>
            repository.GetAsync())
            .ReturnsAsync([]);

        var handler = new GetTodoItemsQueryHandler(mockRepository.Object);

        var todoItems = await handler.Handle(
            new GetTodoItemsQuery(), new CancellationToken());

        todoItems.Should().BeEmpty();

        mockRepository.Verify(repository =>
            repository.GetAsync(), Times.Once);

        mockRepository.VerifyNoOtherCalls();
    }
}