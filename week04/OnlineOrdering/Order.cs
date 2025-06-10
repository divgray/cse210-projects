using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    public class Order
    {
        private Customer _customer;
        private List<Product> _products;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public decimal CalculateTotalCost()
        {
            decimal totalProductsCost = 0;
            foreach (Product product in _products)
            {
                totalProductsCost += product.GetTotalCost();
            }

            // Shipping cost: $5 if in USA; otherwise, $35.
            decimal shippingCost = _customer.LivesInUSA() ? 5m : 35m;
            return totalProductsCost + shippingCost;
        }

        public string GetPackingLabel()
        {
            string label = "PACKING LABEL:\n";
            foreach (Product product in _products)
            {
                label += $"Product Name: {product.GetProductName()}, Product ID: {product.GetProductId()}\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"SHIPPING LABEL:\nCustomer: {_customer.GetName()}\nAddress:\n{_customer.GetAddress().GetFullAddress()}";
        }
    }
}