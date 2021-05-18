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
		public Slow(Texture2D texture, Vector2 pos, Point point) : base(texture, pos, point) //olika grejer som fienden ska ha från GameObjekt
		{

		}
	}
}
