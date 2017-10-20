//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch11 - Posting Data from Client-side
//   SimpleForms
//

namespace Ch11.SimpleForms.Models
{
    public class FormInputModel  
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string CountryCode { get; set; }
        public string Gender { get; set; }
    }
}