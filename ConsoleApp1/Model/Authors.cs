using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Model
{
    public class Authors
    {
        [Key]
        public int AuthorsId { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
    }
}