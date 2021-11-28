using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class UserForAuthenticationDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
