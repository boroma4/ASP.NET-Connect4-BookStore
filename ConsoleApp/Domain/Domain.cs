using System;
using System.ComponentModel.DataAnnotations;
using GameEngine;

namespace Domain
{
    public class Domain
    {
        [Key] 
        public int Id { get; set; } = 0;

        public GameSettings Type { get; set; }
    }
}