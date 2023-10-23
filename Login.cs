namespace WebShop6_v2;

public class Login
{
    public static void Register()
    {
        string[] users = File.ReadAllLines("users.csv");
        Console.Clear();
        Console.WriteLine("Username must be 4-12 characters long.\n\nLeave blank to return to previous menu.\n");
        string? username = Utils.Promt("Username: ");
        if (username.Equals(string.Empty))
        {
            return;
        }
        else if (username.Length > 3 && username.Length < 12)
        {
            foreach (string user in users)
            {
                string[] info = user.Split(',');
                if (info[0].Equals(username))
                {
                    Console.Clear();
                    Console.WriteLine("Username already exists, try again");
                    Thread.Sleep(1000);
                    Register();
                    return;
                }
            }
            bool validPassword;
            do
            {
                validPassword = true;
                Console.Clear();
                Console.WriteLine("Password must be at least 8 characters long.\n\nLeave blank to return to previous menu.\n");
                string password = MaskedPass();
                if (password.Equals(string.Empty))
                {
                    return;
                }
                else if (password.Length > 7)
                {
                    Console.Clear();
                    Console.WriteLine("Please re-enter password\n\nLeave blank to return to previous menu\n");
                    string passwordCheck = MaskedPass();
                    if (passwordCheck.Equals(string.Empty))
                    {
                        return;
                    }
                    else if (passwordCheck.Equals(password))
                    {
                        File.AppendAllText("users.csv", $"{username},{password},Customer{Environment.NewLine}");
                        File.Create($"Carts/{username}.csv").Close();
                        return;
                    }
                }
                Console.WriteLine("\nInvalid password, try again");
                Thread.Sleep(1000);
                validPassword = false;
            } while (!validPassword);
        }
        Console.WriteLine("\nInvalid username, try again");
        Thread.Sleep(1000);
        Register();
        return;
    }

    static string MaskedPass()
    {
        Console.Write("Password: ");
        string pass = string.Empty;
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                pass += key.KeyChar;
                Console.Write("*");
            }
            else
            {
                if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass = pass.Substring(0, (pass.Length - 1));
                    Console.Write("\b \b");
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        } while (key.Key != ConsoleKey.Enter);
        return pass;
    }
}