using System;

public class GameLoop
{
    GatherGameData gameData;
	public GameLoop(GatherGameData gameData)
	{
        this.gameData = gameData;
	}
    public bool AnswerCheck()
    {
        Console.WriteLine("To solve the puzzle, type your answer and press enter:");
        var fullAnswerGuess = Console.ReadLine().ToString().ToUpper();
        if (fullAnswerGuess == gameData.answer.ToUpper())
        {
            Console.WriteLine("hooray, you win!");
            return true;
        }

            Console.WriteLine("try again!");
            //Give user the choices again (0 quit, 1 solve, 2 spin);
        return false;
    }
}