using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Book
    {
        public int BookId { get; set; } 

        [MaxLength(128)]
        public string Title { get; set; } = default!;

        [MaxLength(1024)]
        public string? Summary { get; set; } 

        public int PublishingYear { get; set; } = default!;
        public int AuthoredYear { get; set; } = default!;
        public int WordCount { get; set; } = default!;

        public int LanguageId { get; set; } = default!;
        public Language? Language { get; set; }


        public ICollection<Comment>? Comments { get; set; }

        public int PublisherId { get; set; } = default!;
        public Publisher? Publisher { get; set; }

        public ICollection<BookAuthor>? BookAuthors { get; set; }


    }
}