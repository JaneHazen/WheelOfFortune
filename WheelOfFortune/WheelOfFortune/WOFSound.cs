using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace WheelOfFortune
{

    public class WOFSound
    {
        static string fullPath = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
        static string dir = System.IO.Path.GetDirectoryName(fullPath).Substring(6);
        static string soundsDir = dir + "\\Sounds";

        public static void WOFChant()
        {
            var WOFPlayer = new System.Media.SoundPlayer();
            WOFPlayer.SoundLocation = soundsDir + "\\WOF_Chant.wav";
            Task.Run(() => WOFPlayer.PlaySync());
        }
        public static void WOFTheme()
        {
            var WOFPlayer = new System.Media.SoundPlayer();
            WOFPlayer.SoundLocation = soundsDir + "\\WOF_Opening_Theme.wav";
            Task.Run(() => WOFPlayer.PlaySync());
        }
        public static void WOFPuzzleReveal()
        {
            var WOFPlayer = new System.Media.SoundPlayer();
            WOFPlayer.SoundLocation = soundsDir + "\\PUZZLE-REVEAL.wav";
            Task.Run(() => WOFPlayer.PlaySync());
        }
        public static void WOFWheelSpin()
        {
            var WOFPlayer = new System.Media.SoundPlayer();
            WOFPlayer.SoundLocation = soundsDir + "\\wheel_spin.wav";
            Task.Run(() => WOFPlayer.PlaySync());
        }
    }
}
