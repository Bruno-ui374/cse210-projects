using System;
using System.Collections.Generic;

namespace OnlineShopping
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // -- Order 1 --
            Address address1 = new Address("123 Main St", "New York", "NY", "USA");
            Customer customer1 = new Customer("Alice Johnson", address1);
            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Widget", "W001", 19.99m, 2));
            order1.AddProduct(new Product("Gadget", "G002", 29.99m, 1));
            order1.AddProduct(new Product("Thingamajig", "T003", 9.99m, 5));

            // -- Order 2 --
            Address address2 = new Address("456 Market St", "Toronto", "ON", "Canada");
            Customer customer2 = new Customer("Bob Smith", address2);
            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("Book", "B004", 14.99m, 3));
            order2.AddProduct(new Product("Pen", "P005", 2.99m, 10));
            order2.AddProduct(new Product("Notebook", "N006", 5.99m, 4));

            // Display details of Order 1.
            Console.WriteLine("==================================");
            Console.WriteLine("Order 1 Details:");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine("Total Cost: $" + order1.GetTotalCost());
            Console.WriteLine("==================================\n");

            // Display details of Order 2.
            Console.WriteLine("==================================");
            Console.WriteLine("Order 2 Details:");
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine("Total Cost: $" + order2.GetTotalCost());
            Console.WriteLine("==================================");
        }
    }
}
