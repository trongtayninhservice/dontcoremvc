using System.ComponentModel.DataAnnotations;

namespace ConnectDb2.Models
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
