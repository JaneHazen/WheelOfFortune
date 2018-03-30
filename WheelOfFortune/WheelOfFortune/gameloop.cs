using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Timers;

namespace WheelOfFortune
{
    public class GameLoop
    {
        GatherGameData gameData;
        Wheel          wheel;
        int            wheelRotations;
        public GameLoop(GatherGameData Input)
        {
            gameData = Input;
            wheel = new Wheel(25);
        }

        // waits 3 seconds before closing the terminal
        public void ExitGame()
        {
            bool wait = true;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            while(wait)
            {
                if (sw.ElapsedMilliseconds > 3000)
                    wait = false;
            }
            Environment.Exit(0);
        }

        // Checks if character has already been guessed
        public bool CheckIfCharGuessed(char guessedChar, List<char> previousGuesses)
        {
            // checks if letter has already been guessed
            bool check = previousGuesses.Contains(guessedChar);
            // adds letter to list of guesses
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

            // Display the appropriate string based off the characterCount
            if(characterCount > 0)
                Console.WriteLine($"There is/are {characterCount} letter {guessedChar} in the puzzle \n");
            else
                Console.Write("Sorry, guess again \n");

            return underscoreTemplate;
        }

        public bool AnswerCheck(string answer, bool winner)
        {
            Console.WriteLine("To solve the puzzle, type your answer and press enter:");
            var fullAnswerGuess = Console.ReadLine().ToString().ToUpper();
            if (fullAnswerGuess == answer.ToUpper())
            {
                return true;
            }            
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
                this.wheelRotations = this.wheel.PreSpinAnimation();
                this.wheel.SpinAnimation(this.wheelRotations);
                Console.WriteLine("######################################################################\n");
                Console.WriteLine("Word to guess: \n");

                // Prints underscores for puzzle
                WheelOfFortune.WOFSound.WOFPuzzleReveal();
                foreach (char letter in gameData.AnswerUnder)
                {
                    Console.Write(letter);
                    Console.Write(" ");
                }
                Console.WriteLine("\n");

                // Displey options for turn
                Console.WriteLine("");
                Console.WriteLine(" 0 to quit the game \n 1 to solve the puzzle \n 2 guess a letter \n\n");
                string turnOption = Console.ReadLine();
              
        

                if(turnOption != "0" || turnOption != "1" || turnOption != "2")
                {
                    Console.WriteLine("Please enter a valid option");
                }

                // QUITS THE GAME
               if (turnOption == "0")
                {
                    InfiniteLoop = false;
                }

                // GUESS COMPLETE WORD
                if(turnOption == "1")
                {
                    bool winner = AnswerCheck(gameData.Answer, gameData.winner);

                    if(winner == true)
                    {
                        gameData.winner = true;
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
                else
                {
                    Console.WriteLine("Please choose 0 1 or 2 only.");
                }
            }

            if(gameData.winner == true)
                Console.WriteLine("\r\n  _    _                                                                         _ \r\n | |  | |                                                                       | |\r\n | |__| | ___   ___  _ __ __ _ _   _     _   _  ___  _   _  __      _____  _ __ | |\r\n |  __  |/ _ \\ / _ \\| '__/ _` | | | |   | | | |/ _ \\| | | | \\ \\ /\\ / / _ \\| '_ \\| |\r\n | |  | | (_) | (_) | | | (_| | |_| |_  | |_| | (_) | |_| |  \\ V  V / (_) | | | |_|\r\n |_|  |_|\\___/ \\___/|_|  \\__,_|\\__, ( )  \\__, |\\___/ \\__,_|   \\_/\\_/ \\___/|_| |_(_)\r\n                                __/ |/    __/ |                                    \r\n                               |___/     |___/ ");
            if(gameData.winner == false)
                Console.WriteLine("\r\n _____                 _        _                _ \r\n|  __ \\               | |      | |              | |\r\n| |  \\/ ___   ___   __| |______| |__  _   _  ___| |\r\n| | __ / _ \\ / _ \\ / _` |______| '_ \\| | | |/ _ \\ |\r\n| |_\\ \\ (_) | (_) | (_| |      | |_) | |_| |  __/_|\r\n \\____/\\___/ \\___/ \\__,_|      |_.__/ \\__, |\\___(_)\r\n                                       __/ |       \r\n                                      |___/ ");

            ExitGame();
        }
    }
}
