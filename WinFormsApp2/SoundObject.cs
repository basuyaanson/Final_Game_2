using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    class SoundObject
    {
        public static System.Media.SoundPlayer S_Click = new System.Media.SoundPlayer(Asset.click);
        public static System.Media.SoundPlayer S_Fire01 = new System.Media.SoundPlayer(Asset.Gun01);

    }
}
