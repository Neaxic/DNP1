using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Model
{
    public class Books
    {
        [Key]
        public int ISBN { get; set; }
        public string Title { get; set; }
        public int TotalPages { get; set; }
        public DateTime PublishDate { get; set; }
        
        public Genres genre { get; set; }
        public Authors author { get; set; }
        
    }
}