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
    class Player : GameObject //klassen ärver från GameObjekt
    {
        public static PlayerBehavior behavior = PlayerBehavior.Light; //gör så att man börjar på läge nr 0

        float speedMultiplier = 1;

        Vector2 lastMove;

        public Player(Texture2D texture, Vector2 pos, Point point) : base(texture, pos, point) //olika grejer som spelaren ska ha från GameObjekt
        {
            
        }

        public override void Update() //gör så att den inte updateras 
        {
            lastMove = new Vector2();

            KeyboardState kstate = Keyboard.GetState(); //läser om någon knapp trycks in
            if (behavior == PlayerBehavior.Light) //bestämmer hastigheten och positionsändring om spelaren är light och positionsändringenS bestäms av om något är i vägen
            {
                speedMultiplier = 2;
            }
            else
            {
                speedMultiplier = 1;
            }
            if (kstate.IsKeyDown(Keys.W))
            {
                pos.Y -= 1 * speedMultiplier;
                lastMove.Y -= 1 * speedMultiplier;
            }
            else if (kstate.IsKeyDown(Keys.A))
            {
                pos.X -= 1 * speedMultiplier;
                lastMove.X -= 1 * speedMultiplier;
            }
            else if (kstate.IsKeyDown(Keys.D))
            {
                pos.X += 1 * speedMultiplier;
                lastMove.X += 1 * speedMultiplier;
            }
            else if (kstate.IsKeyDown(Keys.S))
            {
                pos.Y += 1 * speedMultiplier;
                lastMove.Y += 1 * speedMultiplier;
            }

            if (kstate.IsKeyDown(Keys.Q)) //alla här gör så att du kan trycka för att ändra lägen, q för light och e för heavy
            {
                behavior = PlayerBehavior.Light;
            }
            else if (kstate.IsKeyDown(Keys.E))
            {
                behavior = PlayerBehavior.Heavy;
            }

            base.Update(); //gör så att den updatera nu efter istället
        }

        public override void Draw(SpriteBatch spriteBatch) //allt här ritar ut spelaren i båda originallägena
        {
            if (behavior == PlayerBehavior.Light)
            {
                base.Draw(spriteBatch);

            }
            else if(behavior == PlayerBehavior.Heavy)
            {
                base.Draw(spriteBatch);

            }
        }
        public void Collision()
        {
            pos += lastMove * -1;
        }
    }

    


    public enum PlayerBehavior //gör så att de olika spellägena får siffror så att t.ex normal är läge 0
    {
        Light,
        Heavy
    }
}
