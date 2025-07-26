using System;
using System.ComponentModel.DataAnnotations;

namespace Equinox.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public bool IsCoach { get; set; }
    }
}
