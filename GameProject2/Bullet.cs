using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using CollisionExample.Collisions;

namespace GameProject2
{
    class Bullet
    {
        private Vector2 Direction;

        private int speed;

        private Vector2 Physics = new Vector2(0, 10);

        private Texture2D texture;

        private int bulletWidth;

        private int bulletHeight;

        public Vector2 Position = new Vector2(100,100);

        private float rotation;

        private float constantRotation = (float)0.002;

        public BoundingRectangle rectangleBounds;

        private bool launched = false;

        /// <summary>
        /// How quickly the bullet will travel across the screen
        /// Edit this for different bullet presents
        /// </summary>
        public Vector2 velocity = new Vector2(80, 0);

        /// <summary>
        /// How much gravity will affect the bullet
        /// Edit this for different bullet presets
        /// </summary>
        public Vector2 Gravity = new Vector2(0, 30);


        public Bullet(Vector2 position, float initialRotation )
        {
            this.Position = position;
            this.rotation = initialRotation;
        }

        /// <summary>
        /// Loads the bullet Image texture
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("bullet-512_512");
        }

        
        public void Update(GameTime gameTime, int angle, bool launched)
        {
            this.launched = launched;
            //If bullet is shot
            if (launched)
            {
                float time = (float)gameTime.ElapsedGameTime.TotalSeconds;

                //Pull Bullet velocity down over time 
                velocity += Gravity * time;

                //Update bullet position over time 
                Position += velocity * time;

                //TODO: slowly rotate the bullet clockwise
                rotation += constantRotation;
            }
            else
            {
                //TODO: update initial rotation of bullet
                
            }
            
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (texture is null) throw new InvalidOperationException("Texture must be loaded to render");

            spriteBatch.Draw(texture ,new Vector2(Position.X, Position.Y), null,Color.White , rotation, 
                default ,(float) .25, SpriteEffects.None, 0);
        }

    }
}
