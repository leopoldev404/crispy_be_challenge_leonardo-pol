using System.Data;
using Dapper;
using Npgsql;
using TodoService.Biz.Abastractions;
using TodoService.Biz.Models;

namespace TodoService.Infrastructure;

public class PostgresTodoRepository(IDbConnection connection) : ITodoRepository
{
    public async ValueTask InitDbAsync()
    {
        string createTodoTableSql = """
            CREATE TABLE IF NOT EXISTS todos (
                id VARCHAR(255) PRIMARY KEY,
                text VARCHAR(255) NOT NULL,
                completed BOOLEAN NOT NULL,
                created TIMESTAMP WITH TIME ZONE NOT NULL,
                updated TIMESTAMP WITH TIME ZONE NOT NULL
            )
        """;

        await connection.ExecuteAsync(createTodoTableSql);
    }

    public async ValueTask<List<TodoItem>> GetAsync()
    {
        string getTodosSql = """
            SELECT
                id as Id,
                text as Text,
                completed as Completed,
                created as CreatedAt,
                updated as UpdatedAt
             FROM todos
        """;

        var todos = await connection.QueryAsync<TodoItem>(getTodosSql);
        return todos is not null ? todos.ToList() : [];
    }

    public async ValueTask AddAsync(TodoItem todoItem)
    {
        string insertTodoSql = """
            INSERT INTO todos(id, text, completed, created, updated)
            VALUES(@Id, @Text, @Completed, @CreatedAt, @UpdatedAt)
        """;

        await connection.ExecuteAsync(insertTodoSql, todoItem);
    }

    public async ValueTask<int> UpdateAsync(TodoItem todoItem)
    {
        string updateTodoItemSql = """
            UPDATE todos
            SET
                completed = @Completed,
                text = @Text,
                updated = @UpdatedAt
            WHERE id = @Id
        """;

        return await connection.ExecuteAsync(updateTodoItemSql, todoItem);
    }

    public async ValueTask<int> DeleteAsync(string id)
    {
        string deleteTodoSql = "DELETE FROM todos WHERE id = @id";
        return await connection.ExecuteAsync(deleteTodoSql, new { id });
    }

}