using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureExample.WebAPI.Models
{
    public class UserRegistrationRequest
    {
        [Required(ErrorMessage = "Nimi on pakollinen.")]

        public required string Name { get; set; }

        [Required(ErrorMessage = "Sähköposti on pakollinen.")]
        [EmailAddress(ErrorMessage = "Sähköposti ei ole kelvollinen.")]

        public required string Email { get; set; } 
    }
}
