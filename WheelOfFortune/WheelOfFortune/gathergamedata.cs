using System;

public class GatherGameData
{

    public string answer;


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
