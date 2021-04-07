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
        Player player;
        public Light(Texture2D texture, Vector2 pos, Point point, Player player) : base(texture, pos, point) //olika grejer som light ska ha
        {
            this.player = player;
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
                        pos.Y = player.Rectangle.Location.Y;
                        rectangle.Size = new Point(4,12);
                        lastMove.Y -= 2;
                    }
                    else if (kstate.IsKeyDown(Keys.A))
                    {
                        pos.X = player.Rectangle.Location.X;
                        lastMove.X -= 2;
                        
                    }
                    else if (kstate.IsKeyDown(Keys.D))
                    {
                        pos.X += 2;
                        lastMove.X += 2;
                    }
                    else if (kstate.IsKeyDown(Keys.S))
                    {
                        pos.Y += 2;
                        lastMove.Y += 2;
                    }
                }
            }
                base.Update();
        }
    }
}
