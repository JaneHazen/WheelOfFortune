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
        int            turn;
        uint[]         playerMoney;
        public GameLoop(GatherGameData Input)
        {
            this.turn = 0;
            gameData = Input;
            wheel = new Wheel(25);
            playerMoney = new uint[gameData.playerCount];
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
            if (check == false)
                previousGuesses.Add(guessedChar);
            return check;
        }

        public List<char> ShowFoundLetters(char guessedChar, string answer, List<char> underscoreTemplate)//pass in object to modify and word to find)
        {
            var characterCount = 0;

            // iterate through answer to see if char is included
            for (int i = 0; i < answer.Length; i++)
            {
                if (answer[i] == ' ')
                    continue;
                else if (this.gameData.previousGuesses.Contains(Char.ToLower(answer[i])))
                    Console.Write(answer[i]);
                else if (this.gameData.previousGuesses.Contains(Char.ToUpper(answer[i])))
                    Console.Write(answer[i]);
                else
                    Console.Write('_');
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
        //updatePlayerMoneyBags(this.turn, this.playerMoney, this.wheelRotations);
        public void updatePlayerMoneyBags(int turn, uint[] playerArray, uint quantity)
        {
            playerArray[turn] += quantity * 100;
            Console.WriteLine("\nDude!!!!!!!!!!!!!!!!...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("..." + this.gameData.playerNames[turn] + " just won...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("...like...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine((quantity * 100) + " dollars!!!!!!!");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();

        }
        public void DisplayMoneyBags()
        {
            Console.Write("Winnings: ");
            Console.Write(this.playerMoney[this.turn]);
            Console.WriteLine();
        }
        // MAIN GAMEPLAY LOOP
        public void GameplayLoop()
        {
            bool InfiniteLoop = true;
            // each iteration is a turn
            while (InfiniteLoop == true)
            {
                Console.Clear();
                this.gameData.DisplayPlayerName(this.turn);
                this.DisplayMoneyBags();
                this.wheelRotations = this.wheel.PreSpinAnimation();
                this.wheel.SpinAnimation(this.wheelRotations);
                Console.WriteLine("######################################################################\n");
                Console.WriteLine("Word to guess: \n");

                // Prints underscores for puzzle
                WheelOfFortune.WOFSound.WOFPuzzleReveal();
                int x = -1;
                while (++x < this.gameData.Answer.Length)
                {
                    if (this.gameData.Answer[x] == ' ')
                        Console.Write(' ');
                    else if (this.gameData.previousGuesses.Contains(Char.ToLower(this.gameData.Answer[x])))
                        Console.Write(this.gameData.Answer[x]);
                    else if (this.gameData.previousGuesses.Contains(Char.ToUpper(this.gameData.Answer[x])))
                        Console.Write(this.gameData.Answer[x]);
                    else
                        Console.Write('_');
                    Console.Write(' ');
                }
                Console.WriteLine();

                // Displey options for turn
                Console.WriteLine("");
                Console.WriteLine(" 0 to quit the game \n 1 to solve the puzzle \n 2 guess a letter \n\n");
                this.gameData.DisplayPlayerName(this.turn);
                this.DisplayMoneyBags();
                string turnOption = Console.ReadLine();


                // QUITS THE GAME
                if (String.IsNullOrEmpty(turnOption))
                {
                    Console.WriteLine("Trying to pass me some null input, eh?");
                    continue;
                }
                else if (turnOption[0] == '0')
                {
                    InfiniteLoop = false;
                }

                // GUESS COMPLETE WORD
                else if (turnOption[0] == '1')
                {
                    bool winner = AnswerCheck(gameData.Answer, gameData.winner);

                    if (winner == true)
                    {
                        gameData.winner = true;
                        InfiniteLoop = false;
                    }
                }

                // GUESS A LETTER
                else if (turnOption[0] == '2')
                {
                    Console.WriteLine("Enter a letter to guess:");
                    string guessedChar = Console.ReadLine().ToUpper();

                    if (guessedChar.Length == 1 && Char.IsLetter(guessedChar[0]))
                    {
                        bool guessedBefore = CheckIfCharGuessed(guessedChar[0], gameData.previousGuesses);
                        if (guessedBefore)
                        {
                            // tell player to choose a char that hasn't been guessed yet
                            Console.WriteLine("That letter has already been guessed \n");
                            continue;
                        }
                        else
                        {
                            //ShowFoundLetters(guessedChar[0], gameData.Answer, gameData.AnswerUnder);
                            this.updatePlayerMoneyBags(this.turn, this.playerMoney, (uint)this.wheelRotations);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a vaild letter \n");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Please choose 0 1 or 2 only.");
                    continue;
                }
                this.turn++;
                if (this.turn == this.gameData.playerCount)
                    this.turn = 0;
                Console.Clear();
            }

            if(gameData.winner == true)
                Console.WriteLine("\r\n  _    _                                                                         _ \r\n | |  | |                                                                       | |\r\n | |__| | ___   ___  _ __ __ _ _   _     _   _  ___  _   _  __      _____  _ __ | |\r\n |  __  |/ _ \\ / _ \\| '__/ _` | | | |   | | | |/ _ \\| | | | \\ \\ /\\ / / _ \\| '_ \\| |\r\n | |  | | (_) | (_) | | | (_| | |_| |_  | |_| | (_) | |_| |  \\ V  V / (_) | | | |_|\r\n |_|  |_|\\___/ \\___/|_|  \\__,_|\\__, ( )  \\__, |\\___/ \\__,_|   \\_/\\_/ \\___/|_| |_(_)\r\n                                __/ |/    __/ |                                    \r\n                               |___/     |___/ ");
            if(gameData.winner == false)
                Console.WriteLine("\r\n _____                 _        _                _ \r\n|  __ \\               | |      | |              | |\r\n| |  \\/ ___   ___   __| |______| |__  _   _  ___| |\r\n| | __ / _ \\ / _ \\ / _` |______| '_ \\| | | |/ _ \\ |\r\n| |_\\ \\ (_) | (_) | (_| |      | |_) | |_| |  __/_|\r\n \\____/\\___/ \\___/ \\__,_|      |_.__/ \\__, |\\___(_)\r\n                                       __/ |       \r\n                                      |___/ ");

            ExitGame();
        }
    }
}
