using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    class Program
    {
        static GatherGameData gameData = new GatherGameData();

        static void Main(string[] args)
        {
        }

        public static void GetPlayerName()
        {
            Console.WriteLine("Please enter your name:");
            gameData.playerName = Console.ReadLine();
        }

    }
}
