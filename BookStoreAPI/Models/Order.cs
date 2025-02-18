﻿namespace BookStoreAPI.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
