using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using UsersApi.Models;

namespace UsersApi.service;

public class TokenService{
    public string GenerateToken(User user){
        Claim[] claims = new Claim[]{
            new Claim("Username", user.UserName),
            new Claim("id", user.Id),
            new Claim(ClaimTypes.DateOfBirth, user.Birthdate.ToString(), ClaimValueTypes.Date)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sdd49ryWHOTUtgr53D"));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(expires:DateTime.Now.AddMinutes(10), claims:claims, signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}