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

        public GameLoop(GatherGameData gameData)
        {
            // PLAYER CHOOSES TO GUESS A LETTER ----- OPTION 2
            string playerCharGuess = Console.ReadLine();

            // if char hasn't been guessed before
        }
    }
}
