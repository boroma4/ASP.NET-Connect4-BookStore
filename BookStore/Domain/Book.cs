using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Domain
{
    public class Book
    {
        
        public int BookId { get; set; }
        
        [MaxLength(128)]
        public string Title { get; set; } = default!;

        [MaxLength(1024)]
        public string? Summary { get; set; } 

        [Range(-2700,2019,ErrorMessage = "Have some logic in your input please")]
        [Required(ErrorMessage = "This field cannot be empty!")]
        public int? PublishingYear { get; set; } 
        
        [Range(-2700,2019,ErrorMessage = "Have some logic in your input please")]
        [Required(ErrorMessage = "This field cannot be empty!")]
        public int? AuthoredYear { get; set; } 
        
        [Range(1,Int32.MaxValue,ErrorMessage = "Word count must be more than 0")]
        [Required(ErrorMessage = "This field cannot be empty!")]
        public int? WordCount { get; set; } 

        public int LanguageId { get; set; } = default!;
        public Language? Language { get; set; }


        public ICollection<Comment>? Comments { get; set; }

        public int PublisherId { get; set; } = default!;
        public Publisher? Publisher { get; set; }

        public ICollection<BookAuthor>? BookAuthors { get; set; }
        
        

    }
}