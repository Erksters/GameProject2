using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GameProject2
{
    class Weapon
    {
        private Vector2 position;

        private Texture2D texture;

        private float rotation;
        public Weapon(Vector2 position, float rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }


        /// <summary>
        /// Loads the weapons's texture
        /// </summary>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("pistol-860-423");
            
        }

        /// <summary>
        /// Update the weapons axis of rotation
        /// </summary>
        public void Update(float rotation)
        {
            this.rotation += rotation;
        }

        /// <summary>
        /// Draw the weapon and it's new rotation
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture is null) throw new InvalidOperationException("Texture must be loaded to render");

            spriteBatch.Draw(texture,position,Color.White);
        }
    }
}
