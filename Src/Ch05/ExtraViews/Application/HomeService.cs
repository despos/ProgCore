//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch05 - ASP.NET MVC Views
//   JustViews
//

using System;
using Ch05.JustViews.Models;

namespace Ch05.JustViews.Application
{
    public class HomeService : ApplicationServiceBase, IHomeService
    {
        public HomeViewModel GetHomeViewModel()
        {
            var model = new HomeViewModel("Page title")
            {
                Current = DateTime.Today
            };
            model.Today = model.Current.ToString("dddd, <b>d MMM</b> yyyy");
            return model;
        }
    }
}