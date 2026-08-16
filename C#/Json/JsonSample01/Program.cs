using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

//Read
var data = File.ReadAllText(@"D:\1.Json");
Console.WriteLine(data);

//Deserialize
var p = JsonConvert.DeserializeObject<Person>(data);
Console.WriteLine(p.FirstName);

dynamic d = JsonConvert.DeserializeObject(data);
Console.WriteLine(d.LastName);

//Serialize
var p1 = new Person("Sara", "Ahmadi", 32);
Console.WriteLine(JsonConvert.SerializeObject(p1));

//
dynamic d1 = JObject.Parse(data);
Console.WriteLine(d1.FirstName);
Console.WriteLine(d1.Age);

//
var users = new List<User>
{
    new User { Id = 1, Name = "Fatemeh" },
    new User { Id = 2, Name = "Hanieh" }
};
var options = new JsonSerializerOptions { WriteIndented = true };
Console.WriteLine(JsonSerializer.Serialize(users, options));

Console.Read();
