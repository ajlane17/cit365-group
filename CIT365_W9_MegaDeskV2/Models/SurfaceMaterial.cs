using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIT365_W9_MegaDeskV2.Models
{
    public class SurfaceMaterial
    {
        [ForeignKey("Desk")]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Display(Name = "Surface Material Option ID")]
        [ScaffoldColumn(false)]
        public int id { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Surface Material Description")]
        public string description { get; set; }
        [Display(Name = "Cost Per Unit")]
        [DataType(DataType.Currency)]
        public float cost { get; set; }

        [StringLength(30,ErrorMessage ="Maximum length 30")]
        [RegularExpression(@"^[\w,\s-]+\.(jpg|png|gif)$", ErrorMessage ="Must be a JPG, PNG, or GIF image filename no path")]
        [Display(Name = "Image File Name")]
        public string imageFile { get; set; }

    }
}
