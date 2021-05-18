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
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Player player;
        private Light light;
        private Heavy heavy;
		private Fast fast;
		private Slow slow;
        private static List<GameObject> gameObjects;
		private Texture2D redBox;
		private Texture2D blueBox;
		private Texture2D lightGreenBox;
		private Texture2D darkGreenBox;
		private Texture2D blackBox;
		private Texture2D greyBox;
		private Texture2D orangeBox;
		bool changed = new bool();
		public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

		public static void AddGameObject(GameObject o)
		{
			gameObjects.Add(o);
		}

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gameObjects = new List<GameObject>();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            redBox = Content.Load<Texture2D>("RödLåda"); //laddar in den röda färgen
            blueBox = Content.Load<Texture2D>("BlåLåda"); //laddar in de blå färgen
            lightGreenBox = Content.Load<Texture2D>("LjusGrönLåda"); //laddar in den ljusgröna färgen
            darkGreenBox = Content.Load<Texture2D>("MörkGrönLåda"); //laddar in den mörkgröna färgen
            blackBox = Content.Load<Texture2D>("SvartLåda"); //laddar in den svarta färgen
            greyBox = Content.Load<Texture2D>("GråLåda"); //laddar in den grå färgen
            orangeBox = Content.Load<Texture2D>("OrangeLåda"); //laddar in den orangea färgen
            player = new Player(redBox, new Vector2(10, 10), new Point(25, 25)); //bestämmer position, storlek och att den ska ha utseendet av den röda lådan
            light = new Light(greyBox,orangeBox, new Vector2(23,31), new Point(12, 4), player);
            heavy = new Heavy(blackBox, orangeBox, new Vector2(light.Rectangle.X), new Point(20, 4), player);
			fast = new Fast(lightGreenBox, new Vector2(400, 200), new Point(15, 15));
			slow = new Slow(darkGreenBox, new Vector2(400, 300), new Point(35, 35));
            gameObjects.Add(player);
            gameObjects.Add(light);
			gameObjects.Add(fast);
			gameObjects.Add(slow);
			gameObjects.Add(new Wall(blueBox, new Vector2(0, 0), new Point(10, 10))); //alla till radbytet är väggar med deras storlekar och positioner
			// TODO: use this.Content to load your game content here 
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState kstate = Keyboard.GetState(); //kollar vilka knappar som trycks innan updateringen

			
			
			if (Player.behavior == PlayerBehavior.Heavy && gameObjects.Where(a => a is Heavy).ToArray().Length == 0) //kollar om den ska bli heavy om man gjort den heavy i player och lägger in en
			{																										//array och kollar den för att se till så att heavy bara skapas en gång
				gameObjects.Remove(light);
				gameObjects.Add(heavy);
				changed = true;
			}
			if (Player.behavior == PlayerBehavior.Light && changed == true && gameObjects.Where(b => b is Light).ToArray().Length == 0) //kollar om den ska bli light om man gjort den light i 
			{                                                                                                       //player och lägger in en array och kollar den för att se till så att light 
				gameObjects.Remove(heavy);                                                                          //bara skapas en gång
				gameObjects.Add(light);
			}




			for(int i = 0; i < gameObjects.Count; i++) //updaterar alla spelobjekt
            {
                gameObjects[i].Update();
            }
            Player player = gameObjects[0] as Player; //gör så att spelaren/den röda lådan får position 1 i listan

            for (int i = 1; i < gameObjects.Count; i++) //för varje spel objekt som spelaren går in i stoppas spelaren
            {
                if(!(gameObjects[i] is Light || gameObjects[i] is Heavy))//gör så att spelaren inte koliderar med light och heavy
                {
                    if (player.Rectangle.Intersects(gameObjects[i].Rectangle))//gör så att spelaren koliderar med alla andra object i gameobject
                    {
                        player.Collision();
                    }
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.Clear(Color.Black); //gör bakgrunden svart

            // TODO: Add your drawing code here.
            spriteBatch.Begin();
            foreach (GameObject gameObject in gameObjects) //för varje gameobjekt i listan rita ut dem
            {
                gameObject.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
