using System.ComponentModel.DataAnnotations;

namespace AdvancedEship.Models
{
    public class UserAccount
    {

        [Key]
        public int UserId { get; set; }

        [StringLength(350)]
        public string? My_UserName { get; set; }

        [StringLength(350)]
        public string? My_Password { get; set; }

        [StringLength(350)]
        public string? My_Email { get; set; }

        [StringLength(350)]
        public string? My_Phone { get; set; }

        [StringLength(350)]
        public string? My_Address { get; set; }

        [StringLength(350)]
        public string? My_Role { get; set; }

        [StringLength(5350)]
        public string? My_Note { get; set; }
    }
}
