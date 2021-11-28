using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Model
{
    public class Genres
    {
        [Key]
        public int GenresId { get; set; }
        public string GenreName { get; set; }
    }
}