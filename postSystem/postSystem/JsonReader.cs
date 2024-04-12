
using Newtonsoft.Json;
namespace postSystem;

public class JsonReader
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns>items</returns>
    public static List<Item>? ReadItems()
    {
        string jsonFile = "items.json";

        using StreamReader read = new StreamReader(jsonFile);
        
        string fileContent = read.ReadToEnd();
        string[] lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        lines[1] = "";
        string remainingContent = string.Join("\n", lines);
        
        var items = JsonConvert.DeserializeObject<Dictionary<string, List<Item>>>(remainingContent);

        if (items != null && items.ContainsKey("packages")) return items?["packages"];
        return null;
    }
}