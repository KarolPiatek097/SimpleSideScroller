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
    public class Enemy
    {
        public RectangleShape enemy = new RectangleShape(new Vector2f(50, 50));
        public Vector2f velocity = new Vector2f(5, 0);

        public enum Direction {Left, Right};
        public Direction dir = Direction.Right;
        int dirSign = 1;
        public Enemy(int positionX, int positionY)
        {
            enemy.FillColor = Color.Red;
            enemy.Position = new Vector2f(positionX * 50, positionY * 50);
        }

        public bool checkPlatformCollision(Platform platform)
        {
            bool doesCollide = false;
        
            if ((enemy.Position.X + 50 >= platform.platform.Position.X &&
                enemy.Position.X + 50 <= platform.platform.Position.X +25 &&
                enemy.Position.Y +10 >= platform.platform.Position.Y &&
                enemy.Position.Y + 40 <= platform.platform.Position.Y + 50 &&
                dir == Direction.Right) ||
                (enemy.Position.X <= platform.platform.Position.X +50  &&
                enemy.Position.X >= platform.platform.Position.X + 25 &&
                enemy.Position.Y + 10 >= platform.platform.Position.Y &&
                enemy.Position.Y + 40 <= platform.platform.Position.Y + 50 && dir == Direction.Left))
            {
                doesCollide = true;
                velocity.X *= -1;
                dirSign *= -1;
                dir += dirSign;
            }

            return doesCollide;

        }

        public bool checkPlayerCollision(Player player)
        {
            bool doesCollide = false;

            if (enemy.GetGlobalBounds().Intersects(player.player.GetGlobalBounds()))
            {
                doesCollide = true;
                MyGlobals.gameOver = true;

            }
            return doesCollide;
        }

    }
}
