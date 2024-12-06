using labo_1.Input;
using labo_1.Interfaces;
using labo_1.Managers;
using labo_1.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using static System.Reflection.Metadata.BlobBuilder;

namespace labo_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _herotexture;
        private Texture2D _zombietexture;
        private BlockFactory _map;
        Texture2D blokTexture;
        Rectangle blok;
        Vector2 positie
            = new Vector2(0, 0);
        private Texture2D _tileTexure;
        private int tilesize = 70;



        Hero hero;
        Zombie zombie;

        int[,] gameboard = new int[,]
       {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
       };


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            CreateBlocks();
            base.Initialize();
        }

        protected override void LoadContent()
        {

            // TODO: use this.Content to load your game content here
            _herotexture = Content.Load<Texture2D>("sprite");
            _zombietexture = Content.Load<Texture2D>("zombie-walk");
            _tileTexure = Content.Load<Texture2D>("tile3");


            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });

            _spriteBatch = new SpriteBatch(GraphicsDevice);



            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            hero = new Hero(_herotexture, new KeyboardReader());
            zombie = new Zombie(new Vector2(950f, 100f));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here

            zombie.Update(gameTime);
            hero.Update(gameTime);
            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DimGray);

            _spriteBatch.Begin();

            // TODO: Add your drawing code here

            foreach (var position in blockPos)
            {
                _spriteBatch.Draw(_tileTexure, new Rectangle((int)position.X, (int)position.Y, tilesize, tilesize), Color.White);
            }

            zombie.Draw(_spriteBatch);
            hero.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);


        }

        private List<Vector2> blockPos = new List<Vector2>();

        private void CreateBlocks()
        {
            

            int rows = gameboard.GetLength(0);
            int columns = gameboard.GetLength(1);

            

            int screenWidth = GraphicsDevice.Viewport.Width;
            int screenHeight = GraphicsDevice.Viewport.Height;

            int tilesize = Math.Min(screenWidth / columns, screenHeight / rows);


            int gridWidth = columns * tilesize;
            int gridHeight = rows * tilesize;



            blockPos.Clear();

            for (int l = 0; l < rows; l++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (gameboard[l, c] == 1)
                    {
                       Vector2 position = (new Vector2(c * tilesize, l * tilesize));
                        blockPos.Add(position);
                    }

                }
            }
        }
    }
}
