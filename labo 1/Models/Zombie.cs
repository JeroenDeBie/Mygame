using labo_1.Animation;
using labo_1.Input;
using labo_1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labo_1.Models
{
    class Zombie : IGameObject, IMovable
    {
        Texture2D heroTexture;
        Animatie animatie;
        private Vector2 versnelling;
        private Vector2 mouseVector;
        float gravity = 1f;
        private Vector2 velocity;
        private float grounded = 400;
        public bool isGrounded = false;
        private Vector2 Position2;

        public Vector2 Position { get; set; }// Implements Position from IMovable
        public Vector2 Speed { get; set; }    // Implements Speed from IMovable
        public IInputReader InputReader { get; set; } // Implements InputReader from IMovable
        KeyboardReader keyboard = new KeyboardReader();
        KeyboardState state = new KeyboardState();


        private void Move()
        {

        }


        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
