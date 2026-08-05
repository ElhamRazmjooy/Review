using _01_BasicDapper;
using Dapper;
using Microsoft.Data.SqlClient;

var connectionString ="Data Source=.;Initial Catalog=DapperDB;Integrated Security=True;Trust Server Certificate=True";
using var connection = new SqlConnection(connectionString);
connection.Open();

// Insert
var sql = @"INSERT INTO Users(Name, Age) VALUES(@Name, @Age)";
connection.Execute(sql, new { Name = "Ali", Age = 25 });
connection.Execute(sql, new { Name = "Sara", Age = 30 });
connection.Execute(sql, new { Name = "Reza", Age = 18 });


// Get All
var users = connection.Query<User>(@"SELECT * FROM Users");
foreach (var u in users)
{
    Console.WriteLine($"{u.Id} - {u.Name} - {u.Age}");
}

// GetById
var user = connection.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Id = @Id", new { Id = 2 });
if (user != null)
    Console.WriteLine($"{user.Id} - {user.Name} - {user.Age}");

// Update
var updatedRows = connection.Execute(@"UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id", 
    new {Id = 2, Name = "Sara Ahmadi",Age = 31 });

Console.WriteLine($"Updated Rows: {updatedRows}");

// Delete
var deletedRows = connection.Execute(@"DELETE FROM Users WHERE Id = @Id", new { Id = 3 });
Console.WriteLine($"Deleted Rows: {deletedRows}");

Console.ReadLine();
