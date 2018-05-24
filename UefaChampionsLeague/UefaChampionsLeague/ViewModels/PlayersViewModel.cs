using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UefaChampionsLeague.ViewModels
{
    public class PlayersViewModel
    {
        [Display(Name ="Player Name")]
        [Required(ErrorMessage ="*")]
        public string Name { get; set; }
        [Display(Name = "Choose Club")]
        [Required(ErrorMessage = "*")]
        public int ClubId { get; set; }
    }
}
