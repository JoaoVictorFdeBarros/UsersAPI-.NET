using Microsoft.AspNetCore.Identity;

namespace UsersApi.Models;

public class User: IdentityUser{

    public DateTime Birthdate{get;set;}

    public User(): base(){
    }

}