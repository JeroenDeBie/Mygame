using labo_1.Interfaces;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace labo_1.Input
{
    internal class MouseReader : IInputReader
    {
        public bool IsDirectional => true;
        public Vector2 ReadInput()
        {
            MouseState state = Mouse.GetState();
            Vector2 directionMouse = new Vector2(state.X, state.Y);
            //if (directionMouse != Vector2.Zero)
            //{
            //    directionMouse.Normalize();
            //}
            return directionMouse;
        }

        public bool IsDestinationInput => true;
    }
}
