namespace WebShop6_v2;

public record Customer(string Username, List<Product> cart) : IUser;