//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   Config
//  

namespace Ch07.Config.Models
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            Settings = new GeneralSettings();
        }

        public string ApplicationTitle { get; set; }
        public GeneralSettings Settings { get; set; }
    }
}