using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AluraControleUsuarioAPI.Models;

public class User : IdentityUser
{

    public DateTime DateBirth { get; set; }

    public User() : base ()
    {
        
    }

}