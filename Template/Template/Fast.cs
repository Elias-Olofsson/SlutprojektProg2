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
    class Fast : Enemy //klassen ärver från  Enemy
	{
		private Vector2 speed;
		private Random random;
		public Fast(Texture2D texture, Vector2 pos, Point point) : base(texture, pos, point) //olika grejer som fienden ska ha från GameObjekt
		{
			random = new Random();
			speed = new Vector2(RandomFloat(), RandomFloat());
			speed.Normalize();
			speed *= 3;
		}

		public override void Update()
		{
			pos += speed;
			base.Update();
		}

		private float RandomFloat()
		{
			float r = (float)(random.NextDouble());
			r = r*2 - 1;
			return r;
		}

		public void Collision()
		{
			speed.X *= -1;
		}
	}
}
