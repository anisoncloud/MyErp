using System.ComponentModel.DataAnnotations;

namespace MyErp.Models
{
    public class Designation : BaseEntity
    {
        public int DesignationID { get; set; }
        [Display(Name = "Designation")]
        public string Name { get; set; }
        public string? Description { get; set; }       
        public ICollection<Users> Users { get; set; }
    }
}
