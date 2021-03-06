﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDesk.Models
{
    public class SurfaceMaterial
    {
        [ForeignKey("Desk")]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Display(Name = "Surface Material Option ID")]
        public int Id { get; set; }
        //[Required]
        [StringLength(30)]
        [Display(Name = "Surface Material Description")]
        public string Description { get; set; }
        [Display(Name = "Cost Per Unit")]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        [StringLength(30,ErrorMessage ="Maximum length 30")]
        [RegularExpression(@"^[\w,\s-]+\.(jpg|png|gif)$", ErrorMessage ="Must be a JPG, PNG, or GIF image filename no path")]
        [Display(Name = "Image File Name")]
        public string ImageFile { get; set; }

    }
}
