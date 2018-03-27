using System;

public class GatherGameData
{
    public string Answer { get; private set; }
    public string AnswerUnder { get; set; }

    /// <summary>
    /// Gathers initial game data 
    /// </summary>
	public GatherGameData()
	{
        Answer = "Microsoft is awesome";
        AnswerUnder = new String('_', Answer.Length);
	}

    /// <summary>
    /// Displays the answer with underscore placeholders.
    /// </summary>
    public void DisplayUnderWordConsole()
    {
        Console.WriteLine("Puzzle is: " + AnswerUnder);
    }
}
