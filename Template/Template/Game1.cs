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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        Light light;
        Heavy heavy;
        List<GameObject> gameObjects;

        //KOmentar
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

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
            Vector2 rödLådaPos = new Vector2(500, 0);
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

            Texture2D redBox = Content.Load<Texture2D>("RödLåda"); //laddar in den röda färgen
            Texture2D blueBox = Content.Load<Texture2D>("BlåLåda"); //laddar in de blå färgen
            Texture2D lightGreenBox = Content.Load<Texture2D>("LjusGrönLåda"); //laddar in den ljusgröna färgen
            Texture2D darkGreenBox = Content.Load<Texture2D>("MörkGrönLåda"); //laddar in den mörkgröna färgen
            Texture2D blackBox = Content.Load<Texture2D>("SvartLåda"); //laddar in den svarta färgen
            Texture2D greyBox = Content.Load<Texture2D>("GråLåda"); //laddar in den grå färgen
            Texture2D orangeBox = Content.Load<Texture2D>("GråLåda"); //laddar in den grå färgen
            player = new Player(redBox, new Vector2(10, 10), new Point(25, 25)); //bestämmer position, storlek och att den ska ha utseendet av den röda lådan
            light = new Light(greyBox, new Vector2(23,31), new Point(12, 4));
            gameObjects.Add(player);
            gameObjects.Add(light);

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

            foreach (GameObject gameObject in gameObjects) //updaterar alla spelobjekt
            {
                gameObject.Update();
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
