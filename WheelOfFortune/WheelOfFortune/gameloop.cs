using System;

public class GameLoop
{
	public GameLoop()
	{
        //User has pressed 1 to solve
        //Take the input from the user (entire puzzle)
        //Compare the user's answer to the actual answer
        Console.WriteLine("Try to solve the puzzle");
        var fullAnswerGuess = Console.ReadKey().ToString();
        if(fullAnswerGuess == gameData.answer)
        {
            Console.WriteLine("hooray, you win!");
        }
        else
        {
            Console.WriteLine("try again!");
            //Give user the choices again (0 quit, 1 solve, 2 spin);
        }

	}
}
