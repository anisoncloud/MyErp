using MyErp.Models;

namespace MyErp.ViewModels
{
    public class CrmCompanyViewModel
    {
        public string CompanyName { get; set; }
        List<CrmContact> CrmContacts { get; set; }
    }
}
