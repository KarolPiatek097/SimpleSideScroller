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
    class Program
    {
        static void Main(string[] args)
        {

            var window = new RenderWindow(new VideoMode((uint)MyGlobals.width, (uint)MyGlobals.height), "Simple side scroller game", Styles.Default);

            window.SetFramerateLimit((uint)MyGlobals.frameRate);


            Player player = new Player();
            Level l1 = new Level();
            #region game over text
            Text gO = new Text("GAME OVER", new Font("Arial.ttf"));
            gO.CharacterSize = 100;
            gO.Color = Color.White;
            gO.Position = new Vector2f(MyGlobals.width / 2 - 300, MyGlobals.height / 2 - 100);
            #endregion

            #region you win text
            Text yW = new Text("YOU WIN!", new Font("arial.ttf"));
            yW.CharacterSize = 100;
            yW.Color = Color.White;
            yW.Position = new Vector2f(MyGlobals.width / 2 - 300, MyGlobals.height / 2 - 100);
            #endregion

            window.Closed += (s, a) => window.Close();
            window.KeyPressed += (s, a) => move(a.Code);
            window.KeyReleased += (s, a) =>
            {
                player.dir = Player.Direction.Default;
                player.velocity.X = 0;
            };
            while(window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear();
                if(!MyGlobals.gameOver && !MyGlobals.win)
                    update();
                draw();

                window.Display();
            }

            void draw()
            {
                foreach (var obj in l1.allObjectsList)
                    window.Draw(obj.platform);
                foreach (var obj in l1.allEnemiesList)
                    window.Draw(obj.enemy);
                window.Draw(l1.finish.finish);

                window.Draw(player.player);

                if(MyGlobals.gameOver)
                    window.Draw(gO);
                if (MyGlobals.win)
                    window.Draw(yW);

            }

            void move(SFML.Window.Keyboard.Key key)
            {
                switch (key)
                {
                    case Keyboard.Key.D:
                        player.dir = Player.Direction.Right;
                        player.velocity.X = -10;
                        break;
                    case Keyboard.Key.A:
                        player.dir = Player.Direction.Left;
                        player.velocity.X = 10;
                        break;
                    case Keyboard.Key.Space:
                        player.dir = Player.Direction.Jump;
                        player.jump();
                        break;
                    case Keyboard.Key.S:
                        break;
                }
                
            }

            void update()
            {
                l1.checkHorizontalPlayerCollision(player);

                if (!l1.checkHorizontalPlayerCollision(player))
                    player.applyGravity();

                foreach (var obj in l1.allObjectsList)
                {
                    
                    foreach (var obj2 in l1.allEnemiesList)
                        obj2.checkPlatformCollision(obj);
                    obj.platform.Position += player.velocity;
                }

                foreach (var obj in l1.allEnemiesList)
                {
                    obj.checkPlayerCollision(player);                        
                    obj.enemy.Position += obj.velocity + player.velocity;
                    
                }

                l1.finish.checkPlayerCollision(player);
                l1.finish.finish.Position += player.velocity;
            }

        }
    }
}
