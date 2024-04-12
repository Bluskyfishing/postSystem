using postSystem.fileHandling;
using postSystem.methods;
using System.Runtime.ConstrainedExecution;

List<Item>? result = JsonReader.ReadItems();

if (result != null)
{
    List<string[]> allItems = new List<string[]>();

    foreach (Item item in result)
    {
        float[] packing = Packing.PackingFinder(item.Dimensions);
        string[] postage = Postage.Postagefinder(item.Description, packing, item.Dimensions, item.Weight);
        allItems.Add(postage);
    }
    Console.WriteLine("Shipping list:\n" +
                      "Item Description : Weight : Package type : Package price :  Postage type : Postage Price\n");

    foreach (string[] postage in allItems)
    {
        Console.WriteLine(string.Join(" : ",postage));
    }
    
    List<float> sum = SumCalculator.CalculateSum(allItems);
    
    Console.WriteLine($"\nQuantity of items: {sum[0]}\n" +
                      $"Total weight: {sum[1]} g\n" +
                      $"Total price: {sum[2]},-\n");
    
    FileWriter.WriteFile(allItems, sum);
}