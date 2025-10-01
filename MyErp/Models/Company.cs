using System.ComponentModel.DataAnnotations;

namespace MyErp.Models
{
    public class Company : BaseEntity
    {
        public int ID { get; set; }
        [Display(Name = "Company Name")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? CustomCompanyId {  get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
