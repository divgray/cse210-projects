using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            // Order 1: Customer in the USA.
            Address address1 = new Address("123 Maple St", "Anytown", "CA", "USA");
            Customer customer1 = new Customer("Johny Joe", address1);
            Order order1 = new Order(customer1);

            // Add products for Order 1.
            order1.AddProduct(new Product("Laptop", "LAP123", 999.99m, 1));
            order1.AddProduct(new Product("Mouse", "MOU456", 25.50m, 2));

            // Order 2: Customer outside the USA.
            Address address2 = new Address("456 Oak Lane", "Toronto", "ON", "Canada");
            Customer customer2 = new Customer("Janeth Kim", address2);
            Order order2 = new Order(customer2);

            // Add products for Order 2.
            order2.AddProduct(new Product("Monitor", "MON789", 200.00m, 1));
            order2.AddProduct(new Product("Keyboard", "KEY012", 45.99m, 1));
            order2.AddProduct(new Product("USB Cable", "USB345", 10.00m, 3));

            // Display Order 1 details.
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():0.00}\n");

            // Display Order 2 details.
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():0.00}\n");

            // Keep console open.
            Console.ReadLine();
        }
    }
}
