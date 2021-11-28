using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Job
    {
        [Key]
        public int jobId { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
    }
}