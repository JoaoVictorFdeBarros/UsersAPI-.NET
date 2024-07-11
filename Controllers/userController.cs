using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Dtos;
using UsersApi.service;

namespace UsersApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController:ControllerBase{


    private UserService userService;

    public UserController(UserService _uSerService){
        userService = _uSerService;
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddUser(AddUserDto userDto){
        await userService.add(userDto);
        return Ok();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUserDto loginDto){
        var token = await userService.Login(loginDto);
        return Ok(token);
    }

}