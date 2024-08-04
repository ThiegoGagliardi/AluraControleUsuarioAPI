using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AluraControleUsuarioAPI.Authorization;

public class AgeAuthorization : AuthorizationHandler<MinimumAge>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
                                                    MinimumAge requirement)
    {
        var birthDateClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

        if (birthDateClaim is null){
          return Task.CompletedTask;
        }

        var userBirthDate = Convert.ToDateTime(birthDateClaim.Value);

        if (userBirthDate <= DateTime.Today.AddDays(-requirement.Age)){
            context.Succeed(requirement);
        }
        return Task.CompletedTask;

    }
}