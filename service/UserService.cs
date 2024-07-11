using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Dtos;
using UsersApi.Models;

namespace UsersApi.service;

public class UserService
{
    private IMapper mapper;
    private UserManager<User> userManager;
    private SignInManager<User> signInManager;
    private TokenService tokenService;

    public UserService(IMapper _mapper, UserManager<User> _userManager, SignInManager<User> signInManager, TokenService tokenService)
    {
        mapper = _mapper;
        userManager = _userManager;
        this.signInManager = signInManager;
        this.tokenService = tokenService;
    }
    public async Task add(AddUserDto userDto)
    {

        User user = mapper.Map<User>(userDto);
        var result = await userManager.CreateAsync(user, userDto.Password);

        if (!result.Succeeded)
        {
            Console.WriteLine(result.Errors);

            throw new ApplicationException("Failed to add user");
        }

    }

    public async Task<String> Login(LoginUserDto loginDto){
        var result = await signInManager.PasswordSignInAsync(loginDto.Username,loginDto.Password,false, false);

        if(!result.Succeeded){
            throw new ApplicationException("User not autenticated");
        }

        var user = signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == loginDto.Username.ToUpper());
#pragma warning disable CS8604 // Possível argumento de referência nula.
        var token = tokenService.GenerateToken(user);
#pragma warning restore CS8604 // Possível argumento de referência nula.

        return token;
    }
}