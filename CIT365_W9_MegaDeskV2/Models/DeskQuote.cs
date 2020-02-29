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
        public int Id { get; set; }
        [Display(Name = "Customer Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The customer name length must be between 3 and 50 characters")]
        public String CustomerName { get; set; }
        [Required(ErrorMessage = "A Desk must be configured")]
        public Desk Desk { get; set; }
        //public int deskID { get; set; }
        //[Required(ErrorMessage = "A shipping method must be selected.")]
        public int RushId { get; set; }

        public decimal PricePerSquareInch { get; set; }
        public decimal PricePerDrawer { get; set; }
        public decimal BasePrice { get; set; }
        public int SurfacePriceFloor { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal ShippingCost { get; set; }

        public decimal DrawerCost
        {
            get
            {
                return PricePerDrawer * Desk.Drawers;
            }
        }

        public int SizeOverage
        {
            get
            {
                if (Desk.SurfaceArea > SurfacePriceFloor)
                    return (Desk.SurfaceArea - SurfacePriceFloor);
                else
                    return 0;
            }
        }

        public decimal SizeCost
        {
            get
            {
                return SizeOverage * PricePerSquareInch;
            }
        }

        [DataType(DataType.Currency)]
        public decimal QuotePrice
        {
            get
            {
                return BasePrice + MaterialCost + DrawerCost + SizeCost + ShippingCost;
            }
        }
    }
}
