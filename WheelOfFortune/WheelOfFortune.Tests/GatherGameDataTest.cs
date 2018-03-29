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
            Answer = "MICROSOFT IS AWESOME";
            AnswerUnder = new List<char>();
            DisplayAnswerUnder = "Puzzle is: " + AnswerUnder;

            foreach (char c in Answer)
            {
                if (c == ' ')
                    AnswerUnder.Add(' ');
                else
                    AnswerUnder.Add('_');
            }

            var sr = new StringReader("Jupiter");
            Console.SetIn(sr);
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
            Assert.AreEqual(AnswerUnder.ToString(), data.AnswerUnder.ToString());
        }

        [TestMethod]
        public void TestGetPlayerName()
        {
            //Arrange
            var expectedPlayerName = "Asawari";
            var sr = new StringReader("Jupiter");
            Console.SetIn(sr);
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
            var sr = new StringReader("Jupiter");
            Console.SetIn(sr);
            GatherGameData data = new GatherGameData();

            //Act
            var actualPlayerName = data.ParseInput("");
        }

        [TestMethod]
        public void TestDisplayPlayerName()
        {
            //Arrange
            var expectedOutput = "Please enter your name:\r\nPlayer Name: Jupiter \n\r\nPlayer Name: Jupiter \n\r\n";
            var sw = new StringWriter();
            Console.SetOut(sw);
            var sr = new StringReader("Jupiter");
            Console.SetIn(sr);
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

            var expectedOut = "Please enter your name:\r\nPlayer Name: Jupiter \n\r\nPuzzle is: " + Answer;
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
