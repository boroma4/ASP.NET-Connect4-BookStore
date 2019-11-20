namespace Domain
{
    public class BookAuthor
    {
        public int BookAuthorId { get; set; }

        public int BookId { get; set; } = default!;
        public Book? Book { get; set; }

        public int AuthorId { get; set; } = default!;
        public Author? Author { get; set; } 
    }
}