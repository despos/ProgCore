//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch04 - ASP.NET MVC Controllers
//   Simple
//

using System;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ch04.Simple.Common
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CultureAttribute : ActionFilterAttribute
    {
        public string Name { get; set; }
        public static string CookieName => "_Culture";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var culture = Name;
            if (string.IsNullOrEmpty(culture))
                culture = GetSavedCultureOrDefault(filterContext.HttpContext.Request);

            // Set culture on current thread
            SetCultureOnThread(culture);

            // Proceed as usual
            base.OnActionExecuting(filterContext);
        }

        public static void SavePreferredCulture(HttpResponse response, string language,
            int expireDays = 1)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(expireDays)
            };
            response.Cookies.Append(CookieName, language, cookieOptions);
        }

        public static string GetSavedCultureOrDefault(HttpRequest httpRequestBase)
        {
            var culture = httpRequestBase.Cookies[CookieName] ?? CultureInfo.CurrentCulture.Name;
            return culture;
        }

        private static void SetCultureOnThread(string language)
        {
            var cultureInfo = new CultureInfo(language);
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
        }
    }
}
