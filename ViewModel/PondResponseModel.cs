using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;

namespace ConsoleAppFishFarminngToFile.ViewModel
{
    public class PondResponseModel
    {
         public string Message { get; set; } = default!;
        public bool Status { get; set; }
        public Pond Pond{ get; set; }  = default!;

    }
}