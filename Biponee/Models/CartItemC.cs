using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biponee.Models
{
    public class CartItemC
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public String ProductImage { get; set; }
        public String ProductName { get; set; }
        public String ProductSize { get; set; }
        public Double UnitPrice { get; set; }
        public int Qty { get; set; }
        public String Subtotal { get; set; }

        public CartItemC(int orderId, int productId, string productImage, string productName, string productSize, double unitPrice, int qty, string subtotal)
        {
            OrderId = orderId;
            ProductId = productId;
            ProductImage = productImage;
            ProductName = productName;
            ProductSize = productSize;
            UnitPrice = unitPrice;
            Qty = qty;
            Subtotal = subtotal;
        }

        public CartItemC(int productId, string productImage, string productName, string productSize, double unitPrice, int qty, string subtotal)
        {
            ProductId = productId;
            ProductImage = productImage;
            ProductName = productName;
            ProductSize = productSize;
            UnitPrice = unitPrice;
            Qty = qty;
            Subtotal = subtotal;
        }

        public CartItemC()
        {
        }
    }
}