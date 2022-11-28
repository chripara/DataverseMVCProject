using System.ComponentModel.DataAnnotations;

namespace DataverseMVCProject.Dtos.Customer
{
    public class CreateCustomerDto
    {
        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(20)]
        public string ContactPhone { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [Required]
        [MaxLength(30)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
