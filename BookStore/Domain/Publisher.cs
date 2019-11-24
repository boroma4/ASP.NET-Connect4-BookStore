using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Publisher
    {
        public int PublisherId { get; set; }

        [MaxLength(128)]
        [MinLength(2,ErrorMessage = "Have you heard of such short publisher names?")]
        public string PublisherName { get; set; } = default!;

        public ICollection<Book>? Books { get; set; }
    }
}