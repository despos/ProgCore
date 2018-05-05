//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR group notifications
// 

namespace SignalFriend.Backend.Model
{
    public class User
    {
        public User(string username, string password, int age, string city)
        {
            UserName = username;
            Password = password;
            Age = age;
            City = city;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
}