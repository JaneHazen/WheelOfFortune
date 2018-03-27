using System;
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
        public void TestDisplayUnderWordConsole()
        {
            Init();

            GatherGameData data = new GatherGameData();

            data.DisplayUnderWordConsole();
        }
    }
}
