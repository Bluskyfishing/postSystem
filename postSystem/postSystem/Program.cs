﻿using postSystem;
using System.Runtime.ConstrainedExecution;

List<Item>? result = JsonReader.ReadItems();

if (result != null)
{
    List<string[]> allItems = new List<string[]>();

    foreach (Item item in result)
    {
        //Console.WriteLine($"Description: {item.Description}, Dimensions: [{string.Join(", ", item.Dimensions)}], Weight: {item.Weight}");
        int[] packing = Packing.PackingFinder(item.Dimensions);
        //Console.WriteLine(string.Join(",", packing));
        string[] postage = Postage.Postagefinder(item.Description, packing, item.Dimensions, item.Weight);
        allItems.Add(postage);
    }
    foreach (string[] postage in allItems) { Console.WriteLine(string.Join(",",postage)); }  
    //MTG card: expected: 110 x 160 item.Dimensions
    //foreach (float x in Packing.PackingFinder([89, 64, 1])) { Console.WriteLine(x); }
}