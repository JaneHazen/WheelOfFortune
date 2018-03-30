using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WheelOfFortune.Tests
{
    
    [TestClass]
    public class GameLoopTests
    {
        [TestMethod]
        public void TestCheckIfAdamIsAwesome()
        {
            //Arrange

            bool expected = true;
            bool actual = true;

            //Act
            Assert.AreEqual(expected, actual);
        }
    }
}
