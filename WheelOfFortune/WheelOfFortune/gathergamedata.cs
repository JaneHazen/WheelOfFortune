using System;

public class GatherGameData
{
    private string answer;


    public string PlayerName { get; set; }

    /// <summary>
    /// Asks the player for their name and reads it
    /// </summary>
    public void GetPlayerName()
    {
        Console.WriteLine("Please enter your name:");
        PlayerName = ParseInput(Console.ReadLine());
    }

    /// <summary>
    /// For testing GetPlayerName method
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public string ParseInput(string input)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            throw new ArgumentNullException();
        return input;
    }

    /// <summary>
    /// Displays player name on the screen
    /// </summary>
    public void DisplayPlayerName()
    {
      Console.WriteLine($"Player Name : {PlayerName}");
    }

    public GatherGameData()
    {
        // Hard-coded Game String
        answer = "Purple Rain";
    }

    // Accessor Method for Answer String
    public string Answer
    {
        get { return answer; }
        private set { answer = value; }
    }

    }

}
