using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace University_management_system.Models
{
    public class SchoolOfEngineering
    {
        [Required]
        public string Name { get; set; }
        [Key]
        public int Id { get; set; }
        [Required]
        public string RegisterNumber { get; set; }
        [Required]
        [DisplayName("Course")]
        public string Course { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [EmailAddressAttribute]
        [DisplayName("Email-address")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Mobile Number")]
        public string PhoneNo { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string BloodGroup { get; set; }
    }
}
