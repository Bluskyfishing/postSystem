using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postSystem
{
    public static class Packing
    {
        public static int[] PackingFinder(int[] dimensions) 
        {
            int length = dimensions[0];
            int width = dimensions[1];
            int height = dimensions[2];

            if (height < 20)
            {
                int[] option1 = [110, 160];
                int[] option2 = [150, 210];
                int[] option3 = [180, 260];
                int[] option4 = [270, 360];
                int[] option5 = [350, 470];

                List<int[]> packages = new List<int[]> { option1, option2, option3, option4, option5 };

                foreach (int[] package in packages)
                {
                    if (package[0] >= length && package[1] >= width)
                    {
                        return package;
                    }
                }
                return [1, 0, 0];
            }

            else if (height > 20) 
            {
                //length, width, height, weight
                int[] mini = [240, 159, 60, 67];
                int[] liten = [332, 246, 65, 126]; //Rounded from 125,5 to 126
                int[] eskeNorgesPakken = [350, 250, 120, 191];
                int[] stor = [500, 300, 200, 359];

                List<int[]> packages = new List<int[]> { mini, liten, eskeNorgesPakken, stor };

                foreach (int[] package in packages)
                {
                    if (package[0] >= length && package[1] >= width && package[2] >= height)
                    {
                        return package;
                    }
                }
                return [2,0,0];
            }
            return [0,0,0];
        }
    }
    
}