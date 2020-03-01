using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDesk.Models
{
    public class Desk
    {
        [ForeignKey("DeskQuote")]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Desk Width (24-96 inches)")]
        [Range(24, 96, ErrorMessage = "Width must be between 24 and 96 inches.")]
        public int Width { get; set; }
        [Display(Name = "Desk Depth (12-48 inches)")]
        [Range(12, 48, ErrorMessage = "Depth must be between 12 and 48 inches.")]
        public int Depth { get; set; }
        [Display(Name = "Drawer Count (0-7)")]
        [Range(0,7,ErrorMessage = "Drawer count must be between 0 and 7.")]
        public int Drawers { get; set; }

        [Display(Name = "Surface Material")]
        [Required(ErrorMessage ="A surface material must be selected.")]
        public int SurfaceMaterialId { get; set; }

        public int SurfaceArea
        {
            get
            {
                return this.Width * this.Depth;
            }
        }
    }
}
