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

        private int weaponWidth = 300;

        private int weaponHeight = 200;

        public Weapon(Vector2 position, float rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }

        public void ResetGame()
        {
            rotation = 0;
        }

        /// <summary>
        /// Loads the weapons's texture
        /// </summary>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("weapon");
        }

        /// <summary>
        /// Update the weapons axis of rotation
        /// </summary>
        public void Update(float angle)
        {
            this.rotation = angle * (float)1.2;

        }

        /// <summary>
        /// Draw the weapon and it's new rotation
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture is null) throw new InvalidOperationException("Texture must be loaded to render");
            spriteBatch.Draw(texture, new Vector2(position.X, position.Y), 
                null, Color.White, (rotation * 2), 
                new Vector2(weaponWidth / 2 , weaponHeight/ 2), //TODO: resize image then insert rotation point
                (float).5, SpriteEffects.None,0);
        }
    }
}
