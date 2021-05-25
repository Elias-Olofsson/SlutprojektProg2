using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
	class Slow : Enemy //klassen ärver från  Enemy
	{
		private Vector2 speed;
		private Random random;
		public Slow(Texture2D texture, Vector2 pos, Point point) : base(texture, pos, point) //olika grejer som fienden ska ha från GameObjekt
		{
			random = new Random();
			speed = new Vector2(RandomFloat(), RandomFloat());
			speed.Normalize();
			speed *= 1;
		}

		public override void Update()
		{
			pos += speed;
			base.Update();
		}

		private float RandomFloat()
		{
			float r = (float)(random.NextDouble());
			r = r * 2 - 1;
			return r;
		}

		public void Collision()
		{
			if (pos.X < 10 || pos.X > 790 - 35)
			{
				speed.X *= -1;
			}

			if (pos.Y < 10 || pos.Y > 470 - 35)
			{
				speed.Y *= -1;
			}
		}
	}
}
