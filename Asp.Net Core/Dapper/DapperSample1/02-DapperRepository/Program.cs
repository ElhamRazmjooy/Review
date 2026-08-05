using _02_DapperRepository.Models;
using _02_DapperRepository.Repositories;

var connectionString = "Data Source=.;Initial Catalog=DapperDB;Integrated Security=True;Trust Server Certificate=True";
var repository = new UserRepository(connectionString);

//Add
repository.Add(new User
{
    Name = "Ali",
    Age = 25
});
repository.Add(new User
{
    Name = "Sara",
    Age = 30
});
repository.Add(new User
{
    Name = "Reza",
    Age = 18
});

//Get All
var users = repository.GetAll();
foreach (var u in users)
{
    Console.WriteLine($"{u.Id} - {u.Name} - {u.Age}");
}

//Get By Id
var user2 = repository.GetById(2);
if (user2 != null)
    Console.WriteLine($"{user2.Id} - {user2.Name} - {user2.Age}");

//Update
repository.Update(new User { Id = 2, Name = "Sara Ahmadi", Age = 31 });

//Delete
repository.Delete(3);

Console.ReadLine();
