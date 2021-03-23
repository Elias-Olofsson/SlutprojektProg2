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
        public Light(Texture2D texture, Vector2 pos, Point point) : base(texture, pos, point) //olika grejer som light ska ha
        {

        }

        public override void Update()
        {
            if (Player.behavior == PlayerBehavior.Light)
            {
                KeyboardState kstate = Keyboard.GetState(); //läser om någon knapp trycks in
                if (kstate.IsKeyDown(Keys.W) || kstate.IsKeyDown(Keys.A) || kstate.IsKeyDown(Keys.S) || kstate.IsKeyDown(Keys.D))
                {

                }
            }
                base.Update();
        }
    }
}
