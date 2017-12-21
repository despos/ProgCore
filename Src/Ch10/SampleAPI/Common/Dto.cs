//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch10 - Designing a Web API
//   SampleApi
//

namespace Ch10.SampleApi.Common
{
    public class Dto
    {
        public Dto()
        {
            MoreDetails = new InternalDto();
        }

        public InternalDto MoreDetails { get; set; }
        public int ValueToStore { get; set; }

    }
}