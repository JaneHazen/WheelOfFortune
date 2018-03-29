using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WheelOfFortune.Tests
{
    [TestClass]
    public class TestGatherGameData
    {
        string Answer;
        string AnswerUnder;
        string DisplayAnswerUnder;
        GatherGameData GameData;
        public void Init()
        {
            Answer = "Microsoft is awesome";
            AnswerUnder = new String('_', Answer.Length);
            DisplayAnswerUnder = "Puzzle is: " + AnswerUnder;
            GameData = new GatherGameData();
        }

        [TestMethod]
        public void TestGatherGameDataDefault()
        {
            Init();

            GatherGameData data = new GatherGameData();

            Assert.AreEqual(data.Answer, Answer);
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
            Init();

            GatherGameData data = new GatherGameData();

            data.DisplayUnderWordConsole();
        }


    }
}
