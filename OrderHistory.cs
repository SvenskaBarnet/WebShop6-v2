namespace WebShop6_v2;

public class OrderHistory
{
    public static void View(Customer customer)
    {
        Console.Clear();
        string[] orders = File.ReadAllLines($"Orders/{customer.Username}.csv");
        Console.WriteLine("\n------------------------------------------------\n");
        string? sum = null;
        foreach (string line in orders)
        {
            string[] info = line.Split(',');
            if (Enum.TryParse(info[0], out RecieptTag recieptTag))
            {
                switch (recieptTag)
                {
                    case RecieptTag.Sum:
                        sum = $"Total: {info[1]}:-";
                        break;
                    case RecieptTag.Timestamp:
                        Console.WriteLine("{0,-31} {1,10}", sum, info[1]);
                        Console.WriteLine("------------------------------------------------\n");
                        break;
                }
            }
            else
            {
                string formattedProduct = string.Format("{0,-35} {1,10}:-\n", info[0], info[1]);
                Console.WriteLine($"{formattedProduct}");
            }
        }
        Console.WriteLine("\nPress any key to return to previous menu");
        Console.ReadKey();
    }
}