using System.ComponentModel.DataAnnotations;

namespace Equinox.Models
{
    public class Club
    {
        public int ClubId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
