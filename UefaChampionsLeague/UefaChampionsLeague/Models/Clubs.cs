using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UefaChampionsLeague.Models
{
    public class Clubs
    {
        [Key]
        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public string ClubManager { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<Players> Players { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser UserIdNavigation { get; set; }
    }
}
