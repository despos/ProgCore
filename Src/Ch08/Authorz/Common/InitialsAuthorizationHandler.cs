//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch08 - Securing the Application
//   Authorz
// 

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Ch08.Authorz.Common
{
    public class InitialsAuthorizationHandler 
        : AuthorizationHandler<InitialsRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            InitialsRequirement requirement)
        {
            // Grab "name" claim from User (must use ClaimTypes as it was added in this way)
            var name = context.User.FindFirst(c => c.Type == ClaimTypes.Name);
            if (name == null)
                return Task.CompletedTask;

            // Grab initials
            var initials = name.Value.Substring(0, 2).ToLower();
            if (initials.Equals(requirement.Initials))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
