namespace BookStoreAPI.Models
{
    public class Author
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public string? Biography { get; set; }

        public ICollection<Book> Books { get; set; } = [];
    }
}
