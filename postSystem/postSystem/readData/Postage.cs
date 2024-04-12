using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace postSystem.methods
{
    public static class Postage
    {
        //Expected output: ["Item Description", "Weight", "Package type, "Package price",  "Postage type", "Postage Price"] 
        public static string[] Postagefinder(string itemDescription, float[] packingType, int[] packageDimensions, int itemWeight)
        {
            string[] totalItemsArray = new string[6];
            //adds itemName, weight, and dimensions to list.
            totalItemsArray[0] = itemDescription;
            totalItemsArray[1] = itemWeight.ToString();
            totalItemsArray[2] = $"{packingType[0]} x {packingType[1]}";

            float length = packingType[0]; //Length of box/letter
            float width = packingType[1]; //Width of of box/letter

            if (packingType.Length > 3) //Packages Options
            {
                totalItemsArray[3] = packingType[4].ToString(); //Sets price of packing type.

                float height = packingType[2]; //Height of of box only
                float packageWeight = packingType[3]; //Weight of box only 
                float weight = itemWeight + packageWeight; //Add box and item total weight.

                //Norgespakke liten (Inntil 5 kg)
                if (length <= 350 && width <= 250 && height <= 12 && weight >= 350 || weight <= 5000) //Post specifications
                {
                    string postageTypeName = "Norgespakke small (up to 5 kg)";
                    totalItemsArray[4] = postageTypeName;

                    int price = 73;
                    totalItemsArray[5] = price.ToString();

                    return totalItemsArray;

                }
                //Norgespakke stor (over 2kg)
                else if (length > 350 && width > 250 && height > 12 && weight > 2000 && length <= 1200 && width > 600 && height > 600)
                {
                    string postageTypeName = "Norgespakke big (over 2kg)";
                    totalItemsArray[4] = postageTypeName;

                    int[] option1 = [10000, 177]; //Will be handed in at posten so doesnt need price for posten.no?
                    int[] option2 = [25000, 293];
                    int[] option3 = [35000, 377];

                    List<int[]> postageOptions = new List<int[]> { option1, option2, option3 };

                    foreach (int[] option in postageOptions) //Finds if package is within 35000g or not.
                    {
                        if (weight <= 10000)
                        {
                            totalItemsArray[5] = option[1].ToString();
                            return totalItemsArray;
                        }
                        else if (weight <= 25000)
                        {
                            totalItemsArray[5] = option[1].ToString();
                            return totalItemsArray;
                        }
                        else if (weight <= 35000)
                        {
                            totalItemsArray[5] = option[1].ToString();
                            return totalItemsArray;
                        }
                    }

                }
                else
                {
                    totalItemsArray[4] = "Too big to ship!";
                    totalItemsArray[5] = "0";
                    return totalItemsArray;
                }
            }
            else //Letters Options
            {
                totalItemsArray[3] = packingType[2].ToString(); //PackingType for letters doesnt have hight. Adds price to list.
                int height = packageDimensions[2];

                //Letter under 350g
                if (length <= 350 && width <= 250 && height <= 70 && itemWeight < 350)
                {
                    string postageTypeName = "Letter under 350g";
                    totalItemsArray[4] = postageTypeName;

                    // array = [weight, 2cm height price, 2-7cm height price]
                    int[] option1 = [20, 23, 57];
                    int[] option2 = [50, 29, 57];
                    int[] option3 = [100, 36, 57];
                    int[] option4 = [350, 55, 57];

                    List<int[]> postageOptions = new List<int[]> { option1, option2, option3, option4 };

                    foreach (int[] option in postageOptions)
                    {
                        if (option[0] >= itemWeight)
                        {
                            if (height <= 20) //Inntil 2 cm tykk 	
                            {
                                totalItemsArray[5] = option[1].ToString();
                                return totalItemsArray;
                            }
                            else //2–7 cm tykk
                            {
                                totalItemsArray[5] = option[1].ToString();
                                return totalItemsArray;
                            }
                        }
                    }

                }
                //Brev fra 350g til 2kg 
                else if (length + width + height <= 900 && length < 600 && width < 600 && height < 600 && (itemWeight >= 350 || itemWeight <= 2000))
                {
                    string postageTypeName = "Letter from 350g to 2kg ";
                    totalItemsArray[4] = postageTypeName;

                    // array = [weight, 2cm height price, 2-7cm height price, More than 7cm height price]
                    int[] option1 = [20, 23, 57, 90];
                    int[] option2 = [50, 29, 57, 90];
                    int[] option3 = [100, 36, 57, 90];
                    int[] option4 = [350, 55, 57, 90];
                    int[] option5 = [1000, 90, 105, 140];
                    int[] option6 = [2000, 125, 135, 175];

                    List<int[]> postageOptions = new List<int[]> { option1, option2, option3, option4, option5, option6 };

                    foreach (int[] option in postageOptions)
                    {
                        if (option[0] >= itemWeight)
                        {
                            if (height >= 20)
                            {
                                totalItemsArray[5] = option[1].ToString();
                                return totalItemsArray;
                            }
                            else if (height <= 20)
                            {
                                totalItemsArray[5] = option[1].ToString();
                                return totalItemsArray;
                            }
                            else if (height > 70)
                            {
                                totalItemsArray[5] = option[1].ToString();
                                return totalItemsArray;
                            }
                        }
                    }

                }
                else
                {
                    totalItemsArray[4] = "Too big to ship!";
                    totalItemsArray[5] = "0";
                    return totalItemsArray;
                }

            }
            return [];
        }
    }
}
