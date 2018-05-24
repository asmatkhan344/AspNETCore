using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UefaChampionsLeague.ViewModels
{
    public class UserManagementRoleViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        [Display(Name ="Role")]
        public string NewRole { get; set; }
        public SelectList Roles { get; set; }
    }
}
