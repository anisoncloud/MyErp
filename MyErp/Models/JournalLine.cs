using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyErp.Models
{
    public class JournalLine : BaseEntity
    {
        public int JournalLineId {  get; set; }
        public int JournalEntryId {  get; set; }
        [ValidateNever]
        public JournalEntry JournalEntry { get; set; }
        public int AccountId {  get; set; }
        [ValidateNever]
        public ChartOfAccount Account { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Debit {  get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Credit { get; set; }
    }
}
