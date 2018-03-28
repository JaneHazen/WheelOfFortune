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
            //arrange
            Init();

            //act
            var actual = GameData.Answer;

            //assert
            Assert.AreEqual(Answer, actual);
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
            var expectedOut = "Puzzle is: " + AnswerUnder;
            var sw = new StringWriter();
            Console.SetOut(sw);

            //act
            GameData.DisplayUnderWordConsole();

            //assert
            Assert.AreEqual(expectedOut, sw.ToString());
        }


    }
}
