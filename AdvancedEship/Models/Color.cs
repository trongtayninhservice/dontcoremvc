using System.ComponentModel.DataAnnotations;

namespace AdvancedEship.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }

        [StringLength(350)]
        public string? ColorName { get; set; }

    }
}
