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

namespace labo_1
{
    class Hero : IGameObject, IMovable
    {
        private MovementManager movementManager;
        Texture2D heroTexture;
        Animatie animatie;
        private Vector2 versnelling;
        private Vector2 mouseVector;
        float gravity = 0.1f;
        private Vector2 velocity;
        private bool _onGround = true;

        public Vector2 Position { get; set; } // Implements Position from IMovable
        public Vector2 Speed { get; set; }    // Implements Speed from IMovable
        public IInputReader InputReader { get; set; } // Implements InputReader from IMovable



        public Hero(Texture2D texture, IInputReader inputReader)
        {
            heroTexture = texture;
            this.InputReader = inputReader;
            animatie = new Animatie();
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
            this.Position = new Vector2(10, 10);
            this.Speed = new Vector2(1, 1);
            versnelling = new Vector2(0.1f, 0.1f);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            //MoveWithMouse(GetMouseState());
            animatie.Update(gameTime);
        }

        private Vector2 GetMouseState()
        {
            MouseState state = Mouse.GetState();
            mouseVector = new Vector2(state.X, state.Y);

            return mouseVector;
        }



        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }

        private void Move()
        {
            var direction = InputReader.ReadInput();

            if (InputReader.IsDestinationInput)
            {
                direction -= Position;
                direction.Normalize();
            }

            velocity.Y += gravity;
            velocity.X = direction.X;
            Position += velocity;

            if (Position.Y == 400)
            {
                direction.Y = 0;
            }
        }


        public void ChangeInput(IInputReader inputReader)
        {
            this.InputReader = inputReader;
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, Position, animatie.Currentframe.SourceRectangle, Color.White);


        }
    }
}
