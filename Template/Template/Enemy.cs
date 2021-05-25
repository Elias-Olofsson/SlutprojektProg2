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
    class Enemy : GameObject //klassen ärver från GameObjekt
	{ 
		public Enemy(Texture2D texture, Vector2 pos, Point point) : base(texture, pos, point) //olika grejer som fienderna ska ha från GameObjekt
		{

		}
	}
}
