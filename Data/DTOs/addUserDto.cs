using System.ComponentModel.DataAnnotations;

namespace UsersApi.Data.Dtos;

public class AddUserDto{
    [Required]
    public string Username{get;set;}
    public string Birthdate{get;set;}
    [DataType(DataType.Password)]
    public string Password{get;set;}
    [Required]
    [Compare("Password")]
    public string Repassword{get;set;}

    public AddUserDto(string repassword, string password, string birthdate, string username)
    {
        Repassword = repassword;
        Password = password;
        Birthdate = birthdate;
        Username = username;
    }
}