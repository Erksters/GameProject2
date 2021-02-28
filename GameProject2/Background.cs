using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace GameProject2
{
    class Background
    {

        private Vector2 position;

        private Texture2D texture;

        private int ImageWidth = 1280;

        private int ImageHeight = 720;

        private Rectangle source;
        /// <summary>
        /// Loads the weapons's texture
        /// </summary>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("TreeArea");
        }

        /// <summary>
        /// Draw the weapon and it's new rotation
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture is null) throw new InvalidOperationException("Texture must be loaded to render");
            source = new Rectangle(0, 0, ImageWidth, ImageHeight);
            spriteBatch.Draw(texture,source, Color.White);
        }
    }
}



      