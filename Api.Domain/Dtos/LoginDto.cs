using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos;

public class LoginDto
{
    [Required (ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLength(100, ErrorMessage = "Email must be between {1} characters")]
    public string Email { get; set; } = string.Empty;
}
