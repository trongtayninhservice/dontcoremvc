using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvancedEship.Models
{
    public class ShoppingCart
    {
        [Key]
        public int CartId { get; set; }

        public int? UserId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime AddedDate { get; set; }

        [Required]
        public Guid GuidId { get; set; }

        // Navigation properties
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        // Constructor
        public ShoppingCart()
        {
            GuidId = Guid.NewGuid();
        }

        // Nếu bạn có bảng Users, bạn có thể thêm thuộc tính điều hướng cho User
        // [ForeignKey("UserId")]
        // public virtual User User { get; set; }
    }
}