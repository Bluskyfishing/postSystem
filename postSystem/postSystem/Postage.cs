using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postSystem
{
    public static class Postage
    {
        public static string Postagefinder(int[] packingType, int[] packageDimensions)
        {
            int length = packingType[0];
            int width = packingType[1];

            int packageWeight = packageDimensions[2];

            Console.Write($"Length: {length} \nWidth: {width} ");

            if (packingType.Length > 2)
            {
                int height = packingType[2];
                int weight = packingType[3] + packageWeight;

                Console.Write($"\nHeight: {height}\nWeight: {weight}");
            }
            else
            {
                Console.WriteLine("\nWeight: " + packageWeight);
            }

           

            return "work in progress";
        }
    }
}
