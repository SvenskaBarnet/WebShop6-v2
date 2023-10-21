namespace WebShop6_v2;

public class Utils
{
    public static string Promt(string message)
    {
        Console.Write(message);
        string input = Console.ReadLine() ?? string.Empty;
        return input;
    }

}