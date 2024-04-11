using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace postSystem
{
    public static class Postage
    {
        public static string Postagefinder(int[] packingType, int[] packageDimensions, int itemWeight)
        {
            int length = packingType[0]; //Length of box/letter
            int width = packingType[1]; //Width of of box/letter

            if (packingType.Length > 2) //Packages Options
            {
                int height = packingType[2]; //Height of of box only
                int packageWeight = packingType[3]; //Weight of box only 
                int weight = itemWeight + packageWeight; //Add box and item total weight.

                //Norgespakke liten (Inntil 5 kg)
                if (length <= 350 && width <= 250 && height <= 12 && weight >= 350 || weight <= 5000)
                {
                    Console.WriteLine();
                }

                //Norgespakke stor (over 2kg)
                else if (length > 350 && width > 250 && height > 12 && weight > 2000 && length <= 1200 && width > 600 && height > 600)
                {
                    Console.WriteLine();
                }
                else
                {
                    return "Package is too big!";
                }
            }
            else //Letters Options
            {
                int height = packageDimensions[2];

                //Letter under 350g
                if (length <= 350 && width <= 250 && height <= 70 && itemWeight < 350) 
                {
                    Console.WriteLine();
                }
                //Brev fra 350g til 2kg 
                else if (length + width + height <= 900 && length < 600 && width < 600 && height < 600 && itemWeight >= 350 || itemWeight <= 2000)
                {
                    Console.WriteLine();
                }
                else 
                {
                    return "Package is too big!";
                }

            }

            //Description,
            //Total Weight per item(item+container),
            //Price(per shipped object),
            //Total price. 

            return "work in progress";
        }
    }
}
