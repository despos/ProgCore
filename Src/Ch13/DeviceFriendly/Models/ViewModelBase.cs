//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch13 - Building Device-friendly Views
//   DeviceFriendly
//

namespace Ch13.DeviceFriendly.Models
{
    public class ViewModelBase
    {
        protected ViewModelBase(string title = "")
        {
            Title = title;
        }

        public static ViewModelBase Default(string title = "")
        {
            var model = new ViewModelBase(title);
            return model;
        }

        public string Title { get; set; }

    }
}