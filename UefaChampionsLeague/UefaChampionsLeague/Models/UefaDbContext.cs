using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UefaChampionsLeague.Models
{
    public class UefaDbContext:IdentityDbContext<ApplicationUser>
    {
        public UefaDbContext(DbContextOptions<UefaDbContext>options):base(options)
        {

        }
        public DbSet<Clubs> tblClubs { get; set; }
        public DbSet<Players> tblPlayers { get; set; }
    }
}
