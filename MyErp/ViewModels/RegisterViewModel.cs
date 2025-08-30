using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MyErp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(8, ErrorMessage = "Password must be at least {2} characters long.", MinimumLength = 2)]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public int CompanyId {  get; set; }
        public List<SelectListItem> Companies { get; set; }
        public List<SelectListItem> Departments {  get; set; }
        public List<SelectListItem> Designations {  get; set; }
        public int DesignationId { get; set; }
        public int DepartmentId {  get; set; }
    }
}
