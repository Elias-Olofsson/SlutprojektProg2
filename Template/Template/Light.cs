using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Light : GameObject //klassen ärver från GameObjekt
    {
        Vector2 lastMove;
        int lastKey;
        Player player;
        Texture2D bulletTex;
        public Light(Texture2D texture, Texture2D bulletTex, Vector2 pos, Point point, Player player) : base(texture, pos, point) //olika grejer som light ska ha
        {
            this.player = player;
            this.bulletTex = bulletTex;
        }

        public override void Update()
        {
            if (Player.behavior == PlayerBehavior.Light)
            {
                KeyboardState kstate = Keyboard.GetState(); //läser om någon knapp trycks in
                if (kstate.IsKeyDown(Keys.W) || kstate.IsKeyDown(Keys.A) || kstate.IsKeyDown(Keys.S) || kstate.IsKeyDown(Keys.D))
                {
                    if (kstate.IsKeyDown(Keys.W))
                    {
                        rectangle.Size = new Point(4,12);
                        pos.X = player.Rectangle.Location.X+21;
                        pos.Y = player.Rectangle.Location.Y;
                        lastMove.Y -= 2;
                        int lastKey = 1;
                    }
                    else if (kstate.IsKeyDown(Keys.A))
                    {
                        rectangle.Size = new Point(12, 4);
                        pos.X = player.Rectangle.Location.X;
                        pos.Y = player.Rectangle.Location.Y;
                        lastMove.X -= 2;
                        int lastKey = 2;
                    }
                    else if (kstate.IsKeyDown(Keys.D))
                    {
                        rectangle.Size = new Point(12, 4);
                        pos.X = player.Rectangle.Location.X+13;
                        pos.Y = player.Rectangle.Location.Y+21;
                        lastMove.X += 2;
                        int lastKey = 3;
                    }
                    else if (kstate.IsKeyDown(Keys.S))
                    {
                        rectangle.Size = new Point(4, 12);
                        pos.X = player.Rectangle.Location.X;
                        pos.Y = player.Rectangle.Location.Y+13;
                        lastMove.Y += 2;
                        int lastKey = 4;
                    }
                }
                while(lastKey == 1){
                    while (kstate.IsKeyDown(Keys.Space)) {
                        bullet = new Bullet(bulletTex, new Vector2(10, 10), new Point(25, 25));
                    }
                }
            }
                base.Update();
        }
    }
}
