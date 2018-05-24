using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UefaChampionsLeague.ViewModels
{
    public class ClubsViewModel
    {
        [Display(Name ="Club Name")]
        [Required(ErrorMessage ="*")]
        public string ClubName { get; set; }
        [Display(Name = "Club Manager")]
        [Required(ErrorMessage = "*")]
        public string ClubManager { get; set; }
        public string UserId { get; set; }

    }
}
