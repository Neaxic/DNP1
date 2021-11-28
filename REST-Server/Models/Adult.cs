using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models {
public class Adult : Person {
    
    [Key]
    public int Id { get; set; }
    
    public Job JobTitle { get; set; }
}
}