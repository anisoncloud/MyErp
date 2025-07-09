using System.ComponentModel.DataAnnotations;

namespace MyErp.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Current password is required.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmNewPassword", ErrorMessage = "The current password and confirmation do not match.")]
        [StringLength(40, ErrorMessage = "The password must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm new password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        public string ConfirmNewPassword { get; set; }
    }
}
