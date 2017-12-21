//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch05 - ASP.NET MVC Views
//   JustViews
//

using System;

namespace Ch05.JustViews.Models
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(string title) : base(title)
        {
            
        }

        public string Today { get; set; }
        public DateTime Current { get; set; }
    }
}