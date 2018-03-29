using System;
using System.Collections.Generic;

public class GatherGameData
{
    public string Answer { get; private set; }
    public List<char> AnswerUnder { get; set; }
    public string PlayerName { get; set; }
    public List<char> previousGuesses;
    int winner;

    /// <summary>
    /// Gathers initial game data 
    /// </summary>
    public GatherGameData()
	{
        Answer = "Microsoft is awesome";
        Console.WriteLine("Starting the game...");
        AnswerUnder = new List<char>();
        for (int i = 0; i < Answer.Length; i++)
            AnswerUnder.Add('_');
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

        Console.Write("Puzzle is: ");
        foreach(char c in Answer)
        {
            Console.Write(c);
        }
    }
}
