using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminngToFile.Models;

namespace ConsoleAppFishFarminngToFile.ViewModel
{
    public class FarmDirectorResponseModel
    {
         public string Message { get; set; } = default!;
        public bool Status { get; set; }
        public FarmDirector FarmDirector{ get; set; } = default!;

    }
}