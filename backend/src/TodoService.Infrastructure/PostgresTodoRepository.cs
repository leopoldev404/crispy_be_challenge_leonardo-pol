using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using TodoService.Biz.Abastractions;
using TodoService.Biz.Models;
using TodoService.Infrastructure.Settings;

namespace TodoService.Infrastructure;

public class PostgresTodoRepository(IOptions<DatabaseSettings> databaseSettings) : ITodoRepository
{
    private readonly string connectionString = databaseSettings.Value.ConnectionString
        ?? throw new ArgumentNullException("Missing ConnectionString!");

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

        using IDbConnection connection = new NpgsqlConnection(connectionString); ;
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
        using IDbConnection connection = new NpgsqlConnection(connectionString);
        var todos = await connection.QueryAsync<TodoItem>(getTodosSql);
        return todos is not null ? todos.ToList() : [];
    }

    public async ValueTask AddAsync(TodoItem todoItem)
    {
        string insertTodoSql = """
            INSERT INTO todos(id, text, completed, created, updated)
            VALUES(@Id, @Text, @Completed, @CreatedAt, @UpdatedAt)
        """;

        using IDbConnection connection = new NpgsqlConnection(connectionString);
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

        using IDbConnection connection = new NpgsqlConnection(connectionString);
        return await connection.ExecuteAsync(updateTodoItemSql, todoItem);
    }

    public async ValueTask<int> DeleteAsync(string id)
    {
        using IDbConnection connection = new NpgsqlConnection(connectionString);
        string deleteTodoSql = "DELETE FROM todos WHERE id = @id";
        return await connection.ExecuteAsync(deleteTodoSql, new { id });
    }

}