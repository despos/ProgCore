//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch10 - Designing a Web API
//   SampleApi
//

using System;

namespace Ch10.SampleApi.Common
{
    public class News
    {
        public System.Guid NewsId { get; set; }
        public string Title { get; set; }
        public DateTime? When { get; set; }
        public string Content { get; set; }
    }
}