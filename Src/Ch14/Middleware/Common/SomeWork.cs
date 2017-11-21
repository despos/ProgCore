//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch14 - The ASP.NET Core Runtime Environment
//   Middleware
//

using System;

namespace Ch14.Middleware.Common
{
    public class SomeWork
    {
        private readonly string _time;
        public SomeWork()
        {
            _time = DateTime.Now.ToString("HH:mm:ss");
        }

        public string Now()
        {
            return _time;
        }
    }
}
