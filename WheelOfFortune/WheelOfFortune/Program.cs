using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    public class Program
    {
        static void Main(string[] args)
        {
            GatherGameData test = new GatherGameData();
            GameLoop testLoop = new GameLoop(test);
            testLoop.AnswerCheck();
            Console.WriteLine();
        }


    }
}
