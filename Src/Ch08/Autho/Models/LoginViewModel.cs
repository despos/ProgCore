//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch08 - Securing the Application
//   Autho
// 

namespace Ch08.Autho.Models
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
        {
            RememberMe = true;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
