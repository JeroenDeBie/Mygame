using labo_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Security.Cryptography.X509Certificates;

namespace labo_1.Input
{
    internal class KeyboardReader : IInputReader
    {
        public Vector2 ReadInput(bool isGrounded)
        {

            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;

            if (state.IsKeyDown(Keys.Left))
            {
                direction.X -= 3;

            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction.X += 3;
            }
            if (state.IsKeyDown(Keys.Space) && isGrounded)
            {
                direction.Y -= 10;
            }
            return direction;

        }


        public bool IsDestinationInput => false;
    }
}
