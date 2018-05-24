using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UefaChampionsLeague.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is Required")]
        [Display(Name = "Enter your email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Choose your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is Required")]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "this confirm password did not match")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Your country of residence")]
        [Required(ErrorMessage = "Country is Required")]
        public string Country { get; set; }
        [Display(Name = "Date of birth")]
        [Required(ErrorMessage = "Date of Birth is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{00:yyyy:MM:dd}", ApplyFormatInEditMode = true)]
        public string DOB { get; set; }
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }
        [Display(Name = "What European club(s) do you support?")]
        [Required(ErrorMessage = "Club is Required")]
        public string Club { get; set; }
        [Required]
        [Display(Name = "Would you like to be kept up-to-date on all the exciting promotions offered by UEFA and its partners?")]
        public bool AcceptAgreement { get; set; }
    }
}
