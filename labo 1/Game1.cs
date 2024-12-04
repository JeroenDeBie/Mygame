using labo_1.Input;
using labo_1.Interfaces;
using labo_1.Managers;
using labo_1.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Reflection.Metadata;
using System.Xml.Serialization;

namespace labo_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        private BlockFactory _map;
        Texture2D blokTexture;
        Rectangle blok;
        Vector2 positie
            = new Vector2(0, 0);

        Hero hero;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {

            // TODO: use this.Content to load your game content here
            _texture = Content.Load<Texture2D>("sprite");

           

            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            hero = new Hero(_texture, new KeyboardReader());
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here

            hero.Update(gameTime);
            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            hero.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);


        }

    }
}
