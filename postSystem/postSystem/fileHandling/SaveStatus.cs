namespace postSystem.fileHandling;

public class SaveStatus
{
    /// <summary>
    /// Checks if the user want to save the document localy.
    /// </summary>
    /// <returns>saveStatus</returns>
    public static bool Save()
    {
        bool saveStatus = false;
        
        // waits for input Y or N on the keyboard to break the loop
        // and return the applicable value for saveStatus
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