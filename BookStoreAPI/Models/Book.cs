namespace BookStoreAPI.Models
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }

        public Author Author { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = [];
    }
}
