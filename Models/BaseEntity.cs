using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppFishFarminng.Models
{
    public abstract class BaseEntity
    {
          public int Id { get; set; }
        
        public BaseEntity(int id)
        {
            Id = id;
        }

    }
}