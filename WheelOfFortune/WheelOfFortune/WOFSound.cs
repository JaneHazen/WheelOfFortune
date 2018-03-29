using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace WheelOfFortune
{
    class WOFSound
    {
        public void WOFChant()
        {
            var WOFPlayer = new System.Media.SoundPlayer();
            WOFPlayer.SoundLocation = @"https://ccperalta-my.sharepoint.com/:u:/g/personal/brgi2317_cc_peralta_edu/EcFZNbWv5jNLrVMSh0m6d9kBeaVDb9jLn6_rfcGa31e13w?e=Qbf41G";
            WOFPlayer.PlaySync();
        }
        public void WOFTheme()
        {
            var WOFPlayer = new System.Media.SoundPlayer();
            WOFPlayer.SoundLocation = @"https://ccperalta-my.sharepoint.com/:u:/g/personal/brgi2317_cc_peralta_edu/EestiFeYt81GsVygMI9arpwBPKEUmze4FUCHeTF-bh9xYQ?e=mO7aXp";
            WOFPlayer.PlaySync();
        }
        public void WOFPuzzleReveal()
        {
            var WOFPlayer = new System.Media.SoundPlayer();
            WOFPlayer.SoundLocation = @"https://ccperalta-my.sharepoint.com/:u:/g/personal/brgi2317_cc_peralta_edu/ESNnbSOJtdRCh-ZRysRdTW4BevdWlG4VqmO9jtyyVeYb1w?e=hSTAZf";
            WOFPlayer.PlaySync();
        }
        public void WOFWheelSpin()
        {
            var WOFPlayer = new System.Media.SoundPlayer();
            WOFPlayer.SoundLocation = @"https://ccperalta-my.sharepoint.com/:u:/g/personal/brgi2317_cc_peralta_edu/EQUYOAB-pJxOs7Yq0Q0ztjwBp4Zty7CELe48rnd8VsibVQ?e=LdwG2r";
            WOFPlayer.PlaySync();
        }
    }
}
