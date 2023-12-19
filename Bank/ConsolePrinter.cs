namespace Bank;

public class ConsolePrinter : IConsolePrinter
{
    public void PrintLine(string lineToPrint)
    {
        // TODO: Think about how to test this and if it is needed at all.
        Console.WriteLine(lineToPrint);
    }
}