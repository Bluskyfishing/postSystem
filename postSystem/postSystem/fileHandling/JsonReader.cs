using Newtonsoft.Json;
namespace postSystem.fileHandling;

public class JsonReader
{
    /// <summary>
    /// Reads the .json file and returns a list of the items and values
    /// </summary>
    /// <returns>items</returns>
    public static List<Item>? ReadItems()
    {
        string jsonFile = "items.json";

        // Read the file
        using StreamReader read = new StreamReader(jsonFile);
        string fileContent = read.ReadToEnd();
        
        // Remove the "info" line, as it caused issues when using JsonConvert.DeserializeObject
        string[] lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        lines[1] = "";
        string remainingContent = string.Join("\n", lines);

        // Convert remainingContent to more easily handle the data
        var items = JsonConvert.DeserializeObject<Dictionary<string, List<Item>>>(remainingContent);

        // Add the items to a list
        if (items != null && items.ContainsKey("packages")) return items?["packages"];
        return null;
    }
}