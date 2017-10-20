//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch05 - ASP.NET MVC Views
//   ViewEngine
//

namespace Ch05.ViewEngine.Common
{
    public class Dog
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}