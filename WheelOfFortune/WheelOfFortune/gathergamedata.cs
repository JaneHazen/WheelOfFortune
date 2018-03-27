using System;

public class GatherGameData
{
    public string PlayerName { get; set; }

    public void GetPlayerName()
    {
        Console.WriteLine("Please enter your name:");
        PlayerName = Console.ReadLine();
    }

}
