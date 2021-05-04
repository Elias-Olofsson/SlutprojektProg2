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
    public class GameObject
    {
        protected Texture2D texture; //textur
        protected Vector2 pos; //position
        protected Rectangle rectangle; //rektangel
        public Rectangle Rectangle
        {
            get { return rectangle; }
        }

        public GameObject(Texture2D texture, Vector2 pos, Point size)
        {
            this.texture = texture;
            this.pos = pos;
            rectangle = new Rectangle(pos.ToPoint(), size);
        }

        public virtual void Update()
        {
            rectangle.Location = pos.ToPoint(); //syncar objectets rectangle med pos 
        }

        public virtual void Draw(SpriteBatch spriteBatch)//ritar ut spritebatcharna
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }

        public virtual void SetPos(Vector2 vector2)
        {
            pos = vector2;
        }
    }
}
