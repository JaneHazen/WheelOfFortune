using System;
using System.Collections.Generic;

public class GatherGameData
{
    public string Answer { get; private set; }
    public List<char> AnswerUnder { get; set; }
    public string PlayerName { get; set; }
    public List<char> previousGuesses { get; set; }
    public bool winner;

    /// <summary>
    /// Gathers initial game data 
    /// </summary>
    public GatherGameData()
	{
        GetPlayerName();
        Answer = "MICROSOFT IS AWESOME";
        DisplayPlayerName();
        AnswerUnder = new List<char>();
        for (int i = 0; i < Answer.Length; i++)
            if(Answer[i] == ' ')
                AnswerUnder.Add(' ');
            else
                AnswerUnder.Add('_');

        previousGuesses = new List<char>();
        winner = false;
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
      Console.WriteLine($"Player Name: {PlayerName} \n");
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