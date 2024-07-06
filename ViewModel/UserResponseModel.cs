using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;

namespace ConsoleAppFishFarminngToFile.ViewModel
{
    public class UserResponseModel
    {
         public string Message { get; set; } = default!;
        public bool Status { get; set; }
        public User User{ get; set; } = default!;

    }
}