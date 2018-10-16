using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.IO;
namespace proj2
{
    public class Level
    {
        public int[,] allObjects = new int[22,500];
        public Finish finish;
        public List<Platform> allObjectsList = new List<Platform>();
        public List<Enemy> allEnemiesList = new List<Enemy>();

        public List<string> level = File.ReadAllLines(@"Level.txt").ToList();

        public Level()
        {
            generatePlatforms();
        }

        void generatePlatforms()
        {
            for(int i =0; i<22;i++)
            {
                for(int j = 0; j<500;j++)
                {
                    if(level[i][j] == '1')
                    {
                        allObjectsList.Add(new Platform(j, i));
                    }

                    if(level[i][j] == '2')
                    {
                        allEnemiesList.Add(new Enemy(j, i));
                    }

                    if(level[i][j] == '3')
                    {
                        finish = new Finish(j, i);
                    }

                }
            }
        }

        public void displayLevel()
        {
            for (int i = 0; i < 22; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    Console.Write(level[i][j]);
                }
                Console.WriteLine("");
            }

        }


        

        public bool checkHorizontalPlayerCollision(Player player)
        {
            bool doesCollide = false;

            foreach(var obj in allObjectsList)
            {
                if(player.player.Position.X <= obj.platform.Position.X +50 &&
                   player.player.Position.X >= obj.platform.Position.X &&
                   player.player.Position.Y +50 >= obj.platform.Position.Y &&
                   player.player.Position.Y + 2<= obj.platform.Position.Y+50)
                {
                    if (player.dir == Player.Direction.Left)
                        player.velocity.X = 0;
                }

                if (player.player.Position.X +50 >= obj.platform.Position.X &&
                    player.player.Position.X < obj.platform.Position.X +50&&
                    player.player.Position.Y + 50 >= obj.platform.Position.Y &&
                    player.player.Position.Y +2 <= obj.platform.Position.Y + 50)
                {
                    if (player.dir == Player.Direction.Right)
                        player.velocity.X = 0;
                }

                if (player.player.Position.Y + 51 >= obj.platform.Position.Y &&
                    player.player.Position.Y <= obj.platform.Position.Y + 50 &&
                    player.player.Position.X + 48 >= obj.platform.Position.X &&
                    player.player.Position.X + 2 <= obj.platform.Position.X + 50)
                {

                    if(player.player.Position.Y + 50 > obj.platform.Position.Y &&
                       player.player.Position.Y + 50 < obj.platform.Position.Y +25)
                    {
                        player.player.Position = new Vector2f(player.player.Position.X, obj.platform.Position.Y - 51);
                    }

                    if (player.dir != Player.Direction.Jump)
                    {
                        player.velocity.Y = 0;
                        doesCollide = true;
                    }
                }

                if (player.player.Position.Y <= obj.platform.Position.Y + 45 &&
                    player.player.Position.Y + 50 >= obj.platform.Position.Y &&
                    player.player.Position.X + 48 >= obj.platform.Position.X &&
                    player.player.Position.X + 2 <= obj.platform.Position.X + 50)
                {
                    if (player.player.Position.Y <= obj.platform.Position.Y + 50 &&
                        player.player.Position.Y + 50 >= obj.platform.Position.Y + 25)
                    {
                        player.player.Position = new Vector2f(player.player.Position.X, obj.platform.Position.Y + 51);

                    }


                    if (player.dir == Player.Direction.Jump)
                        player.velocity.Y = 0;
                }

            }

            return doesCollide;

        }

    }
}
