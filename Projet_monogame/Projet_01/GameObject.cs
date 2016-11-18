using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_01
{
    class GameObject
    {
        public bool estVivant;
        public Texture2D sprite;
        public Vector2 position;
        public Rectangle Rectcollision = new Rectangle();

        public Rectangle GetRect()
        {
            Rectcollision.X = (int)this.position.X;
            Rectcollision.Y = (int)this.position.Y;
            Rectcollision.Width = this.sprite.Width;
            Rectcollision.Height = this.sprite.Height;
            return Rectcollision;
        }

        
    }
}
