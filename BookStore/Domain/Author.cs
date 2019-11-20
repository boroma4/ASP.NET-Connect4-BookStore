﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Author
    {
        public int AuthorId { get; set; }

        [MaxLength(128)] public string FirstName { get; set; } = default!;
        [MaxLength(128)] public string LastName { get; set; } = default!;

        public int YearOfBirth { get; set; } = default!;

        public ICollection<BookAuthor>? AuthorBooks { get; set; }

        public string FirstLastName => FirstName + " " + LastName;
       

    }
}