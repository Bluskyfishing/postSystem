using postSystem.fileHandling;
using postSystem.readData;
using System.Runtime.ConstrainedExecution;

// Extract the contents from the .json file
List<Item>? fileContents = JsonReader.ReadItems();

// Finds packing and postage for items from the .json file, and adds them to allitems list.
if (fileContents != null)
{
    List<string[]> allItems = new List<string[]>();

    foreach (Item item in fileContents)
    {
        float[] packing = Packing.PackingFinder(item.Dimensions);
        string[] postage = Postage.Postagefinder(item.Description, packing, item.Dimensions, item.Weight);
        allItems.Add(postage);
    }
    
    // Write the list to the user
    Console.WriteLine("Shipping list:\n" +
                      "Item Description : Weight : Package type : Package price :  Postage type : Postage Price\n");
    foreach (string[] postage in allItems)
    {
        Console.WriteLine(string.Join(" : ",postage));
    }
    
    // write the sum list to the user
    List<float> sum = SumCalculator.CalculateSum(allItems);
    Console.WriteLine($"\nQuantity of items: {sum[0]}\n" +
                      $"Total weight: {sum[1]} g\n" +
                      $"Total price: {sum[2]},-\n");
    
    // Saves the file if the user chooses to
    FileWriter.WriteFile(allItems, sum);
}