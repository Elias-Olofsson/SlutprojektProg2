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
        private Vector2 lastMove; //variabel, egenskaper och en instans av Player
        private Player player;
		private float reload = 0;
		private Texture2D bulletTex;
		public Heavy(Texture2D texture, Texture2D bulletTex, Vector2 pos, Point point, Player player) : base(texture, pos, point) //olika egenskaper som heavy ska ha
        {
            this.player = player; //får den privata instansen av Player att vara del av Heavy
			this.bulletTex = bulletTex; //får den privata instansen av Texture2d:n bulletTex att vara del av Heavy
		}
        public override void Update()
        {
            if (Player.behavior == PlayerBehavior.Heavy) //om spelaren är heavy
            {
                KeyboardState kstate = Keyboard.GetState(); //läser om någon knapp trycks in
                if (kstate.IsKeyDown(Keys.W) || kstate.IsKeyDown(Keys.A) || kstate.IsKeyDown(Keys.S) || kstate.IsKeyDown(Keys.D)) //om en rörelseknapp trycks in
                {
					if (kstate.IsKeyDown(Keys.W)) //om det är W
					{
						rectangle.Size = new Point(4, 20); //bestämmer längden och bredden så att det ser ut som att vapnet är riktat framåt
						pos.X = player.Rectangle.Location.X + 21; //bestämmer platsen så att det ser ut som att vapnet är riktat framåt och är på spelaren
						pos.Y = player.Rectangle.Location.Y; //bestämmer platsen så att det ser ut som att vapnet är riktat framåt och är på spelaren
						lastMove.Y -= 2; //ändrar lastMove så att det verkligen är den förra positionen
						Light.turned = 1; //bestämmer att det hållet den går är vändningsläge 1
					}
					else if (kstate.IsKeyDown(Keys.A)) //om det är A
					{
						rectangle.Size = new Point(20, 4); //-||-
						pos.X = player.Rectangle.Location.X;
						pos.Y = player.Rectangle.Location.Y;
						lastMove.X -= 2;
						Light.turned = 2; //fast 2

					}
					else if (kstate.IsKeyDown(Keys.D)) //om det är D
					{
						rectangle.Size = new Point(20, 4); //-||-
						pos.X = player.Rectangle.Location.X + 5;
						pos.Y = player.Rectangle.Location.Y + 21;
						lastMove.X += 2;
						Light.turned = 3; //fast 3
					}
					else if (kstate.IsKeyDown(Keys.S)) //om det är S
					{
						rectangle.Size = new Point(4, 20); //-||-
						pos.X = player.Rectangle.Location.X;
						pos.Y = player.Rectangle.Location.Y + 5;
						lastMove.Y += 2;
						Light.turned = 4; //fast 4
					}
				}
				Console.WriteLine("Shoot check, " + reload); //checkar reload så att man kan se hur bra det funkar

				if (kstate.IsKeyDown(Keys.Space) && reload < 1) //om man trycker space och den inte måste ladda
				{
					Console.WriteLine("Shooting, " + reload); //checkar reload så att man kan se hur bra det funkar igen för att se skillnaden
					if (Light.turned == 1) //kollar om det är rätt vändningsläge
					{
						Game1.AddGameObject(new Bullet(bulletTex, new Vector2(player.Rectangle.Location.X + 21, player.Rectangle.Location.Y - 4), new Point(4, 4), Light.turned)); //lägger till Bullet
						reload = 20; //sätter att den måste spendera lite under 20/60 sekunder innan den kan skjuta igen
					}
					else if (Light.turned == 2) //-||-
					{
						Game1.AddGameObject(new Bullet(bulletTex, new Vector2(player.Rectangle.Location.X - 4, player.Rectangle.Location.Y), new Point(4, 4), Light.turned));
						reload = 20;
					}
					else if (Light.turned == 3) //-||-
					{
						Game1.AddGameObject(new Bullet(bulletTex, new Vector2(player.Rectangle.Location.X + 25, player.Rectangle.Location.Y + 21), new Point(4, 4), Light.turned));
						reload = 20;
					}
					else if (Light.turned == 4) //-||-
					{
						Game1.AddGameObject(new Bullet(bulletTex, new Vector2(player.Rectangle.Location.X, player.Rectangle.Location.Y + 25), new Point(4, 4), Light.turned));
						reload = 20;
					}
				}
				else 
				{
					Console.WriteLine("Reloading, " + reload); //checkar reload så att man kan se hur bra det funkar igen för att se skillnaden

					reload -= 1; //laddar
				}
				base.Update();
            }
        }
    }
}
