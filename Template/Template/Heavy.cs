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
    class Heavy : GameObject //klassen ärver från GameObjekt
    {
        private Vector2 lastMove;
        private Player player;
		private float reload = 0;
		private Texture2D bulletTex;
		public Heavy(Texture2D texture, Texture2D bulletTex, Vector2 pos, Point point, Player player) : base(texture, pos, point) //olika grejer som heavy ska ha
        {
            this.player = player;
			this.bulletTex = bulletTex;
		}
        public override void Update()
        {
            if (Player.behavior == PlayerBehavior.Heavy)
            {
                KeyboardState kstate = Keyboard.GetState(); //läser om någon knapp trycks in
                if (kstate.IsKeyDown(Keys.W) || kstate.IsKeyDown(Keys.A) || kstate.IsKeyDown(Keys.S) || kstate.IsKeyDown(Keys.D))
                {
					if (kstate.IsKeyDown(Keys.W))
					{
						rectangle.Size = new Point(4, 20);
						pos.X = player.Rectangle.Location.X + 21;
						pos.Y = player.Rectangle.Location.Y;
						lastMove.Y -= 2;
						Light.turned = 1;
					}
					else if (kstate.IsKeyDown(Keys.A))
					{
						rectangle.Size = new Point(20, 4);
						pos.X = player.Rectangle.Location.X;
						pos.Y = player.Rectangle.Location.Y;
						lastMove.X -= 2;
						Light.turned = 2;

					}
					else if (kstate.IsKeyDown(Keys.D))
					{
						rectangle.Size = new Point(20, 4);
						pos.X = player.Rectangle.Location.X + 5;
						pos.Y = player.Rectangle.Location.Y + 21;
						lastMove.X += 2;
						Light.turned = 3;
					}
					else if (kstate.IsKeyDown(Keys.S))
					{
						rectangle.Size = new Point(4, 20);
						pos.X = player.Rectangle.Location.X;
						pos.Y = player.Rectangle.Location.Y + 5;
						lastMove.Y += 2;
						Light.turned = 4;
					}
				}
				Console.WriteLine("Shoot check, " + reload);

				if (kstate.IsKeyDown(Keys.Space) && reload < 1)
				{
					Console.WriteLine("Shooting, " + reload);
					if (Light.turned == 1)
					{
						Game1.AddGameObject(new Bullet(bulletTex, new Vector2(player.Rectangle.Location.X + 21, player.Rectangle.Location.Y - 4), new Point(4, 4), Light.turned));
						reload = 20;
					}
					else if (Light.turned == 2)
					{
						Game1.AddGameObject(new Bullet(bulletTex, new Vector2(player.Rectangle.Location.X - 4, player.Rectangle.Location.Y), new Point(4, 4), Light.turned));
						reload = 20;
					}
					else if (Light.turned == 3)
					{
						Game1.AddGameObject(new Bullet(bulletTex, new Vector2(player.Rectangle.Location.X + 25, player.Rectangle.Location.Y + 21), new Point(4, 4), Light.turned));
						reload = 20;
					}
					else if (Light.turned == 4)
					{
						Game1.AddGameObject(new Bullet(bulletTex, new Vector2(player.Rectangle.Location.X, player.Rectangle.Location.Y + 25), new Point(4, 4), Light.turned));
						reload = 20;
					}
				}
				else
				{
					Console.WriteLine("Reloading, " + reload);

					reload -= 1;
				}
				base.Update();
            }
        }
    }
}
