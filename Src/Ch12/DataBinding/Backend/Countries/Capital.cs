//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch12 - Client-side data binding
//   DataBinding
//

using System.Collections.Generic;

namespace Ch12.DataBinding.Backend.Countries
{
    public class Capital
    {
        public double DLST { get; set; }
        public double TD { get; set; }
        public int Flg { get; set; }
        public string Name { get; set; }
        public List<double> GeoPt { get; set; }
    }   
}