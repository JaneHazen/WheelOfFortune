using System;
using System.Collections.Generic;

namespace WheelOfFortune
{
    public class GameLoop
    {
        GatherGameData gameData;
        public GameLoop(GatherGameData Input)
        {
            gameData = Input;
        }
        // Checks if character has already been guessed
        public bool CheckIfCharGuessed(char guessedChar, List<char> previousGuesses)
        {
            var check = previousGuesses.Contains(guessedChar);

            return check;
        }

        public List<char> ShowFoundLetters(char guessedChar, string answer, List<char> underscoreTemplate)//pass in object to modify and word to find)
        {
            var characterCount = 0;

            // iterate through answer to see if char is included
            for (int i = 0; i < answer.Length; i++)
            {
                // NEED TO DEBUG; 
                if (answer[i] == guessedChar)
                {
                    characterCount++;
                    //replace letter 
                    underscoreTemplate[i] = guessedChar;
                    //remember to verify that guessedChar has upcase 
                }
            }
            return underscoreTemplate;

        }

        public bool AnswerCheck(string answer)
        {
            Console.WriteLine("To solve the puzzle, type your answer and press enter:");
            var fullAnswerGuess = Console.ReadLine().ToString().ToUpper();
            if (fullAnswerGuess == answer.ToUpper())
            {
                Console.WriteLine("hooray, you win!");
                return true;
            }
            Console.WriteLine("try again!");
            //Give user the choices again (0 quit, 1 solve, 2 spin);
            return false;
        }

        public void GameplayLoop()
        {
            bool InfiniteLoop = true;
            while (InfiniteLoop == true)
            {
                // PLAYER CHOOSES TO GUESS A LETTER ----- OPTION 2
                string playerCharGuess = Console.ReadLine();
            }
        }
    }
}
