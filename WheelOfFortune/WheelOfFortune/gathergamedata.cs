using System;

public class GatherGameData
{
    public string Answer { get; private set; }
    public string AnswerUnder { get; set; }
    public string PlayerName { get; set; }

    /// <summary>
    /// Gathers initial game data 
    /// </summary>
    public GatherGameData()
	{
        Answer = "Microsoft is awesome";
        AnswerUnder = new String('_', Answer.Length);
	}

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

    /// <summary>
    /// Displays the answer with underscore placeholders.
    /// </summary>
    public void DisplayUnderWordConsole()
    {
        Console.WriteLine("Puzzle is: " + AnswerUnder);
    } 
    }

}
