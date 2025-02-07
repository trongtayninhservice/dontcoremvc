using System.ComponentModel.DataAnnotations;

namespace AdvancedEship.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(350)]
        public string My_UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(350)]
        public string My_Password { get; set; }
    }
}
