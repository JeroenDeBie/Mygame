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
        private float grounded = 950f;
        public bool isGrounded = false;
        private Vector2 Position2;

        public Vector2 Position { get; set; }// Implements Position from IMovable
        public Vector2 Speed { get; set; }    // Implements Speed from IMovable
        public IInputReader InputReader { get; set; } // Implements InputReader from IMovable
        KeyboardReader keyboard = new KeyboardReader();
        KeyboardState state = new KeyboardState();


        private bool movingRight = true; // Direction of movement
        private float patrolSpeed = 2f;  // Speed of movement
        private float patrolRange = 300f; // Range to patrol within
        private float startPositionX;    // Starting X position

        public Zombie(Vector2 initialPosition)
        {
            Position2 = initialPosition;
            startPositionX = initialPosition.X;
            animatie = new Animatie();
        }
        private void Move()
        {
            if (Position2.Y == grounded) // Only move when grounded
            {
                // Move left or right
                if (movingRight)
                {
                    Position2.X += patrolSpeed;
                    if (Position2.X >= startPositionX + patrolRange) // Change direction
                    {
                        movingRight = false;
                    }
                }
                else
                {
                    Position2.X -= patrolSpeed;
                    if (Position2.X <= startPositionX - patrolRange) // Change direction
                    {
                        movingRight = true;
                    }
                }
            }

        }






        public void Update(GameTime gameTime)
        {


            animatie.AddFrame(new AnimationFrame(new Rectangle(12, 46, 26, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(60, 46, 22, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(108, 46, 26, 32)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(156, 46, 22, 32)));

            animatie.Update(gameTime);
            Move();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var frame = animatie.Currentframe;

            if (frame == null)
            {
                SpriteEffects effects = movingRight ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

                spriteBatch.Draw(heroTexture, Position2, frame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1f, effects, 0f);
            }

        }
    }
}
