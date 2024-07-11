using AutoMapper;
using UsersApi.Data.Dtos;
using UsersApi.Models;

namespace UsersApi.profiles;

public class UserProfile: Profile{
     public UserProfile(){
        CreateMap<AddUserDto, User>();
     }
}