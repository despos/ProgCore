//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch08 - Securing the Application
//   Authorz
// 

using Microsoft.AspNetCore.Authorization;

namespace Ch08.Authorz.Common
{
    public class InitialsRequirement : IAuthorizationRequirement
    {
        public InitialsRequirement(string nameStartsWith)
        {
            Initials = nameStartsWith ?? string.Empty;
        }

        public string Initials { get; set; }
    }
}
