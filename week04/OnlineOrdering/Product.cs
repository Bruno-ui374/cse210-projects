using System;

namespace OnlineShopping
{
    public class Product
    {
        private string _name;
        private string _productId;
        private decimal _price;
        private int _quantity;

        public Product(string name, string productId, decimal price, int quantity)
        {
            _name = name;
            _productId = productId;
            _price = price;
            _quantity = quantity;
        }

        // Computes the total cost of this product.
        public decimal GetTotalCost()
        {
            return _price * _quantity;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetProductId()
        {
            return _productId;
        }
    }
}
