using System.ComponentModel.DataAnnotations;

namespace ConnectDb2.Models
{
    public class Size
    {
        [Key]
        public int SizeId { get; set; }

        [StringLength(350)]
        public string? SizeName { get; set; }
    
    }
}
