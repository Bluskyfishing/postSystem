namespace postSystem.fileHandling;

/// <summary>
/// Class file for items
/// </summary>
/// <param name="description"></param>
/// <param name="dimensions"></param>
/// <param name="weight"></param>
public class Item(string description, int[] dimensions, int weight)
{
    public string Description = description;
    public int[] Dimensions = dimensions;
    public int Weight = weight;
}
