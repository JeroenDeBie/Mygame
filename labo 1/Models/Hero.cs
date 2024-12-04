using labo_1.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using labo_1.Animation;
using Microsoft.Xna.Framework.Input;
using labo_1.Managers;
using labo_1.Input;
using System.IO;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace labo_1
{
    class Hero : IGameObject, IMovable
    {
        Texture2D heroTexture;
        Animatie animatie;
        private Vector2 versnelling;
        private Vector2 mouseVector;
        float gravity = 0.5f;
        private Vector2 velocity;
        private float grounded = 400;
        public bool isGrounded = false;
        private Vector2 Position2;
        private float friction = 0.9f;

        public Vector2 Position { get; set; }// Implements Position from IMovable
        public Vector2 Speed { get; set; }    // Implements Speed from IMovable
        public IInputReader InputReader { get; set; } // Implements InputReader from IMovable
        KeyboardReader keyboard = new KeyboardReader();
        KeyboardState state = new KeyboardState();

        public Hero(Texture2D texture, IInputReader inputReader)
        {
            heroTexture = texture;
            this.InputReader = inputReader;
            animatie = new Animatie();





            this.Position2 = new Vector2(10, 10);
            this.Speed = new Vector2(1, 1);
            versnelling = new Vector2(0.1f, 0.1f);
        }

        public void Update(GameTime gameTime)
        {
            Move();


            if (state.IsKeyDown(Keys.Right))
            {
                animatie.AddFrame(new AnimationFrame(new Rectangle(314, 15, 29, 40)));
                animatie.AddFrame(new AnimationFrame(new Rectangle(345, 15, 19, 40)));
                animatie.AddFrame(new AnimationFrame(new Rectangle(366, 15, 22, 40)));
                animatie.AddFrame(new AnimationFrame(new Rectangle(389, 15, 31, 40)));
                animatie.AddFrame(new AnimationFrame(new Rectangle(421, 15, 33, 40)));
                animatie.AddFrame(new AnimationFrame(new Rectangle(455, 15, 25, 40)));
                animatie.AddFrame(new AnimationFrame(new Rectangle(484, 15, 19, 40)));
                animatie.AddFrame(new AnimationFrame(new Rectangle(506, 15, 24, 40)));
                animatie.AddFrame(new AnimationFrame(new Rectangle(534, 15, 29, 40)));
                animatie.AddFrame(new AnimationFrame(new Rectangle(565, 15, 33, 40)));
                animatie.AddFrame(new AnimationFrame(new Rectangle(599, 15, 29, 40)));
            }
            else
            {
                animatie.AddFrame(new AnimationFrame(new Rectangle(208, 15, 32, 40)));
                animatie.AddFrame(new AnimationFrame(new Rectangle(242, 15, 32, 40)));
            }

            //MoveWithMouse(GetMouseState());
            
            animatie.Update(gameTime);
        }

        private Vector2 GetMouseState()
        {
            MouseState state = Mouse.GetState();
            mouseVector = new Vector2(state.X, state.Y);

            return mouseVector;
        }



        private Vector2 Limit(Vector2 v, float maxX, float maxY)
        {
            // Limit X component
            if (Math.Abs(v.X) > maxX)
            {
                v.X = Math.Sign(v.X) * maxX; // Retain direction while capping magnitude
            }

            // Limit Y component
            if (Math.Abs(v.Y) > maxY)
            {
                v.Y = Math.Sign(v.Y) * maxY; // Retain direction while capping magnitude
            }

            return v;
        }

        private void Move()
        {
            var direction = InputReader.ReadInput(isGrounded);

            if (InputReader.IsDestinationInput)
            {
                direction -= Position2;
                direction.Normalize();
            }

            if (direction.X == 0)
            {
                velocity.X *= friction; // Reduce horizontal speed gradually
                if (Math.Abs(velocity.X) < 0.1f)
                    velocity.X = 0; // Stop completely when very slow
            }

            velocity += direction;
            velocity.Y += versnelling.Y;
            velocity.Y += gravity;
            velocity = Limit(velocity, 5, 10);


            Position2 += velocity;



            if (Position2.Y >= grounded)
            {
                Position2.Y = grounded;
                isGrounded = true;
                velocity.Y = 0;

            }
            else if (Position.Y < grounded)
            {
                
                isGrounded = false;
            }

        }

        private void UpdateAnimation()
        {

        }


        public void ChangeInput(IInputReader inputReader)
        {
            this.InputReader = inputReader;
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, Position2, animatie.Currentframe.SourceRectangle, Color.White);


        }
    }
}
