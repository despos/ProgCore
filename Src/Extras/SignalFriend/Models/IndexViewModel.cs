//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR group notifications
// 

using System.Collections.Generic;
using SignalFriend.Backend.Model;

namespace SignalFriend.Models
{
    public class IndexViewModel : ViewModelBase
    {
        public IndexViewModel(string title) : base(title)
        {

        } 
        
        public IList<User> Friends { get; set; }
    }
}
