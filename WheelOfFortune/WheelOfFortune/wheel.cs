using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    public class Wheel
    {

        //This Data structure was how I planned to represent the actual, physical wheel.
        LinkedList<string> wheel;
        //Divisions is used to represent the number of sections in the wheel.
        uint Divisions;
        public Wheel(uint WheelDivisions)
        {
            //This constructor makes our wheel with a user prescribed number of divisions.
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
            //Debugging code -- this prints out our linked list, just so we know it really exists and isn't having problems.
            LinkedList<string>.Enumerator e = wheel.GetEnumerator();
            foreach (string v in wheel)
            {
                Console.WriteLine(v);
            }
        }
        public void Iterate()
        {
            //This was an early method I was planning on using in conjunction with the wheel spin in order to simulate
            //a spinning wheel.
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
                //This was to prevent my broke ass wheel from slowing down my programming time with all sorts of exceptions. :)
                Console.WriteLine("Opps, something done broke");
            }
        }
        public int PreSpinAnimation()
        {
            //This is the beginning of the first major graphical animation method.
            bool direction = true;
            int PowerBar = 0;
            Console.WriteLine("This is the pre-spin power animation. (Press Spacebar)");
            //This while loop is the core of the animation.  Summary: we create a while loop who's ending condition
            //consists of a spacebar keypress.  During this while loop, the computer is going to check the direction bool
            //to see if it should print out a '|' key or a backspace.  So basically we are printing out a bunch of pike symbols
            //and then deleting them, over and over again.
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar))
            {
                PowerBar = this.DrawBar(PowerBar, direction);
                if (PowerBar == 20)
                    direction = false;
                else if (PowerBar == -1)
                    direction = true;
                //This reference to sleep is simply to prevent the computer from printing stuff out too fast (otherwise
                //the animation will look like a blur of text, rather than a sequence of frames.  :D
                System.Threading.Thread.Sleep(50);
            }
            Console.WriteLine();
            WheelOfFortune.WOFSound.WOFWheelSpin();
            return (PowerBar);
        }
        //DrawBar is a compartmentalization of functionality that resides in the PreSpinAnimation method.
        //I didn't want the aformentioned method getting too long and convoluted, so I dumped a bunch of lines
        //into this method.  DrawBar looks at the direction bool and decides if it should print out a '|' or
        //a backspace.  The return value acts as a count down so that, eventually, the direction will chance from
        //true to false.  This, in turn, will swap the character we are printing, back and forth, back and forth.
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
        //The spin animation is the biggest method in the wheel class.  Very simply, this method consists of a series
        //of while loops that print out a series of frames and clear the screen in between each frame.  The nitty gritty
        //of this method is a bit more complicated.
        public void SpinAnimation(int rotations)
        {
            //This variable 'wheel' contains a list of frames.  Technically speaking, we have an embedded list: each
            //frame consits of a list of strings, each string consists of one line of our animation image.
            //Init wheel simply adds all of this text into the data structure so that our subsequent while loops
            //can print it out.
            List<List<string>> wheel = initWheel();
            int x = -1;
            //This part of the code is where we can tweak values to fine tune our animation
            //Initially, the entire animation was too long, so I divided the rotation value by two to cut the time in half.
            rotations = rotations / 2;
            //Sleep value controls the time the computer sleeps after drawing a complete frame.  We want to gradually
            //increase this value so that we can simulate inertial degradation on the wheel.  I.E. when you throw the wheel,
            //initially, the wheel will spin fast, but over time it will slow down.
            int sleepValue = rotations + 30;
            int rotationDegredation = rotations;
            //This while loop is where we actually draw the animation.
            while (++x < rotations)
            {
                AnimateRotation(wheel, sleepValue, rotationDegredation);
                rotationDegredation--;
                sleepValue += 10;
            }
        }
        //This method is a comparmentalization of functionality within the SpinAnimation function.  I dumped it into this
        //sub method to keep the aformentioned method from ballooning into too many lines.
        //It's a very simple method that loops through our wheel data structure and prints out the entire series of frames.
        //Each time we invoke this method, we print out an entire rotation of the wheel.
        private void AnimateRotation(List<List<string>> wheel, int sleepValue, int rotations)
        {
            int x = -1;
            //This loop controls iterating through each frame in our data structure.
            while (++x < wheel.Count)
            {
                //This loop controls iterating through the individual lines of each frame.
                int y = -1;
                while (++y < wheel[x].Count)
                {
                    Console.WriteLine(wheel[x][y]);
                }
                //Sleep the computer for a small amount of time after we print out an entire frame of animation.
                System.Threading.Thread.Sleep(sleepValue);
                //Clear the screen so we are ready for the next frame of animation.
                Console.Clear();
            }
        }
        //This method initilizes our hard coded ascii animation.
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