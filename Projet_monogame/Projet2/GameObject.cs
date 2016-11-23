using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Projet2
{
    internal class GameObject
    {
        public bool estVivant;
        public Texture2D sprite;
        public Vector2 position;
        public Vector2 direction;
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