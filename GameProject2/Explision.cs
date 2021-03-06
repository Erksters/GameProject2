﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GameProject2
{
    class Explision
    {
        private SoundEffect weaponLaunch;
        private SoundEffect impact;
        private SoundEffect gunReload;
        private SoundEffect nighttime;
        private SoundEffectInstance nightTimeLoop;
        private bool makeNoise = true;
        private bool showExplosion = false;
        private bool playImpact = true;
        private Texture2D texture;
        private double animationTimer;
        private short animationFrame;
        private int widthOfFrame = 12;
        private int heightOfFrame = 12;
        private int heightLocationOfFrame = 0;
        private bool newGame = true;

        /// <summary>
        /// Position of Explosion 
        /// this should match the target
        /// </summary>
        public Vector2 Position;

        public Explision(Vector2 position)
        {
            Position = position;
        }

        /// <summary>
        /// Add the content of the sound
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            weaponLaunch = content.Load<SoundEffect>("Gun");
            gunReload = content.Load<SoundEffect>("reload_small_gunwav");
            impact = content.Load<SoundEffect>("explosion_sound");
            nighttime = content.Load<SoundEffect>("Nightime");
            nightTimeLoop = nighttime.CreateInstance();
            texture = content.Load<Texture2D>("flame_exposion");
        }

        public void ResetGame(Vector2 position)
        {
            gunReload.Play();
            Position = position;
            makeNoise = true;
            showExplosion = false;
            animationFrame = 0;
            animationTimer = 0;
            playImpact = true;
        }

        /// <summary>
        /// Update will take care of noises and rendering the explosion
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="Launched"></param>
        public void Update(bool Launched, bool hit)
        {
            if (newGame)
            {
                nightTimeLoop.IsLooped = true;
                nightTimeLoop.Play();
                newGame = false;
            }
            if (Launched && makeNoise)
            {
                weaponLaunch.Play();
                makeNoise = false;
            }

            if (hit)
            {
                showExplosion = true;
                if (playImpact)
                {
                    impact.Play();
                    playImpact = false;
                }
                
            }
           
        }

        /// <summary>
        /// Draw the animation of the explosion
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Check texture content
            if (texture is null) throw new InvalidOperationException("Texture must be loaded to render");

            //If we were hit
            if (showExplosion)
            {
                //Update animation timer
                animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

                //animate on 10 frames a second
                if (showExplosion && animationTimer > 0.1)
                {
                    //reset the timer to sustain the frame
                    animationTimer -= 0.1;

                    //increment the frame
                    animationFrame++;
                    
                    //quit animation
                    if (animationFrame > 8)
                    {
                        showExplosion = false;
                    }
                }

                var source = new Rectangle(animationFrame * widthOfFrame, 0, widthOfFrame, heightOfFrame);

                spriteBatch.Draw(texture, Position, source, Color.White, 0f, new Vector2(0, 0), 7, SpriteEffects.None, 0);
            }
        }
    }
}
