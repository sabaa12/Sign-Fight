using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
namespace Domain.Models.Data
{
   public class User: IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string  City { get; set; }
        public string Zip { get; set; }
        public ICollection<Cause> Causes { get; set; }
    }
}
