//GetType() , typeof()
//var user = new User();
//var type = user.GetType();
//Console.WriteLine(type.Name);

//var type2 = typeof(User);
//Console.WriteLine(type2.Module);

//GetProperties()
//var type3 = typeof(User);
//var properties = type3.GetProperties();
//foreach (var property in properties)
//{
//    Console.WriteLine(property.Name);
//}

//GetValue()
//var u = new User(10, "Elham", "Elham@test.com");
//var t = typeof(User);
//var p1 = t.GetProperties();
//foreach (var p in p1)
//{
//    var value = p.GetValue(u); 
//    Console.WriteLine($"{p.Name}: {value}");
//}

//SetValue()
//var user = new User(10, "Elham", "Elham@test.com");
//var type  = user.GetType();
//var nameProp  = type.GetProperty("Name");
//nameProp?.SetValue(user, "Nazanin");
//Console.WriteLine(user.Name);

//GetMethods()
//var user = new User();
//var type = user.GetType();
//var methods = type.GetMethods();
//foreach (var method in methods)
//{
//    Console.WriteLine(method.Name);
//}

//Reflection + Method
//var cal = new Calculator();
//var method = typeof(Calculator).GetMethod("Add");
//var result = method?.Invoke(cal, new object[] {10, 20});
//Console.WriteLine(result);

//Reflection + Attribute
//var method = typeof(Test).GetMethod("OldMethod");
//var attribute = method?.GetCustomAttributes(false);
//Console.WriteLine(attribute);

//
//var type = typeof(EmailPlugin);
//if (typeof(IPlugin).IsAssignableFrom(type))
//{
//    var plugin = (IPlugin)Activator.CreateInstance(type)!;
//    plugin.Run();
//}

Console.ReadLine();