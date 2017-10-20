//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Access to Application Data
//   EfCore
// 

using System;

namespace Ch09.EfCore.Backend.Persistence.Model
{
    public class EntityBase
    {
        public EntityBase()
        {
            Enabled = true;
            Modified = DateTime.UtcNow;
        }

        public bool Enabled { get; set; }
        public DateTime? Modified { get; set; }
    }
}