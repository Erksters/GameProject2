using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using CollisionExample.Collisions;

namespace GameProject2
{
    class Target
    {
        private Vector2 position;

        private Texture2D texture;

        private int targetWidth = 100;
        
        private int targetHeight = 100;

        /// <summary>
        /// Determine if the target was hit
        /// </summary>
        public bool TargetHit { get; set; } = false;

        private BoundingRectangle rectangleBounds;

        /// <summary>
        /// Bounding Volume of the coin 
        ///FOR RECTANGLE COLLISIONS
        /// </summary>        
        public BoundingRectangle RectangleBounds => rectangleBounds;

        public Target(Vector2 position)
        {
            this.position = position;
            this.rectangleBounds = new BoundingRectangle(
                                        new Vector2(position.X - targetWidth / 2 , position.Y - targetHeight /2), 
                                        targetWidth, targetHeight);
        }

        /// <summary>
        /// Tell the target it was hit
        /// </summary>
        public void Update(bool targetHit)
        {
            TargetHit = targetHit;
        }

        public void ResetGame(Vector2 position)
        {
            this.position = position;
            this.rectangleBounds = new BoundingRectangle(position, targetWidth / 4, targetHeight / 4);
            TargetHit = false;
        }

        /// <summary>
        /// Loads the sprite texture using the provided ContentManager
        /// </summary>
        /// <param name="content">The ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("target");
        }

        /// <summary>
        /// Draws the animated sprite using the supplied SpriteBatch
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The spritebatch to render with</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture is null) throw new InvalidOperationException("Texture must be loaded to render");

            var source = new Rectangle(0, 0, targetWidth , targetHeight);
            if (TargetHit == false) { spriteBatch.Draw(texture, position, null, Color.White); }
            
        }

    }
}
