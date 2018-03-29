using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WheelOfFortune.Tests
{
    [TestClass]
    public class GameLoopTests
    {
        //[TestMethod]
        //public void TestCheckIfCharGuessed()
        //{
        //    // Arrange
        //    string[] arr = new string[4] { "a", "b", "c", "d" };
        //    string guess = "b";

        //    // Act
            
        //}

        [TestMethod]
        public void TestAnswerCheck()
        {
            // Arrange
            GameLoop loop = new GameLoop(null);
            var input = "microsoft is awesome";
            var expectedGameLoop = false;

            // Act
            var actualGameLoop = loop.AnswerCheck("microsoft is awesome");
            var sr = new StringReader(input);
            Console.SetIn(sr);

            // Assert
            Assert.AreEqual(expectedGameLoop, actualGameLoop);
        }


    }
}
