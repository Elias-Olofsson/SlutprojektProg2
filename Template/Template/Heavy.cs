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
    class Heavy : GameObject //klassen ärver från GameObjekt
    {
        Vector2 lastMove;
        Player player;
        public Heavy(Texture2D texture, Vector2 pos, Point point, Player player) : base(texture, pos, point) //olika grejer som heavy ska ha
        {
            this.player = player;
        }
        public override void Update()
        {
            if (Player.behavior == PlayerBehavior.Heavy)
            {
                KeyboardState kstate = Keyboard.GetState(); //läser om någon knapp trycks in
                if (kstate.IsKeyDown(Keys.W) || kstate.IsKeyDown(Keys.A) || kstate.IsKeyDown(Keys.S) || kstate.IsKeyDown(Keys.D))
                {
                    if (kstate.IsKeyDown(Keys.W))
                    {
                        rectangle.Size = new Point(4, 20);
                        pos.X = player.Rectangle.Location.X + 21;
                        pos.Y = player.Rectangle.Location.Y;
                        lastMove.Y -= 2;
                    }
                    else if (kstate.IsKeyDown(Keys.A))
                    {
                        rectangle.Size = new Point(20, 4);
                        pos.X = player.Rectangle.Location.X;
                        pos.Y = player.Rectangle.Location.Y;
                        lastMove.X -= 2;

                    }
                    else if (kstate.IsKeyDown(Keys.D))
                    {
                        rectangle.Size = new Point(20, 4);
                        pos.X = player.Rectangle.Location.X + 5;
                        pos.Y = player.Rectangle.Location.Y + 21;
                        lastMove.X += 2;
                    }
                    else if (kstate.IsKeyDown(Keys.S))
                    {
                        rectangle.Size = new Point(4, 20);
                        pos.X = player.Rectangle.Location.X;
                        pos.Y = player.Rectangle.Location.Y + 5;
                        lastMove.Y += 2;
                    }
                }
                base.Update();
            }
        }
    }
}
