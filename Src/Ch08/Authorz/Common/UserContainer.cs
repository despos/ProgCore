//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch08 - Securing the Application
//   Authorz
// 

namespace Ch08.Authorz.Common
{
    public class UserContainer
    {
        public UserContainer(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
}
