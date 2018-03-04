//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   Config
//  

using System.Collections.Generic;

namespace Ch07.Config.Models
{
    public class GeneralSettings
    {
        public GeneralSettings()
        {
            Paging = new PagingSettings();
            CopyrightYears = new List<int>();
        }

        public IList<int> CopyrightYears { get; set; }
        public PagingSettings Paging { get; set; }
        public int Timezone { get; set; }
    }

    public class PagingSettings
    {
        public int PageSize { get; set; }
    }
}