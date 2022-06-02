internal class ConsoleUI : IUI
{
    public void Write(string? value) => Console.WriteLine(value);
}