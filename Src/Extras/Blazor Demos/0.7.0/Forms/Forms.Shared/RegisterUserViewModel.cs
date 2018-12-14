using System;

namespace Forms.Shared
{
    public class RegisterUserViewModel
    {
        public RegisterUserViewModel()
        {
            
        }
        public RegisterUserViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
