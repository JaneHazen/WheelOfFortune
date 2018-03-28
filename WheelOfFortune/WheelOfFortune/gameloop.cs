using System;

public class GameLoop
{
	public GameLoop(object gameData)
	{

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

    }

}
