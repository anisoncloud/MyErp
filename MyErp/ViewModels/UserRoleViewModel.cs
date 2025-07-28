using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyErp.ViewModels
{
    /*public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<RoleSelection> Roles { get; set; }
    }*/


    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public IList<SelectListItem> Roles { get; set; }
    }

    public class RoleSelection
    {
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}
