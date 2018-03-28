using System;
using System.Collections.Generic;

namespace WheelOfFortune
{
    public class GameLoop
    {
        GatherGameData gameData;
        // Checks if character has already been guessed
        public bool CheckIfCharGuessed(string charGuess, List<string> previousGuesses)
        {
            var check = previousGuesses.Contains(charGuess);

            return check;
        }

    
	
    //*************
    public bool AnswerCheck()
    {
        Console.WriteLine("To solve the puzzle, type your answer and press enter:");
        var fullAnswerGuess = Console.ReadLine().ToString().ToUpper();
        if (fullAnswerGuess == gameData.Answer.ToUpper())
        {
            Console.WriteLine("hooray, you win!");
            return true;
        }
        Console.WriteLine("try again!");
        //Give user the choices again (0 quit, 1 solve, 2 spin);
        return false;
    }
    //*************
    public void Loop()
        {
            bool InfiniteLoop = true;
            while (InfiniteLoop == true)
            {
                this.AnswerCheck();
            }
            
        }
    public GameLoop(GatherGameData gameData)
        {
            // PLAYER CHOOSES TO GUESS A LETTER ----- OPTION 2
            string playerCharGuess = Console.ReadLine();
            this.gameData = gameData;


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

        }

        public string ShowFoundLetters(string guessedChar, string answer, string underscoreTemplate)//pass in object to modify and word to find)
        {  
         var characterCount = 0;

        // iterate through answer to see if char is included

        for (int i = 0; i < answer; i++)
            {
            if (answer[i] == guessedChar)
            {
                characterCount++;
                //replace letter 
                underscoreTemplate[i] = guessedChar;
                //remember to verify that guessedChar has upcase 
            }  

            }
        return underscoreTemplate;

            // if char hasn't been guessed before
        }
    }
}
