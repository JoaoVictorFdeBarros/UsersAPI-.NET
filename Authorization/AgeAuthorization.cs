using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace UsersApi.Authorization;

public class AgeAuthorization : AuthorizationHandler<MinAge>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinAge requirement)
    {
        var BirthdateClaim = context.User.FindFirst(claim =>claim.Type == ClaimTypes.DateOfBirth);

        if (BirthdateClaim is null){
            return Task.CompletedTask;
        }
        var Birthdate = Convert.ToDateTime(BirthdateClaim.Value);

        var age = DateTime.Today.Year - Birthdate.Year;

        if (Birthdate > DateTime.Today.AddYears(-age)){
            age--;
        }

        if(age >= requirement.Age){
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
}