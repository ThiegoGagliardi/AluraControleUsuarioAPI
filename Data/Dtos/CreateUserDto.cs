using System.ComponentModel.DataAnnotations;

namespace AluraControleUsuarioAPI.Data.Dtos;

public class CreateUserDto
{
    [Required]
    public string? UserName { get; set; }

   [Required]
    public DateTime DateBirth { get; set; }

   [Required]
   [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required]
    [Compare("Password")]
    public string? ConfirmPassword { get; set; }

}