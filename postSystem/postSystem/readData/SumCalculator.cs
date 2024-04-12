namespace postSystem.methods;

public class SumCalculator
{
    /// <summary>
    /// Adds the totals for price, weight and items from itemList
    /// </summary>
    /// <param name="itemList"></param>
    /// <returns>sum</returns>
    public static List<int> CalculateSum(List<string[]> itemList)
    {
        int totalPrice = 0;
        int totalWeight = 0;
        int totalItems = 0;

        // Parsing the data and adding them together
        foreach (string[] strings in itemList)
        {
            int packagePrice = int.Parse(strings[3]);
            int postagePrice = int.Parse(strings[5]);
            int weight = int.Parse(strings[1]);
            totalPrice += packagePrice + postagePrice;
            totalWeight += weight;
            totalItems += 1;
        }

        // Returns the values in a way they can be separated
        List<int> sum =
        [
            totalItems,
            totalWeight,
            totalPrice
        ];

        return sum;
    }
}