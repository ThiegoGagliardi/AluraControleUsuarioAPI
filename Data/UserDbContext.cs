using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using AluraControleUsuarioAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AluraControleUsuarioAPI.Data;

public class UserDbContext : IdentityDbContext<User>
{ 
    public UserDbContext(DbContextOptions<UserDbContext> opts) : base(opts)
    {
        
    }
}
