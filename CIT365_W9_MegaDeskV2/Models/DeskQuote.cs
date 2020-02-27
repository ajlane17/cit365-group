using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CIT365_W9_MegaDeskV2.Models
{
    public class DeskQuote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }
        [Display(Name = "Customer Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The customer name length must be between 3 and 50 characters")]
        public String customerName { get; set; }
        [Required(ErrorMessage = "A desk must be configured")]
        public Desk desk { get; set; }
        //public int deskID { get; set; }
        [Required(ErrorMessage = "A shipping method must be selected.")]
        public int rushID { get; set; }

        //Adding this for the lookup value causes an error when accessing the data.
        //public IEnumerable<SelectListItem> RushTypeList { get; set; }

        [Display(Name = "Quote Amount")]
        [DataType(DataType.Currency)]
        [Editable(false)]
        public double totalQuote { get; set; }
    }
}
