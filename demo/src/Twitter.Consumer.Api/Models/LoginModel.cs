using System.ComponentModel.DataAnnotations;

namespace Twitter.Consumer.Api.Models
{
    public record LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; init; } = "";

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; init; } = "";
    }
}
