using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDesk.Models
{
    public class RushType
    {
        [ForeignKey("DeskQuote")]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Display(Name = "Rush Option ID")]
        public int Id { get; set; }
        [Display(Name = "Shipping Option")]
        public string Description { get; set; }
        [Display(Name = "Tier 1 Cost (up to 1000 sq ft)")]
        public decimal Tier1Cost { get; set; }
        [Display(Name = "Tier 2 Cost (up to 2000 sq ft)")]
        public decimal Tier2Cost { get; set; }
        [Display(Name = "Tier 3 Cost (>2000 sq ft)")]
        public decimal Tier3Cost { get; set; }
    }
}
