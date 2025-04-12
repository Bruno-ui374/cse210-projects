using System;
using System.Collections.Generic;

namespace OnlineShopping
{
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;
        private const decimal ShippingCostUSA = 5m;
        private const decimal ShippingCostInternational = 35m;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        // Adds a product to the order.
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        // Computes the total order cost (products + shipping).
        public decimal GetTotalCost()
        {
            decimal total = 0;
            foreach (Product product in _products)
            {
                total += product.GetTotalCost();
            }
            total += _customer.LivesInUSA() ? ShippingCostUSA : ShippingCostInternational;
            return total;
        }

        // Generates a packing label listing product names and IDs.
        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (Product product in _products)
            {
                label += "Name: " + product.GetName() + ", Product ID: " + product.GetProductId() + "\n";
            }
            return label;
        }

        // Generates a shipping label with the customer's name and full address.
        public string GetShippingLabel()
        {
            string label = "Shipping Label:\n";
            label += "Name: " + _customer.GetName() + "\n";
            label += _customer.GetAddress().GetFullAddress();
            return label;
        }
    }
}
