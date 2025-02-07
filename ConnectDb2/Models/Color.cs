using System.ComponentModel.DataAnnotations;

namespace ConnectDb2.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }

        [StringLength(350)]
        public string? ColorName { get; set; }

    }
}
