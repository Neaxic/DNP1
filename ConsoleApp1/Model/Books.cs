using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Model
{
    public class Books
    {
        [Key]
        private int ISBN { get; set; }
        private string Title { get; set; }
        private int TotalPages { get; set; }
        private DateTime PublishDate { get; set; }
    }
}