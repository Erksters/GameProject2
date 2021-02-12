using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using CollisionExample.Collisions;

namespace GameProject2.Collisions
{
    class Bullet
    {
        private Vector2 Direction;

        private int speed;

        private Vector2 Physics = new Vector2(0, 10);

        private Texture2D texture;

        private int bulletWidth;

        private int bulletHeight;

        public Vector2 Position = new Vector2(100,400);

        private int rotation;

        private BoundingRectangle rectangleBounds;

        public Bullet(int rotation)
        {
            this.rotation = rotation;
        }

        /// <summary>
        /// Loads the bat sprite texture
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Bullet");
        }

        public void Update(GameTime gameTime)
        {
            //TODO: slowly drift the bullet down
            //TODO: slowly rotate the bullet clockwise
            //TODO: update the position of the bullet
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(texture ,new Vector2(Position.X, Position.Y), null,Color.White , rotation, 
                default , 1, SpriteEffects.None, 0);
        }

    }
}
