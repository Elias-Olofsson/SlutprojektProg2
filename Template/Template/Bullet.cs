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
		private float speed = 6;
		private int direction;
        public Bullet(Texture2D texture, Vector2 v, Point p, int turned) : base(texture,v,p)
        {
			direction = turned;
        }
		public override void Update()
		{
			if(direction == 3)
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
