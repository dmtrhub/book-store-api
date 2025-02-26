﻿namespace BookStoreAPI.Models
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }

        public ICollection<Book> Books { get; set; } = [];
    }
}
