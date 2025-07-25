using System.Collections.Generic;
using System.Linq;

namespace DineEase.dao
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public List<OrderItem> Items { get; set; }
        public string Status { get; set; } // "Pending", "Confirmed", "Rejected"
        public decimal Subtotal => Items.Sum(item => item.Price * item.Quantity);
    }

    public class OrderItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
