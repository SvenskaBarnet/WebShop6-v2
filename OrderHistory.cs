namespace WebShop6_v2;

public class OrderHistory
{
    public static void View(Customer customer)
    {
        Console.Clear();
        string[] files = Directory.GetFiles($"Orders/{customer.Username}/");
        foreach (string file in files)
        {
            string[] orders = File.ReadAllLines(file);
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
                            Console.WriteLine("\n{0,-32} {1,15}", info[1], sum);
                            Console.WriteLine("\n------------------------------------------------\n");
                            break;
                        case RecieptTag.Product:
                            string formattedProduct = string.Format("{0,-35} {1,10}:-\n", info[1], info[2]);
                            Console.WriteLine($"{formattedProduct}");
                            break;
                    }
                }
            }
        }
        Console.WriteLine("\nPress any key to return to previous menu");
        Console.ReadKey();
    }
}