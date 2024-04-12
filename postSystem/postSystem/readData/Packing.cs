using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postSystem.readData
{
    public static class Packing
    {
        /// <summary>
        /// Finds the correct packingtype for item.
        /// </summary>
        /// <param name="dimensions"></param>
        /// <returns>float[]package, if no package found return dimensions of package and 0 price.</returns>
        public static float[] PackingFinder(int[] dimensions)
        {
            int length = dimensions[0];
            int width = dimensions[1];
            int height = dimensions[2];

            if (height < 20)
            {
                //Array = [length, width, price]
                float[] option1 = [110, 160, 2.99f]; //price is rounded off. 
                float[] option2 = [150, 210, 2.99f];
                float[] option3 = [180, 260, 5.90f];
                float[] option4 = [270, 360, 8.50f];
                float[] option5 = [350, 470, 15.00f];

                List<float[]> packages = new List<float[]> { option1, option2, option3, option4, option5 };

                foreach (float[] package in packages)
                {
                    if (package[0] >= length && package[1] >= width)
                    {
                        return package;
                    }
                }
                return [length, width, height];
            }

            else if (height > 20)
            {
                //array = [length, width, height, weight, price]
                float[] mini = [240, 159, 60, 67, 18];
                float[] liten = [332, 246, 65, 125.5f, 20]; //Rounded from 125,5 to 126
                float[] eskeNorgesPakken = [350, 250, 120, 191, 24];
                float[] stor = [500, 300, 200, 359, 27];

                List<float[]> packages = new List<float[]> { mini, liten, eskeNorgesPakken, stor };

                foreach (float[] package in packages)
                {
                    if (package[0] >= length && package[1] >= width && package[2] >= height)
                    {
                        return package;
                    }
                }
                return [length, width, 0];
            }
            return [0, 0, 0];
        }
    }

}