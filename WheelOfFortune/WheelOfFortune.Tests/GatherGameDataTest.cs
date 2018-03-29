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
        public void Init()
        {
            Answer = "Microsoft is awesome";
            AnswerUnder = new String('_', Answer.Length);
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
            string input = $"Puzzle is: {AnswerUnder}";
            var expectedOut = $"Puzzle is: {AnswerUnder}\r\n";
            var sw = new StringWriter();
            Console.SetOut(sw);

            //act
            GatherGameData data = new GatherGameData();
            data.DisplayUnderWordConsole();

            //assert
            Assert.AreEqual(expectedOut, sw.ToString());
        }


    }
}
