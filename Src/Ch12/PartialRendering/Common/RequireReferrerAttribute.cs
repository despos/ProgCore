//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch12 - Client-side data binding
//   PartialRendering
//

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;

namespace Ch12.PartialRendering.Common
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequireReferrerAttribute : ActionMethodSelectorAttribute
    {
        public RequireReferrerAttribute(params string[] trustedServers)
        {
            TrustedServers = trustedServers;
        }

        /// <summary>
        /// Array of servers acceptable as referrers
        /// </summary>
        public string[] TrustedServers { get; }

        /// <summary>
        /// Determines if the action method is valid for the request
        /// </summary>
        /// <param name="routeContext">Route context</param>
        /// <param name="action">Descriptor of the action being called</param>
        /// <returns></returns>
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            var referrer = routeContext.HttpContext.Request.Headers["Referer"].ToString();
            if (referrer == null)
                return false;
            referrer = referrer.Trim('/').ToLower();

            var list = TrustedServers.Select(ts => routeContext
                    .HttpContext
                    .Request
                    .GetAbsoluteUrl(ts)
                    .Trim('/')
                    .ToLower()).ToList();
            var result = list.Any(ts => referrer == ts);
            return result;
        }
    }
}