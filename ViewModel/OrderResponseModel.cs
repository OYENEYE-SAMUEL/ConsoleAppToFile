using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;

namespace ConsoleAppFishFarminngToFile.ViewModel
{
    public class OrderResponseModel
    {
         public string Message { get; set; } = default!;
        public bool Status { get; set; }
        public Order Order { get; set; } = default!;

    }
}