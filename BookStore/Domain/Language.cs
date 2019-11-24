using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Language
    {
        public int LanguageId { get; set; }

        [MinLength(2,ErrorMessage = "Have you heard of such short language names?")]
        [MaxLength(128)]
        public string LanguageName { get; set; } = default!;

        public ICollection<Book>? Books { get; set; }
    }
}