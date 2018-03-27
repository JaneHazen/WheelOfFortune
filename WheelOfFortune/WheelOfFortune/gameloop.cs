using System;
using System.Collections.Generic;

public class GameLoop
{

    // Checks if character has already been guessed
    private bool checkIfCharGuessed(string charGuess, List<string> previousGuesses)
    {
        var check = previousGuesses.Contains(charGuess);

        return check;

    }
    public GameLoop(object gameData)
	{
        // PLAYER CHOOSES TO GUESS A LETTER
        string playerCharGuess = Console.ReadLine();

        int charCount = 0;
        string turnResult;


        // Check if letter guessed is in the answer
        // If so, display how many of that character there are

        // if char hasn't been guessed before
        if(checkIfCharGuessed(playerCharGuess, gameData.previousGuesses))
        {


            // if char is in anser
            if(charCount > 0)
            {
                // display "There are {charCount} guessChar in the answer
                turnResult = $"There is/are {charCount} letter {playerCharGuess.ToUpper} in the puzzle";
            }

        }





	}
}
