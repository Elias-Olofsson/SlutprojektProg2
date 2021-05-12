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
    class Light : GameObject //klassen ärver från GameObjekt
    {
        private Vector2 lastMove;
        private Player player;
        private Texture2D bulletTex;
		public static int turned = 3;
		private int reload = 0;
        public Light(Texture2D texture, Texture2D bulletTex, Vector2 pos, Point point, Player player) : base(texture, pos, point) //olika grejer som light ska ha
        {
            this.player = player;
            this.bulletTex = bulletTex;
        }

        public override void Update()
        {
            if (Player.behavior == PlayerBehavior.Light)
            {
                KeyboardState kstate = Keyboard.GetState(); //läser om någon knapp trycks in
                if (kstate.IsKeyDown(Keys.W) || kstate.IsKeyDown(Keys.A) || kstate.IsKeyDown(Keys.S) || kstate.IsKeyDown(Keys.D))
                {
                    if (kstate.IsKeyDown(Keys.W))
                    {
                        rectangle.Size = new Point(4,12);
                        pos.X = player.Rectangle.Location.X+21;
                        pos.Y = player.Rectangle.Location.Y;
                        lastMove.Y -= 2;
						turned = 1;

					}
                    else if (kstate.IsKeyDown(Keys.A))
                    {
                        rectangle.Size = new Point(12, 4);
                        pos.X = player.Rectangle.Location.X;
                        pos.Y = player.Rectangle.Location.Y;
                        lastMove.X -= 2;
						turned = 2;

					}
                    else if (kstate.IsKeyDown(Keys.D))
                    {
                        rectangle.Size = new Point(12, 4);
                        pos.X = player.Rectangle.Location.X+13;
                        pos.Y = player.Rectangle.Location.Y+21;
                        lastMove.X += 2;
						turned = 3;

					}
                    else if (kstate.IsKeyDown(Keys.S))
                    {
                        rectangle.Size = new Point(4, 12);
                        pos.X = player.Rectangle.Location.X;
                        pos.Y = player.Rectangle.Location.Y+13;
                        lastMove.Y += 2;
						turned = 4;

					}
                }
                if (kstate.IsKeyDown(Keys.Space) && reload < 1) {
					if (turned == 1)
					{
						Game1.AddGameObject(new Bullet(bulletTex, new Vector2(player.Rectangle.Location.X + 21, player.Rectangle.Location.Y - 4), new Point(4, 4), turned));
						reload = 50;
					}
					else if (turned == 2)
					{
						Game1.AddGameObject(new Bullet(bulletTex, new Vector2(player.Rectangle.Location.X - 4, player.Rectangle.Location.Y), new Point(4, 4), turned));
						reload = 50;
					}
					else if (turned == 3)
					{
						Game1.AddGameObject(new Bullet(bulletTex, new Vector2(player.Rectangle.Location.X + 25, player.Rectangle.Location.Y +21), new Point(4, 4), turned));
						reload = 50;
					}
					else if (turned == 4)
					{
						Game1.AddGameObject( new Bullet(bulletTex, new Vector2(player.Rectangle.Location.X , player.Rectangle.Location.Y + 25), new Point(4, 4), turned));
						reload = 50;
					}
				}
				else
				{
					reload -= 1;
				}
            }
                base.Update();
        }
    }
}
