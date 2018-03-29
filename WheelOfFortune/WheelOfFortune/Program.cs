using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace WheelOfFortune
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            GatherGameData Input = new GatherGameData();
            GameLoop Loop = new GameLoop(Input);
            Loop.GameplayLoop();
            AnnounceWinner Winner = new AnnounceWinner(Loop);
            Console.WriteLine("End of game");
            Console.ReadLine();
        }
    }
}
