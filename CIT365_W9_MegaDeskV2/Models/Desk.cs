using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIT365_W9_MegaDeskV2.Models
{
    public class Desk
    {
        [ForeignKey("DeskQuote")]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }
        [Display(Name = "Desk Width (24-96 inches)")]
        [Range(24, 96, ErrorMessage = "Width must be between 24 and 96 inches.")]
        public double width { get; set; }
        [Display(Name = "Desk Height (12-48 inches)")]
        [Range(12, 48, ErrorMessage = "Depth must be between 12 and 48 inches.")]
        public double depth { get; set; }
        [Display(Name = "Drawer Count (0-7)")]
        [Range(0,7,ErrorMessage = "Drawer count must be between 0 and 7.")]
        public int drawers { get; set; }

        [Display(Name = "Select Surface Material")]
        [Required(ErrorMessage ="A surface material must be selected.")]
        public int surfaceMaterialID { get; set; }
        //public SurfaceMaterial surfaceMaterial { get; set; }
    }
}
