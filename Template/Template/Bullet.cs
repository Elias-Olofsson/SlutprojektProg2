﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Template
{
    class Bullet : GameObject
    {
        public Bullet(Texture2D texture, Vector2 v, Point p) : base(texture,v,p)
        {
			
        }
    }
}
