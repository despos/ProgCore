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
    public class ViewModelBase
    {
        public ViewModelBase(string title = "")
        {
            Title = title;
            ErrorMessage = "";
            StatusCode = 0;
        }

        public string Title { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
    }
}
