using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        GameObject[] ennemi = new GameObject[5];
        GameObject test;
        GameObject test2;
        GameObject carrot;
        GameObject tru;
        GameObject dir;
        SpriteFont font;
        Random r = new Random();
        float timer;




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
            hero.position.X = 0;
            hero.position.Y = 0;
            hero.sprite = Content.Load<Texture2D>("hero.png");

            for (int i = 0; i < ennemi.Length; i++)
            {
                ennemi[i] = new GameObject();
                ennemi[i].estVivant = true;
                ennemi[i].position.X = fenetre.Width - 250;
                ennemi[i].position.Y = 0;
                ennemi[i].sprite = Content.Load<Texture2D>("ennemi");
                ennemi[i].direction.X = r.Next(-5, -2);
                ennemi[i].direction.Y = r.Next(2, 5);
            }

            test = new GameObject();
            test.position.X = -100;
            test.position.Y = -100;
            test.estVivant = true;

            test2 = new GameObject();
            test2.position.X = -100;
            test2.position.Y = -100;
            test2.estVivant = true;

            carrot = new GameObject();
            for (int i = 0; i < ennemi.Length; i++)
            {
                carrot.position.X = ennemi[i].position.X;
                carrot.position.Y = ennemi[i].position.Y;
            }
            carrot.sprite = Content.Load<Texture2D>("proj.png");
            carrot.estVivant = true;

            tru = new GameObject();
            tru.estVivant = true;

            dir = new GameObject();
            dir.estVivant = true;

            Song song = Content.Load<Song>("Sounds\\Creepy-doll-music");
            MediaPlayer.Play(song);


            font = Content.Load<SpriteFont>("Font");

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

            if (hero.position.X < -30)
                hero.position.X = -30;
            if (hero.position.X > fenetre.Width - 100)
                hero.position.X = fenetre.Width - 100;
            if (hero.position.Y < -30)
                hero.position.Y = -30;
            if (hero.position.Y > fenetre.Height - 250)
                hero.position.Y = fenetre.Height - 250;

            for (int i = 0; i < ennemi.Length; i++)
            {
                if(ennemi[i].position.X < -30)
                {
                    ennemi[i].direction.X = r.Next(2, 5);
                }
                else if(ennemi[i].position.X > fenetre.Width - 50)
                {
                    ennemi[i].direction.X = r.Next(-5, -2);
                }
                else if(ennemi[i].position.Y < -50)
                {
                    ennemi[i].direction.Y = r.Next(2, 5);
                }
                else if(ennemi[i].position.Y > fenetre.Height - 180)
                {
                    ennemi[i].direction.Y = r.Next(-5, -2);
                }
                ennemi[i].position.X += ennemi[i].direction.X;
                ennemi[i].position.Y += ennemi[i].direction.Y;
            }

            

            if (carrot.estVivant == true)
            {
                carrot.position.Y += 20;
            }
            if (carrot.position.Y > fenetre.Height)
            {
                for (int i = 0; i < ennemi.Length; i++)
                {
                    carrot.position.X = ennemi[i].position.X;
                    carrot.position.Y = ennemi[i].position.Y;
                }
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
            if (tru.estVivant == true)
            {
                GraphicsDevice.Clear(Color.White);
                tru.estVivant = false;
            }
            else
            {
                GraphicsDevice.Clear(Color.Black);
                tru.estVivant = true;
            }
            spriteBatch.Begin();

            if (hero.estVivant == true)
            {
                spriteBatch.Draw(hero.sprite, hero.position, Color.White);
                timer = (float)gameTime.TotalGameTime.Seconds;

            }
            else
            {
                GraphicsDevice.Clear(Color.Red);
                for (int i = 0; i < ennemi.Length; i++)
                {
                    ennemi[i].estVivant = false;
                }
                carrot.estVivant = false;
                spriteBatch.DrawString(font, "This is the end!!!", new Vector2(650, 450), Color.Blue);
                spriteBatch.DrawString(font, "Temps perdu a jouer: " + timer + " secondes", new Vector2(540, 500), Color.Green);
            }
            for (int i = 0; i < ennemi.Length; i++)
            {
                if (ennemi[i].estVivant == true)
                {
                    spriteBatch.Draw(ennemi[i].sprite, ennemi[i].position, Color.White);
                }
            }
            if (carrot.estVivant)
            {
                spriteBatch.Draw(carrot.sprite, carrot.position, Color.White);
            }

            spriteBatch.End();

            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
