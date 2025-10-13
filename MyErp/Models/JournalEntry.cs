using System.ComponentModel.DataAnnotations;

namespace MyErp.Models
{
    public class JournalEntry : BaseEntity
    {
        public int JournalEntryId {  get; set; }
        public DateTime EntryDate {  get; set; }= DateTime.Now;
        [Required]
        public string Description { get; set; }
        //[Required]
        public List<JournalLine> Lines { get; set; }= new List<JournalLine>();
        public string? VoucherType {  get; set; }
    }
}
