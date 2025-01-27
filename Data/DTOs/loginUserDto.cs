using System.ComponentModel.DataAnnotations;

namespace UsersApi.Data.Dtos;

public class LoginUserDto{
    [Required]
    public string Username{get;set;}
    [Required]
    public string Password{get;set;}

    public LoginUserDto(string password, string username)
    {
        Password = password;
        Username = username;
    }
}