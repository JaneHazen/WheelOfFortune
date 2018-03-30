using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
public class GatherGameData
{
    public string Answer { get; private set; }
    public List<char> AnswerUnder { get; set; }
    public string PlayerName { get; set; }
    public List<char> previousGuesses { get; set; }
    public bool winner;
    public int  playerCount;
    public string[] playerNames;
    public string logoWheel;
    public string logoOf;
    public string logoFortune;

    /// <summary>
    /// Gathers initial game data 
    /// </summary>
    public GatherGameData()
	{
        this.InitWheelLogo();
        WheelOfFortune.WOFSound.WOFChant();
        AnimateAnnouncement();
        this.playerCount = GetPlayerCount();
        GetPlayerNames();
        Answer = "MICROSOFT IS awesome";
        AnswerUnder = new List<char>();
        for (int i = 0; i < Answer.Length; i++)
            if(Answer[i] == ' ')
                AnswerUnder.Add(' ');
            else
                AnswerUnder.Add('_');
        previousGuesses = new List<char>();
        winner = false;
    }
    public int GetPlayerCount()
    {
        int count = 0;
        bool goodInput = false;
        while (goodInput == false)
        {
            Console.WriteLine("How many players? ");
            if (Int32.TryParse(Console.ReadLine(), out count))
                goodInput = true;
        }
        Console.Clear();
        return (count);
    }

    /// <summary>
    /// Asks the player for their name and reads it
    /// </summary>
    public void GetPlayerNames()
    {
        this.playerNames = new string[playerCount];
        int x = -1;
        while (++x < this.playerCount)
        {
            Console.WriteLine("Please enter a name for player " + (x + 1));
            this.playerNames[x] = ParseInput(Console.ReadLine());
        }
        Console.Clear();
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
    public void DisplayPlayerName(int playerTurn)
    {
      Console.WriteLine($"Player Name: {this.playerNames[playerTurn]} \n");
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
    public void AnimateAnnouncement()
    {
        this.PrintWheelLogo(0);
        System.Threading.Thread.Sleep(1500);
        Console.Clear();
        this.PrintWheelLogo(1);
        System.Threading.Thread.Sleep(1200);
        Console.Clear();
        this.PrintWheelLogo(2);
        System.Threading.Thread.Sleep(1000);
        Console.Clear();
        this.PrintWheelLogo(42);
    }
    public void InitWheelLogo()
    {
        this.logoWheel = "____    __    ____  __    __   _______  _______  __                        \r\n\\   \\  /  \\  /   / |  |  |  | |   ____||   ____||  |                       \r\n \\   \\/    \\/   /  |  |__|  | |  |__   |  |__   |  |                       \r\n  \\            /   |   __   | |   __|  |   __|  |  |                       \r\n   \\    /\\    /    |  |  |  | |  |____ |  |____ |  `----.                  \r\n    \\__/  \\__/     |__|  |__| |_______||_______||_______| ";
        this.logoOf = "                                                                           \r\n  ______    _______                                                        \r\n /  __  \\  |   ____|                                                       \r\n|  |  |  | |  |__                                                          \r\n|  |  |  | |   __|                                                         \r\n|  `--'  | |  |                                                            \r\n \\______/  |__|                                                            ";
        this.logoFortune = " _______   ______   .______     .___________. __    __  .__   __.  _______ \r\n|   ____| /  __  \\  |   _  \\    |           ||  |  |  | |  \\ |  | |   ____|\r\n|  |__   |  |  |  | |  |_)  |   `---|  |----`|  |  |  | |   \\|  | |  |__   \r\n|   __|  |  |  |  | |      /        |  |     |  |  |  | |  . `  | |   __|  \r\n|  |     |  `--'  | |  |\\  \\----.   |  |     |  `--'  | |  |\\   | |  |____ \r\n|__|      \\______/  | _| `._____|   |__|      \\______/  |__| \\__| |_______|\r\n                                                                           ";
    }
    public void PrintWheelLogo(int part)
    {
        if (part == 0)
            Console.WriteLine(this.logoWheel);
        else if (part == 1)
            Console.WriteLine(this.logoOf);
        else if (part == 2)
            Console.WriteLine(this.logoFortune);
        else
        {
            Console.WriteLine(this.logoWheel);
            Console.WriteLine(this.logoOf);
            Console.WriteLine(this.logoFortune);
        }
    }
}