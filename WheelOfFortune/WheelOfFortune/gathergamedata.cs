using System;

public class GatherGameData
{
    private string answer;

    public string answer;

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
