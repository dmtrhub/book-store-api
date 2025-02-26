﻿namespace BookStoreAPI.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();       
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid OrderId { get; set; }
        public Guid BookId { get; set; }

        public Order Order { get; set; }
        public Book Book { get; set; }
    }
}
