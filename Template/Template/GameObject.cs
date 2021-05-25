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
        public Rectangle Rectangle //gör så att man kan få tag på rektangel i orelaterade klasser trots att den är protected
        {
            get { return rectangle; }
        }

        public GameObject(Texture2D texture, Vector2 pos, Point size) //bestämmer egenskaper för spelobjekt
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

        public virtual void SetPos(Vector2 vector2) //bestämmer att pos är position
        {
            pos = vector2;
        }
    }
}
