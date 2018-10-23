//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR - 1
//

namespace WebSock.Models
{
    public class ViewModelBase
    {
        public static ViewModelBase Default()
        {
            return new ViewModelBase() {Title = "Azure SignalR Demo"};
        }

        public string Title { get; set; }
        public string UserName { get; set; }
    }
}