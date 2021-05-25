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
    class Bullet : GameObject //klassen ärver från GameObjekt
	{
		private float speed = 6; //skapar hastigheten
		private int direction; //skapar en variabel för riktning
        public Bullet(Texture2D texture, Vector2 v, Point p, int turned) : base(texture,v,p) //beskriver bullets egenskaper
        {
			direction = turned; //gör så att kulans riktning är samma som vilket håll vapnet är riktat
        }
		public override void Update()
		{
			if(direction == 3) //räknar ut nya positioner som kulan ska hoppa till sextio gånger varje sekund
			{
				pos.X += speed;
			}
			else if(direction == 1)
			{
				pos.Y -= speed;
			}
			else if (direction == 2)
			{
				pos.X -= speed;
			}
			else if (direction == 4)
			{
				pos.Y += speed;
			}
			base.Update();
		}
	}
}
