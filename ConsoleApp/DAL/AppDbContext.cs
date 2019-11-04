using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<GameSettings> Settings { get; set; } = default!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= D:\C#\ics0016-2019f\ConsoleApp\ConsoleApp\bin\Debug\netcoreapp3.0\mydb.db");

        }

    }

}