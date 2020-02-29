using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIT365_W9_MegaDeskV2.Models
{
    public class RushType
    {
        [ForeignKey("DeskQuote")]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Display(Name = "Rush Option ID")]
        public int id { get; set; }
        [Display(Name = "Shipping Option")]
        public string description { get; set; }
        [Display(Name = "Tier 1 cost (up to 1000 sq ft)")]
        public float tier1Cost { get; set; }
        [Display(Name = "Tier 2 cost (up to 2000 sq ft)")]
        public float tier2Cost { get; set; }
        [Display(Name = "Tier 3 cost (>2000 sq ft)")]
        public float tier3Cost { get; set; }
    }
}
