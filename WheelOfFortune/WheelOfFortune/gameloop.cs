using System;
using System.Collections.Generic;

namespace WheelOfFortune
{
    public class GameLoop
    {
        // Checks if character has already been guessed
        public bool CheckIfCharGuessed(string charGuess, List<string> previousGuesses)
        {
            var check = previousGuesses.Contains(charGuess);

            return check;
        }

        public GameLoop(object gameData)
        {
            // PLAYER CHOOSES TO GUESS A LETTER ----- OPTION 2
            string playerCharGuess = Console.ReadLine();

            // if char hasn't been guessed before
            if (CheckIfCharGuessed(playerCharGuess, gameData.previousGuesses))
            {

                // HABY'S LOGIC
                // Check for matches in answer and update underscore answer and charCount

                // if char is in answer
                if (charCount > 0)
                {
                    // display "There are {charCount} guessChar in the answer
                    turnResult = $"There is/are {charCount} letter {playerCharGuess.ToUpper} in the puzzle";
                }

            }
        }
    }
}
