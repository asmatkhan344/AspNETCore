using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UefaChampionsLeague.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Club { get; set; }

        public virtual ICollection<Clubs> Clubs { get; set; }
    }
}
