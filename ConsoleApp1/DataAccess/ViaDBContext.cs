using System;
using ConsoleApp1.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.DataAccess
{
    public class ViaDBContext : DbContext
    {
        public DbSet<Books> Books { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Genres> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlite(@"Data Source = /Users/andreas/Documents/Github/DNP1/ConsoleApp1/Library.db");
        }
    }
}