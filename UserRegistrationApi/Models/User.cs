using System;
using System.ComponentModel.DataAnnotations;

namespace UserRegistrationApi.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "IdentityNumber is required")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "IdentityNumber must be exactly 16 characters")]
        [RegularExpression("^[0-9]{16}$", ErrorMessage = "IdentityNumber must be 16 digits")]
        public string IdentityNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        public DateTime DateOfBirth { get; set; }
    }
}