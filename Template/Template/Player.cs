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
        private bool clearPath;
        bool clearPath = true;
        public PlayerBehavior behavior = PlayerBehavior.Light; //gör så att man börjar på läge nr 0
        public Player(Texture2D texture, Vector2 pos, Point point) : base(texture, pos, point) //olika grejer som spelaren ska ha
        {

        }

        public override void Update() //gör så att den inte updateras 
        {
            KeyboardState kstate = Keyboard.GetState(); //läser om någon knapp trycks in
            if (behavior == PlayerBehavior.Light) //bestämmer hastigheten och håll om spelaren är light och hållet bestäms av om något är i vägen
            {
                if (kstate.IsKeyDown(Keys.W))
                {
                    if (clearPath == true)
                    {
                        pos.Y -= 2;
                    }
                    else
                    {
                        pos.Y += 2;
                    }
                }
                else if (kstate.IsKeyDown(Keys.A))
                {
                    if (clearPath == true)
                    {
                        pos.Y -= 2;
                    }
                    else
                    {
                        pos.Y += 2;
                    }
                }
                else if (kstate.IsKeyDown(Keys.D))
                {
                    if (clearPath == true)
                    {
                        pos.Y += 2;
                    }
                    else
                    {
                        pos.Y -= 2;
                    }
                }
                else if (kstate.IsKeyDown(Keys.S))
                {
                    if (clearPath == true)
                    {
                        pos.Y += 2;
                    }
                    else
                    {
                        pos.Y -= 2;
                    }
                }
            }
            else 
            {
                if (kstate.IsKeyDown(Keys.W))
                {
                    if (clearPath == true)
                    {
                        pos.Y -= 1;
                    }
                    else
                    {
                        pos.Y += 1;
                    }
                }
                else if (kstate.IsKeyDown(Keys.A))
                {
                    if (clearPath == true)
                    {
                        pos.Y -= 1;
                    }
                    else
                    {
                        pos.Y += 1;
                    }
                }
                else if (kstate.IsKeyDown(Keys.D))
                {
                    if (clearPath == true)
                    {
                        pos.Y += 1;
                    }
                    else
                    {
                        pos.Y -= 1;
                    }
                }
                else if (kstate.IsKeyDown(Keys.S))
                {
                    if (clearPath == true)
                    {
                        pos.Y += 1;
                    }
                    else
                    {
                        pos.Y -= 1;
                    }
                }
            }

            if (kstate.IsKeyDown(Keys.NumPad0)) //alla här gör så att du kan trycka för att ändra lägen
            {
                behavior = PlayerBehavior.Light;
            }
            else if (kstate.IsKeyDown(Keys.NumPad1))
            {
                behavior = PlayerBehavior.Heavy;
            }
            clearPath = true;

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
            clearPath = false;
        }
    }

    


    public enum PlayerBehavior //gör så att de olika spellägena får siffror så att t.ex normal är läge 0
    {
        Light,
        Heavy
    }
}
