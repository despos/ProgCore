//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch06 - The Razor Syntax 
//   TagHelpers
//

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ch06.TagHelpers.Models
{
    public class RoomViewModel : ViewModelBase
    {
        public RoomViewModel(string title) : base(title)
        {
            RoomTypes = new List<string>();
        }

        public IList<string> RoomTypes { get; set; }
        public RoomCategories CurrentRoomType { get; set; }
    }

    public enum RoomCategories
    {
        [Display(Name = "Not specified")]
        None,
        Single,
        [Display(Name = "Very large room")]
        Double
    }
}