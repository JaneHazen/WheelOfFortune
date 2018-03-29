using System;
using System.Collections.Generic; 
using System.IO;
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
            //Init();
            var answer = "Microsoft is awesome";

            //act
            GatherGameData data = new GatherGameData();

            //assert
            Assert.AreEqual(answer, data.Answer);
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
            GatherGameData data = new GatherGameData();

            //Act
            data.DisplayPlayerName();
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
            //GatherGameData.DisplayUnderWordConsole();

            //assert
            Assert.AreEqual(expectedOut, sw.ToString());
        }


    }
}
