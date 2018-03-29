using System;
using System.IO;
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
            bool check = false;
            check = previousGuesses.Contains(guessedChar);
            previousGuesses.Add(guessedChar);

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
                Console.WriteLine($"There is/are {characterCount} letter {guessedChar} in the puzzle \n");
            }
            else
            {
                Console.Write("Sorry, guess again \n");
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

        // MAIN GAMEPLAY LOOP
        public void GameplayLoop()
        {
            bool InfiniteLoop = true;

            // each iteration is a turn
            while (InfiniteLoop == true)
            {

                Console.WriteLine("######################################################################\n");
                Console.WriteLine("Word to guess:");
                string underscores = string.Join(" ", gameData.AnswerUnder.ToArray());
                Console.WriteLine(underscores);

                Console.WriteLine("");
                Console.WriteLine(" 0 to quit the game \n 1 to solve the puzzle \n 2 guess a letter \n\n");

                string turnOption = Console.ReadLine();

                // quit the game
                if(turnOption == "0")
                {
                    // quit game
                    InfiniteLoop = false;
                }

                // GUESS COMPLETE WORD
                if(turnOption == "1")
                {
                    bool winner = AnswerCheck(gameData.Answer);

                    if(winner == true)
                    {
                        InfiniteLoop = false;
                    }
                }

                // GUESS A LETTER
                if(turnOption == "2")
                {
                    Console.WriteLine("Enter a letter to guess:");
                    string guessedChar = Console.ReadLine().ToUpper();

                    if(guessedChar.Length == 1 || Char.IsLetter(guessedChar[0]))
                    {
                        var guessedBefore = CheckIfCharGuessed(guessedChar[0], gameData.previousGuesses);

                        if(guessedBefore)
                        {
                            // tell player to choose a char that hasn't been guessed yet
                            Console.WriteLine("That letter has already been guessed \n");
                        }
                        else
                        {
                            ShowFoundLetters(guessedChar[0], gameData.Answer, gameData.AnswerUnder);
                        }

                    } else
                    {
                        Console.WriteLine("Please enter a vaild letter \n");
                    }


                }
            }

            //Console.WriteLine("Hooray, you won!");
            Console.WriteLine("Would you like to play agian? (y/n) \n");
            string playAgain = Console.ReadLine();

        }
    }
}
