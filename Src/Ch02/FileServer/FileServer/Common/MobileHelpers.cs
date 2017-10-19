//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch02 - The First ASP.NET Core Project 
//   FileServer
//

using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace Ch02.FileServer.Common
{
    public static class MobileHelpers
    {

        public static bool IsMobileDevice(this HttpContext context)
        {
            var mobileCheck = new Regex(
                @"android|(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino",
                RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);

            var ua = context.Request.Headers["user-agent"].ToString();
            if (mobileCheck.IsMatch(ua))
                    return true;
            return false;
        }
    }
}
