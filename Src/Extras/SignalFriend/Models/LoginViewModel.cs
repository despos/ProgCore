//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR group notifications
// 

namespace SignalFriend.Models
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
