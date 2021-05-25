using System;
using System.Collections.Generic;
using System.IO;
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
            lastMove = new Vector2(); //skapar en position för var man var

            KeyboardState kstate = Keyboard.GetState(); //läser om någon knapp trycks in
            if (behavior == PlayerBehavior.Light) //bestämmer hastigheten och positionsändring om spelaren är light och positionsändringen bestäms av om något är i vägen
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

            if (kstate.IsKeyDown(Keys.Q)) //alla här gör så att du kan trycka för att ändra lägen, Q för light och E för heavy
            {
                behavior = PlayerBehavior.Light;
            }
            else if (kstate.IsKeyDown(Keys.E))
            {
                behavior = PlayerBehavior.Heavy;
				PageFile();
            }

            base.Update(); //gör så att den updatera nu efter istället
        }

		void PageFile() //ger en achevement i filform
		{
			if (!File.Exists("achievement.file")) //endast om filen redan inte finns
			{
				BinaryWriter fileTextMaker = new BinaryWriter(new FileStream("achievement.file", FileMode.OpenOrCreate, FileAccess.Write)); //bestämmer var den ska skriva
				fileTextMaker.Write("You have managed to equip the heavy weapon."); //bestämmer vad den ska skriva
				fileTextMaker.Close(); //avslutar filskrivandet
			}
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
        public void Collision() //gör så att man backar en positionsändring när man går in i något
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
