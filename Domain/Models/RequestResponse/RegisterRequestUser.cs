﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.RequestResponse
{
   public class RegisterRequestUser
    {
        public string  FullNAme  { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
    }
}
