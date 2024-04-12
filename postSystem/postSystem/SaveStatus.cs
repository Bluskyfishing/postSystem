namespace postSystem;

public class SaveStatus
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns>saveStatus</returns>
    public static bool Save()
    {
        bool saveStatus = false;
        while (true)
        {
            Console.WriteLine("Do you wish to save your document?\n[Y] - Yes\n[N] - No");
            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.Y)
            {
                saveStatus = !saveStatus;
                break;
            }
            if (input.Key == ConsoleKey.N)
            {
                break;
            }
        }
        return saveStatus;
    }
}