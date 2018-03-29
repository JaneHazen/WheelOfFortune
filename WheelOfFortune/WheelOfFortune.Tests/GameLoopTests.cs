using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WheelOfFortune.Tests
{
    [TestClass]
    public class GameLoopTests
    {
        [TestMethod]
        public void TestCheckIfCharGuessed()
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

    }
}
