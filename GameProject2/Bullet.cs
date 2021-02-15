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
        private Texture2D texture;

        private int bulletWidth = 200;

        private int bulletHeight = 200;

        public Vector2 Position;

        public float rotation;

        private float constantRotation = (float)0.001;

        public BoundingRectangle rectangleBounds;

        private bool launched = false;

        /// <summary>
        /// How quickly the bullet will travel across the screen
        /// Edit this for different bullet presents
        /// </summary>
        public Vector2 velocity = new Vector2(90, 0);

        /// <summary>
        /// How much gravity will affect the bullet
        /// Edit this for different bullet presets
        /// </summary>
        public Vector2 Gravity = new Vector2(0, 10);


        public Bullet(Vector2 position, float initialRotation )
        {
            this.Position = position;
            this.rotation = initialRotation;
            rectangleBounds = new BoundingRectangle( position ,bulletWidth / 4, bulletHeight / 4);
        }

        public void ResetGame(Vector2 newStartingPosition)
        {
            launched = false;
            velocity = new Vector2(300, 0);
            rotation = 0;
            Position = newStartingPosition;
            rectangleBounds = new BoundingRectangle(newStartingPosition, bulletWidth, bulletHeight );
        }
        /// <summary>
        /// Loads the bullet Image texture
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("small-bullet");
        }

        
        public void Update(GameTime gameTime, Vector2 angle, bool launched)
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

                //Slowly rotate the bullet clockwise
                rotation += constantRotation;

                //Update Rectangle Bounding Box
                rectangleBounds.X = Position.X;
                rectangleBounds.Y = Position.Y;
            }
            else
            {
                //TODO: update initial rotation of bullet
                velocity = angle;
                
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (texture is null) throw new InvalidOperationException("Texture must be loaded to render");
            if (launched) 
            {
                spriteBatch.Draw(texture, new Vector2(Position.X, Position.Y),
                null, Color.White, (rotation * (float)1.8),
                new Vector2(bulletWidth / 2, bulletHeight / 2), //TODO: resize image then insert rotation point
                 (float).5, SpriteEffects.None, 0);
            }
            
        }
    }
}
