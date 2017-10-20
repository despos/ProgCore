//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch08 - Securing the Application
//   Authorz
// 

using Ch08.Authorz.Common;
using Ch08.Authorz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Ch08.Authorz.Controllers
{
    [Authorize(Policy = "MustBeRegisteredUser")]
    public class SecretController : MyControllerBase
    {
        private readonly IAuthorizationService _authorization;

        public SecretController(
            IOptions<GlobalConfig> config, 
            IAuthorizationService authorization)
        {
            Configuration = config.Value;
            _authorization = authorization;
        }


        public IActionResult Index()
        {
            var model = new IndexViewModel(Configuration.Title);
            return View(model);
        }

        [Authorize(Policy = "MustBeAdministrator")]
        public IActionResult Admin1()
        {
            var model = new IndexViewModel(Configuration.Title);
            return View(model);
        }

        [Authorize(Policy = "MustBeAdministratorWithBlondHair")]
        public IActionResult Admin2()
        {
            var model = new IndexViewModel(Configuration.Title);
            return View(model);
        }

        public IActionResult Guest1()
        {
            var model = new IndexViewModel(Configuration.Title);
            return View(model);
        }

        public IActionResult Guest2()
        {
            // NOTE: method has many overloads (instead of policy name,
            //       you can pass in list of requirements, single requirement, policy object)
            if (_authorization
                .AuthorizeAsync(User, "GuestWithSpecialInitials")
                .Result
                .Succeeded)
            {
                var model = new IndexViewModel(Configuration.Title);
                return View(model);
            }

            return new ChallengeResult();
        }
    }
}
