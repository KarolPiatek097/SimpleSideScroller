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
    public class Platform
    {
        public RectangleShape platform = new RectangleShape(new Vector2f(50, 50));
        

        public Platform(int xPosition, int yPosition)
        {
            platform.FillColor = Color.White;
            platform.OutlineColor = Color.Red;
            //platform.OutlineThickness = 1f;
            platform.Position = new Vector2f(xPosition*50, yPosition*50);
        }





    }
}
