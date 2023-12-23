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
                Id VARCHAR(255) PRIMARY KEY,
                Text VARCHAR(255) NOT NULL,
                Completed BOOLEAN NOT NULL
            )
        """;

        using IDbConnection connection = new NpgsqlConnection(connectionString); ;
        await connection.ExecuteAsync(createTodoTableSql);
    }

    public async ValueTask<List<TodoItem>> GetAsync()
    {
        string getTodosSql = "SELECT * FROM todos";
        using IDbConnection connection = new NpgsqlConnection(connectionString);
        var todos = await connection.QueryAsync<TodoItem>(getTodosSql);
        return todos is not null ? todos.ToList() : [];
    }

    public async ValueTask AddAsync(TodoItem todoItem)
    {
        string insertTodoSql = """
            INSERT INTO todos (Id, Text, Completed)
            VALUES (@Id, @Text, @Completed)
        """;

        using IDbConnection connection = new NpgsqlConnection(connectionString);
        await connection.ExecuteAsync(insertTodoSql, todoItem);
    }
    public async ValueTask<int> UpdateAsync(TodoItem todoItem)
    {
        string updateTodoItemSql = """
            UPDATE todos
            SET Completed = @Completed,
                Text = @Text
            WHERE Id = @Id
        """;

        using IDbConnection connection = new NpgsqlConnection(connectionString);
        return await connection.ExecuteAsync(updateTodoItemSql, todoItem);
    }

    public async ValueTask<int> DeleteAsync(string id)
    {
        using IDbConnection connection = new NpgsqlConnection(connectionString);
        string deleteTodoSql = "DELETE FROM todos WHERE Id = @id";
        return await connection.ExecuteAsync(deleteTodoSql, new { id });
    }

}