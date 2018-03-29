using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    public class Wheel
    {
        LinkedList<string> wheel;
        uint Divisions;
        public Wheel(uint WheelDivisions)
        {
            Divisions = WheelDivisions;
            wheel = new LinkedList<string>();
            int x = -1;
            while (++x < WheelDivisions)
            {
                wheel.AddLast("Wheel division " + x);
            }
        }
        public void Print()
        {
            LinkedList<string>.Enumerator e = wheel.GetEnumerator();
            foreach (string v in wheel)
            {
                Console.WriteLine(v);
            }
        }
        public void Iterate()
        {
            int x = -1;
            try
            {
                while (++x < this.Divisions)
                {
                    var value = this.wheel.ElementAt(++x);
                    Console.WriteLine("testing: " + value);
                }
            }
            catch (SystemException)
            {
                Console.WriteLine("Opps, something done broke");
            }
        }
        public int PreSpinAnimation()
        {
            bool direction = true;
            int PowerBar = 0;
            Console.WriteLine("This is the pre-spin power animation. (Press Spacebar)");
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar))
            {
                PowerBar = this.DrawBar(PowerBar, direction);
                if (PowerBar == 20)
                    direction = false;
                else if (PowerBar == -1)
                    direction = true;
                System.Threading.Thread.Sleep(50);
            }
            Console.WriteLine();
            return (PowerBar);
        }
        private int DrawBar(int power, bool direction)
        {
            if (direction == true)
            {
                Console.Write("|");
                return (power + 1);
            }
            Console.Write("\b \b");
            return (power - 1);
        }
        public void SpinAnimation(int rotations)
        {
            List<List<string>> wheel = initWheel();
            int x = -1;
            int sleepValue = rotations + 30;
            int rotationDegredation = rotations;
            while (++x < rotations)
            {
                AnimateRotation(wheel, sleepValue, rotationDegredation);
                rotationDegredation--;
                sleepValue += (rotationDegredation * rotationDegredation) / 35;
            }
        }
        private void AnimateRotation(List<List<string>> wheel, int sleepValue, int rotations)
        {
            int x = -1;
            while (++x < wheel.Count)
            {
                int y = -1;
                while (++y < wheel[x].Count)
                {
                    Console.WriteLine(wheel[x][y]);
                }
                System.Threading.Thread.Sleep(sleepValue);
                Console.Clear();
            }
        }
        private List<List<string>> initWheel()
        {
            List<List<string>> blah = new List<List<string>>();
            blah.Add(new List<string>());
            int x = 0;
            blah[x].Add(" _____________________ ");
            blah[x].Add("|          *          |");
            blah[x].Add("|          *          |");
            blah[x].Add("|          *          |");
            blah[x].Add("|          0          |");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|_____________________|");
            x = 1;
            blah.Add(new List<string>());
            blah[x].Add(" _____________________ ");
            blah[x].Add("|                *    |");
            blah[x].Add("|              *      |");
            blah[x].Add("|            *        |");
            blah[x].Add("|          0          |");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|_____________________|");
            x++;
            blah.Add(new List<string>());
            blah[x].Add(" _____________________ ");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|          0  *  *  * |");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|_____________________|");
            x++;
            blah.Add(new List<string>());
            blah[x].Add(" _____________________ ");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|          0          |");
            blah[x].Add("|            *        |");
            blah[x].Add("|              *      |");
            blah[x].Add("|                *    |");
            blah[x].Add("|_____________________|");
            x++;
            blah.Add(new List<string>());
            blah[x].Add(" _____________________ ");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|          0          |");
            blah[x].Add("|          *          |");
            blah[x].Add("|          *          |");
            blah[x].Add("|          *          |");
            blah[x].Add("|_____________________|");
            x++;
            blah.Add(new List<string>());
            blah[x].Add(" _____________________ ");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|          0          |");
            blah[x].Add("|        *            |");
            blah[x].Add("|      *              |");
            blah[x].Add("|    *                |");
            blah[x].Add("|_____________________|");
            x++;
            blah.Add(new List<string>());
            blah[x].Add(" _____________________ ");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("| *  *  *  0          |");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|_____________________|");
            x++;
            blah.Add(new List<string>());
            blah[x].Add(" _____________________ ");
            blah[x].Add("|    *                |");
            blah[x].Add("|      *              |");
            blah[x].Add("|        *            |");
            blah[x].Add("|          0          |");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|                     |");
            blah[x].Add("|_____________________|");
            return (blah);
        }
        private void printWheel(List<string> wheel)
        {
            int x = -1;
            while (++x < wheel.Capacity)
            {
                Console.WriteLine(wheel[x]);
            }
        }
    }
}
