using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class UnfinishedForm
    {
        public int UnfinishedFormId { get; set; } 

        [MaxLength(128)]
        public string? Title { get; set; } 

        [MaxLength(1024)]
        public string? Summary { get; set; } 

        public int? PublishingYear { get; set; } 
        public int? AuthoredYear { get; set; } 
        public int? WordCount { get; set; } 

        public int? Language { get; set; } 

        public int? Publisher { get; set; }

        public ICollection<BookAuthor>? BookAuthors { get; set; }
    }
}