using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MegaDesk.Models
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

        [DataType(DataType.Currency)]
        public decimal PricePerSquareInch { get; set; }
        [DataType(DataType.Currency)]
        public decimal PricePerDrawer { get; set; }
        [DataType(DataType.Currency)]
        public decimal BasePrice { get; set; }
        public int SurfacePriceFloor { get; set; }
        [DataType(DataType.Currency)]
        public decimal MaterialCost { get; set; }
        [DataType(DataType.Currency)]
        public decimal ShippingCost { get; set; }

        [DataType(DataType.Currency)]
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

        [DataType(DataType.Currency)]
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
