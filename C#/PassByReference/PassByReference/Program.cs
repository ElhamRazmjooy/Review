//ref
//void Increase(ref int number) => number++;
//int x = 10;
//Increase(ref x);
//Console.WriteLine(x);

//without ref
//void Increase(int number) => number++;
//int x = 10;
//Increase(x);
//Console.WriteLine(x);

//out
//bool TryParse(string text, out int result) => int.TryParse(text, out result);
//if (int.TryParse("349", out int num))
//    Console.WriteLine(num);
//if (TryParse("Hello", out int num2))
//    Console.WriteLine(num2);

//in
//void Print(in int num) => Console.WriteLine(num);
//int number = 30;
//Print(number);

Console.ReadLine();