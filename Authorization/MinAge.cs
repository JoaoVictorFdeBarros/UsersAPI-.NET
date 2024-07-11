using Microsoft.AspNetCore.Authorization;

namespace UsersApi.Authorization;

public class MinAge: IAuthorizationRequirement{
    public int Age{get;set;}

    public MinAge(int _Age)
    {
        Age = _Age;
    }
}