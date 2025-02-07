using System.ComponentModel.DataAnnotations;

namespace AdvancedEship.Models
{
    public class Size
    {
        [Key]
        public int SizeId { get; set; }

        [StringLength(350)]
        public string? SizeName { get; set; }
    
    }
}
