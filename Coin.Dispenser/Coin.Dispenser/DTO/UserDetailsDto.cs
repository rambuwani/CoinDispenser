using System.ComponentModel.DataAnnotations;

namespace Coin.Dispenser.DTO
{
    public class UserDetailsDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
