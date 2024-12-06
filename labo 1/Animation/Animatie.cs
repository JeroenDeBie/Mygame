using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace labo_1.Animation
{
    public class Animatie
    {
        public AnimationFrame Currentframe { get; set; }

        private List<AnimationFrame> frames;
        
        private int counter;

        private double frameMovement = 0;

        public Animatie()
        {
            frames = new List<AnimationFrame>();
        }

        public void AddFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            Currentframe = frames[0];
        }

        public void ClearFrames()
        {
            frames.Clear();
            counter = 0;
        }

        public void Update(GameTime gameTime)
        {
             Currentframe = frames[counter];

            frameMovement += Currentframe.SourceRectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;
            if (frameMovement >= Currentframe.SourceRectangle.Width/10)
            {
                counter++;
                frameMovement = 0;
            }

           

            if (counter >= frames.Count)
                counter = 0;
        }
    }
}
