using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;

namespace ConsoleAppFishFarminngToFile.ViewModel
{
    public class CustomerResponseModel
    {
         public string Message { get; set; } = default!;
        public bool Status { get; set; }
        public Customer Customer{ get; set; } = default!;

    }
}