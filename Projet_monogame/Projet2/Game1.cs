using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Projet2;
using System;

namespace Projet2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameObject hero;
        Rectangle fenetre;
        GameObject ennemi;
        GameObject test;
        GameObject test2;
        GameObject carrot;
        Random r = new Random();


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

            this.graphics.PreferredBackBufferWidth = graphics.GraphicsDevice.DisplayMode.Width;
            this.graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.DisplayMode.Height;
            this.graphics.ToggleFullScreen();
            fenetre = new Rectangle(0, 0, graphics.GraphicsDevice.DisplayMode.Width, graphics.GraphicsDevice.DisplayMode.Height);

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

            hero = new GameObject();
            hero.estVivant = true;
            hero.position.X = 800;
            hero.position.Y = 450;
            hero.sprite = Content.Load<Texture2D>("hero.png");

            ennemi = new GameObject();
            ennemi.estVivant = true;
            ennemi.position.X = fenetre.Width - 250;
            ennemi.position.Y = 0;
            ennemi.sprite = Content.Load<Texture2D>("ennemi");

            test = new GameObject();
            test.position.X = -100;
            test.position.Y = -100;
            test.estVivant = true;

            test2 = new GameObject();
            test2.position.X = -100;
            test2.position.Y = -100;
            test2.estVivant = true;

            carrot = new GameObject();
            carrot.position.X = ennemi.position.X;
            carrot.position.Y = ennemi.position.Y;
            carrot.sprite = Content.Load<Texture2D>("proj.png");
            carrot.estVivant = true;
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

            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
                hero.position.X -= 4;

            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
                hero.position.X += 4;

            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
                hero.position.Y -= 4;
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
                hero.position.Y += 4;

            if (hero.position.X < -150)
                hero.position.X = -150;
            if (hero.position.X > fenetre.Width - 200)
                hero.position.X = fenetre.Width - 200;
            if (hero.position.Y < -150)
                hero.position.Y = -150;
            if (hero.position.Y > fenetre.Height - 250)
                hero.position.Y = fenetre.Height - 250;

            if(ennemi.position.X < -50)
            {
                ennemi.position.X = -50;
                test.estVivant = true;
            }
            if(ennemi.position.X > fenetre.Width - 200)
            {
                ennemi.position.X = fenetre.Width - 200;
                test.estVivant = false;
            }
            if(ennemi.position.Y < -50)
            {
                ennemi.position.Y = -50;
                test2.estVivant = true;
            }
            if(ennemi.position.Y > fenetre.Height - 250)
            {
                ennemi.position.Y = fenetre.Height - 250;
                test2.estVivant = false;
            }

            if(test.estVivant == true)
            {
                ennemi.position.X += r.Next(1, 5);
            }
            if(test.estVivant == false)
            {
                ennemi.position.X -= r.Next(1, 5);
            }
            if(test2.estVivant == true)
            {
                ennemi.position.Y += r.Next(1, 5);
            }
            if(test2.estVivant == false)
            {
                ennemi.position.Y -= r.Next(1, 5);
            }


            if (carrot.estVivant == true)
            {
                carrot.position.Y += 20;
            }
            if (carrot.position.Y > fenetre.Height)
            {
                carrot.position.X = ennemi.position.X;
                carrot.position.Y = ennemi.position.Y;
            }

            if (hero.GetRect().Intersects(carrot.GetRect()))
            {
                hero.estVivant = false;
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            if (hero.estVivant == true)
            {
                spriteBatch.Draw(hero.sprite, hero.position, Color.White);
            }
            spriteBatch.Draw(ennemi.sprite, ennemi.position, Color.White);
            spriteBatch.Draw(carrot.sprite, carrot.position, Color.White);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
