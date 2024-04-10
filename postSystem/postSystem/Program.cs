// See https://aka.ms/new-console-template for more information

using postSystem;

Console.WriteLine("Hello, World!");

List<Item>? result = JsonReader.ReadItems();

if (result != null)
{
    foreach (Item item in result)
    {
        Console.WriteLine($"Description: {item.Description}, Dimensions: [{string.Join(", ", item.Dimensions)}], Weight: {item.Weight}");
    }
}