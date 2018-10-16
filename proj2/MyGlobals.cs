using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace proj2
{
    public static class MyGlobals
    {
        public static bool gameOver = false;
        public static bool win = false;

        public static int width = 1920;
        public static int height = 1080;

        public static int frameRate = 60;
        public static Vector2f gravity = new Vector2f(0, 15f);

        

    }
}
