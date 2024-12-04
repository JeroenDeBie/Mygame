using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labo_1.Models
{


    public class Sprite
    {
        Texture2D texture;
        Vector2 position;

        public Sprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }




    public void Draw()
    {
         Globals.SpriteBatch.Draw(texture, position, Color.White);
    }
}
}
