using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace labo_1.Interfaces
{
    internal interface IInputReader
    {
        Vector2 ReadInput();
        public bool IsDestinationInput { get; }
    }
}
