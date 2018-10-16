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
    public class Finish
    {
        public RectangleShape finish = new RectangleShape(new Vector2f(50, 50));


        public Finish(int positionX, int positionY)
        {
            finish.FillColor = Color.Magenta;
            finish.Position = new Vector2f(positionX*50, positionY*50);
        }

        public bool checkPlayerCollision(Player player)
        {
            bool doesCollide = false;

            if (finish.GetGlobalBounds().Intersects(player.player.GetGlobalBounds()))
            {
                doesCollide = true;
                MyGlobals.win = true;

            }
            return doesCollide;
        }
    }
}
