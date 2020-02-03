using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevoltTest.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string ID1 { get; set; }
        public string ID2 { get; set; }
    }
}
