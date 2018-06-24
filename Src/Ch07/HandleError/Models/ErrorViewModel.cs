//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   Except
//  

using System;

namespace Ch07.Except.Models
{
    public class ErrorViewModel : ViewModelBase
    {
        public Exception Error { get; set; }
    }
}