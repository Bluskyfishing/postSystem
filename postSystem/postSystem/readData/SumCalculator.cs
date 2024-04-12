namespace postSystem.readData;
public class SumCalculator
{
    /// <summary>
    /// Adds the totals for price, weight and items from itemList
    /// </summary>
    /// <param name="itemList"></param>
    /// <returns>sum</returns>
    public static List<float> CalculateSum(List<string[]> itemList)
    {
        float totalPrice = 0;
        float totalWeight = 0;
        float totalItems = 0;

        // Parsing the data and adding them together
        foreach (string[] strings in itemList)
        {
            float packagePrice = float.Parse(strings[3]);
            float postagePrice = float.Parse(strings[5]);
            float weight = float.Parse(strings[1]);
            totalPrice += packagePrice + postagePrice;
            totalWeight += weight;
            totalItems += 1;
        }
        // Returns the values in a way they can be separated
        List<float> sum =

        [
            totalItems,
            totalWeight,
            totalPrice
        ];

        return sum;
    }
}