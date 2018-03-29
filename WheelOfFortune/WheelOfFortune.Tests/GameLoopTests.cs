using System;
using System.Collections.Generic;
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
            List<char> list = new List<char> { 'a', 'b', 'c', 'c' };
            char guess1 = 'b';
            char guess2 = 's';

            // Act
            GameLoop loop = new GameLoop(null);
            var checkTrue = loop.CheckIfCharGuessed(guess1, list);
            var checkFalse = loop.CheckIfCharGuessed(guess2, list);

            // Assert
            Assert.IsTrue(checkTrue);
            Assert.IsFalse(checkFalse);
        }

        //[TestMethod]
        //public void TestGameplayLoopOption1()
        //{

        //    // Arrange
        //    var expected = "1";
        //    var sr = new StringReader(expected);
        //    Console.SetIn(sr);

        //    GatherGameData data = new GatherGameData();
        //    GameLoop loop = new GameLoop(data);

        //    // Act
        //    loop.GameplayLoop();

        //    // Assert
        //    Assert.AreEqual(expected, sr.ToString());


        //}

    }
}
