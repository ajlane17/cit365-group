using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaDesk.Models;

namespace MegaDesk
{
    public class Helper
    {
        //For purposes of this project, there should only be a single instance of these settings so we will not be scaffolding or creating a UI for this.
        public const int baseCost = 200, drawerCost = 50;

        //Constants for surface area Cost
        public const int surfaceCost = 1, surfaceCostThreshold = 1000;

        //Constants for shipping method thresholds
        public const int tier1Max = 1000, tier2Max = 2000;

        public decimal CalcCost(ref DeskQuote dq)
        {
            try
            {
                //Tabulate quote Cost
                decimal tempCost = baseCost;
                //Add surface area Cost if > surface area threshold (i.e. 1,000)
                decimal surfaceArea = dq.Desk.Width * dq.Desk.Depth;
                if (surfaceArea > surfaceCostThreshold) tempCost += surfaceArea * surfaceCost;
                //Add drawer Cost
                tempCost += dq.Desk.Drawers * drawerCost;
                //Add surface material Cost
                //tempCost += dq.Desk.surfaceMaterial.Cost;
                //Add rush shipping costs based on tier and values in RushType dataset
                //TODO: Fix rush type addition
                //if (surfaceArea < tier1Max)
                //{
                //    tempCost += dq.rushType.Tier1Cost;
                //}
                //else if (surfaceArea < tier2Max)
                //{
                //    tempCost += dq.rushType.Tier2Cost;
                //}
                //else
                //{
                //    tempCost += dq.rushType.Tier3Cost;
                //}
                return tempCost;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error in updating price, check to ensure all required fields are populated: " + ex.Message);
                return 0;
            }
        }
    }
}
