//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch06 - The Razor Syntax 
//   BootstrapTagHelpers
//

namespace Ch06.BootstrapTagHelpers.Common
{
    public class ModalContext
    {
        public const string HeaderTag = "mheader";
        public const string BodyTag = "mbody";
        public const string FooterTag = "mfooter";

        public string Id { get; set; }
        public bool AutoClose { get; set; }
    }
}