using Microsoft.AspNetCore.Mvc;

using AluraControleUsuarioAPI.Data.Dtos;
using AluraControleUsuarioAPI.Services;


namespace AluraControleUsuarioAPI.Controller;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private UserService _userService;

    public UserController( UserService userService)
    {
        this._userService = userService;     
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CreateUserAsync(CreateUserDto userDto)
    {
         await _userService.CreateUserAsync(userDto);

         return Ok("Usuário cadastrado");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginUserDto userDto)
    {
        var token = await _userService.LoginAsync(userDto);
        return Ok($"Usuário autenticado. {token}");
    }
}
