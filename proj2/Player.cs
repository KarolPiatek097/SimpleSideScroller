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
    public class Player
    {
        public RectangleShape player = new RectangleShape(new Vector2f(50, 50));
        public Vector2f velocity = new Vector2f(0,1);

        public int bounceHeight = 21;
        public float inAirTime = 0;
        public Vector2f gravity = new Vector2f(0, 1f);

        public enum Direction { Default,Left, Right, Jump};
        public Direction dir = Direction.Default;

        public Player()
        {
            player.Position = new Vector2f(MyGlobals.width/2, 947);
            player.FillColor = Color.Green;

        }

        public void jump()
        {
            velocity.Y = bounceHeight;
        }

        public void applyGravity()
        {
            inAirTime += 0.2f;

            if (inAirTime >= 0.6f)
                inAirTime = 0.6f;

            double velMultTime = Math.Round(velocity.Y * inAirTime);

            velocity.Y -= (float)Math.Round(gravity.Y * inAirTime);


        }

    }
}
