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
            GatherGameData Input = new GatherGameData();
            GameLoop Loop = new GameLoop(Input);
            AnnounceWinner Winner = new AnnounceWinner(Loop);
            Console.WriteLine("End of game");
            Console.WriteLine();
        }
    }
}
