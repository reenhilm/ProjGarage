namespace ProjGarage
{
    internal class ConsoleUI : IUI
    {
        public string? GetInput() => Console.ReadLine();
        public void Write(string? value) => Console.WriteLine(value);
    }
    //internal class MockUI : IUI
    //{
    //    public static Func<string> GetInputImplementation { private get; set; } = DefaultDummyImplementation;
    //    public static string LastOutput { get; set; } = "1";
    //    private static string DefaultDummyImplementation() => "";
    //    public string GetInput() => GetInputImplementation();
    //    public void Write(string? message) => LastOutput = message ?? string.Empty;
    //}
}