using System.Text;

using var manager = new FileManager(@"D:\test.txt");
manager.Write("Hello!");

public class FileManager(string path) : IDisposable
{
    private readonly FileStream stream = File.OpenWrite(path);
    public void Write(string text) => stream.Write(Encoding.UTF8.GetBytes(text));
    public void Dispose()
    {
        Console.WriteLine("Disposing FileManager ...");
        stream.Dispose();
    }
}
