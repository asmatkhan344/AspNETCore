using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UefaChampionsLeague.Models
{
    public class Players
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int ClubId { get; set; }
        [ForeignKey("ClubId")]
        public virtual Clubs ClubIdNavigation { get; set; }
    }
}
