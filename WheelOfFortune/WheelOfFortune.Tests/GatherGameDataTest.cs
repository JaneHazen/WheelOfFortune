using System;
using System.IO;
using System.Collections.Generic; 
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WheelOfFortune.Tests
{
    [TestClass]
    public class TestGatherGameData
    {
        string Answer;
        List<char> AnswerUnder;
        string DisplayAnswerUnder;
        public void Init()
        {
            Answer = "Microsoft is awesome";
            AnswerUnder = new List<char>();
            DisplayAnswerUnder = "Puzzle is: " + AnswerUnder;
        }

        [TestMethod]
        public void TestGatherGameDataDefault()
        {
            //arrange
            Init();

            //act
            GatherGameData data = new GatherGameData();

            //assert
            Assert.AreEqual(Answer, data.Answer);
        }

        [TestMethod]
        public void TestGetPlayerName()
        {
            //Arrange
            var expectedPlayerName = "Asawari";
            GatherGameData data = new GatherGameData();

            //Act
            var actualPlayerName = data.ParseInput("Asawari");

            //Assert
            Assert.AreEqual(expectedPlayerName, actualPlayerName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetPlayerNameInputValidation()
        {
            //Arrange
            GatherGameData data = new GatherGameData();

            //Act
            var actualPlayerName = data.ParseInput("");
        }

        [TestMethod]
        public void TestDisplayPlayerName()
        {
            //Arrange
            var expectedOutput = "Player Name : Jupiter\r\n";
            var sw = new StringWriter();
            Console.SetOut(sw);
            GatherGameData data = new GatherGameData();
            data.PlayerName = "Jupiter";

            //Act
            data.DisplayPlayerName();

            //Assert
            Assert.AreEqual(expectedOutput, sw.ToString());
               
        }

        [TestMethod]
        public void TestDisplayUnderWordConsole()
        {   
            //arrange
            Init();
            foreach (char c in Answer)
            {
                AnswerUnder.Add(c);
            }

            var expectedOut = "Starting the game...\r\nPuzzle is: " + Answer;
            var sw = new StringWriter();
            Console.SetOut(sw);
            GatherGameData data = new GatherGameData();

            //act
            data.DisplayUnderWordConsole();

            //assert
            Assert.AreEqual(expectedOut, sw.ToString());
        }


    }
}
