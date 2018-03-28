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
                if (answer[i] == guessedChar)
                {
                    characterCount++;
                    //replace letter 
                    underscoreTemplate[i] = guessedChar;
                    //remember to verify that guessedChar has upcase 
                }
            }

            if(characterCount > 0)
            {
                Console.WriteLine($"There is/are {characterCount} letter {guessedChar} in the puzzle");
            }
            else
            {
                Console.Write("Sorry, guess again");
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

            // each iteration is a turn
            while (InfiniteLoop == true)
            {
                string underscores = string.Join(" ", gameData.AnswerUnder.ToArray());
                Console.WriteLine(underscores);

                Console.WriteLine("");
                Console.WriteLine("0 to quit the game \n 1 to solve the puzzle \n 2 guess a letter");

                string turnOption = Console.ReadLine();

                // quit the game
                if(turnOption == "0")
                {
                    // quit game
                }

                if(turnOption == "1")
                {
                    AnswerCheck(gameData.Answer);
                }

                if(turnOption == "2")
                {
                    string guessedChar = Console.ReadLine().ToUpper();
                    var guessedBefore = CheckIfCharGuessed(guessedChar[0], gameData.previousGuesses);

                    if(guessedBefore)
                    {
                        // tell player to choose a char that hasn't been guessed yet
                        Console.WriteLine();
                    }
                    else
                    {
                        ShowFoundLetters(guessedChar[0], gameData.Answer, gameData.AnswerUnder);
                    }

                }


                // PLAYER CHOOSES TO GUESS A LETTER ----- OPTION 2
                string playerCharGuess = Console.ReadLine();
            }
        }



    }
}
