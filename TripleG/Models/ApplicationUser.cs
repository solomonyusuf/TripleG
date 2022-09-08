using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripleG.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string ImgPath { get; set; }
        public string Role { get; set; }


    }
}
