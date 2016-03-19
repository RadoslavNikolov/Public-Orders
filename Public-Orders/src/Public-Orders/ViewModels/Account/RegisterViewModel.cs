namespace PublicOrders.ViewModels.Account
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "EGN")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "The EGN must contain exactly 10 digits")]
        public string Egn { get; set; }

        [Display(Name = "User age")]
        [RegularExpression(@"^([1-9][0-9]?|10[0-9]|11[0-5])$", ErrorMessage = "The user age must be between 1 - 115")]
        public short Age { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
