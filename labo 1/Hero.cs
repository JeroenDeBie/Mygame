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

namespace labo_1
{
    class Hero : IGameObject
    {
        Texture2D heroTexture;
        Animatie animatie;
        private Vector2 positie;
        private Vector2 snelheid;
        private Vector2 versnelling;
        private Vector2 mouseVector;

        public Hero(Texture2D texture)
        {
            heroTexture = texture;
            animatie = new Animatie();
            animatie.AddFrame(new AnimationFrame(new Rectangle(0,0,60,64)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(60, 0, 60, 64)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(120, 0, 60, 64)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(180, 0, 60, 64)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(240, 0, 60, 64)));
            positie = new Vector2(10, 10);
            snelheid = new Vector2(1, 1);
            versnelling = new Vector2(0.05f, 0.05f);
        }

        public void Update(GameTime gameTime)
        {
            
            Move(GetMouseState());
            animatie.Update(gameTime);
        }

        private Vector2 GetMouseState()
        {
            MouseState state = Mouse.GetState();
            mouseVector = new Vector2(state.X, state.Y);

            return mouseVector;
        }

        private void Move(Vector2 mouse)
        {
            var direction = Vector2.Add(mouse, -positie);
            direction.Normalize();
            direction = Vector2.Multiply(direction, 0.5f);

            positie += snelheid;
            snelheid += direction;
            snelheid = Limit(snelheid, 15);


            if (positie.X > 750 || positie.X < 0)
            {
                snelheid.X *= -1;
                versnelling.X *= -1;
            }
            if (positie.Y > 400 || positie.Y < 0)
            {
                snelheid.Y *= -1;
                versnelling.Y *= -1;
            }
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






        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, positie,animatie.Currentframe.SourceRectangle, Color.White);

         
        }
    }
}
