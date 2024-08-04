using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using AluraControleUsuarioAPI.Models;
using AluraControleUsuarioAPI.Data.Dtos;
using System.Xml;


namespace AluraControleUsuarioAPI.Services;

public class UserService
{

    private IMapper _mapper;

    private UserManager<User> _userManager;

    private SignInManager<User> _signInManager;
    private TokenService _tokenService;

    public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
    {
        this._mapper = mapper;
        this._userManager = userManager;
        this._signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task CreateUserAsync(CreateUserDto userDto)
    {
        User user = _mapper.Map<User>(userDto);

        IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);

        if (!result.Succeeded){
            throw new ApplicationException($"Falha ao cadastra usuário.");
        }
    }

    public async Task<string> LoginAsync(LoginUserDto userDto)
    {
        var result = await _signInManager.PasswordSignInAsync(userDto.UserName, userDto.Password, false, false);

        if (!result.Succeeded){ 
         
            throw new ApplicationException("Usuário não autenticado."); 
        }
        
        User user = _signInManager
                                 .UserManager
                                 .Users
                                 .FirstOrDefault(user => user.NormalizedUserName == userDto.UserName.ToUpper());

       var token =  _tokenService.GenerateToken(user);

       return token;        
    }
}