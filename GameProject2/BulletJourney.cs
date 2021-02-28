using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace GameProject2
{
    public class BulletJourney : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont myFont;
        private AimAndShootInputManager AimInputManager;
        private List<Target> targets;
        private Bullet bullet;
        private Weapon weapon;
        private Explision explosion;
        private Random rand;
        private Background background;
        private int attempts;
        private int hittargets;
        private bool targetWasHit;
        private bool attempted = true;


        public BulletJourney()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            AimInputManager = new AimAndShootInputManager();
            targets = new List<Target>();
            targets.Add(new Target(new Vector2(650, 200)));
            bullet = new Bullet(new Vector2(100, 400), 0);
            weapon = new Weapon(new Vector2(100, 430), 0);
            explosion = new Explision(new Vector2(650, 200));
            rand = new Random();
            background = new Background();
            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            myFont = Content.Load<SpriteFont>("ArialText");
            foreach(var target in targets)
            {
                target.LoadContent(Content);
            }

            bullet.LoadContent(Content);
            weapon.LoadContent(Content);
            explosion.LoadContent(Content);
            background.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (AimInputManager.Exit)  Exit();

            // TODO: Add your update logic here
            AimInputManager.Update(gameTime);
            foreach (var target in targets)
            {
                if (target.RectangleBounds.CollidesWith(bullet.rectangleBounds)) 
                {
                    if (!targetWasHit) { hittargets++; targetWasHit = true; }
                    
                    explosion.Update(false, true);
                    target.TargetHit = true;
                }
            }

            if (AimInputManager.Reset)
            {
                Vector2 weaponPosTemp = new Vector2(100, rand.Next(100, 600));
                Vector2 BulletPosTemp = weaponPosTemp + new Vector2(0, -30);
                Vector2 TargetExplosionPosTemp = new Vector2(rand.Next(650, 1000), rand.Next(100, 600));

                AimInputManager.ResetGame();
                bullet.ResetGame(BulletPosTemp);
                weapon.ResetGame(weaponPosTemp);
                explosion.ResetGame(TargetExplosionPosTemp);
                
                foreach (var target in targets) { target.ResetGame( TargetExplosionPosTemp); }
                targetWasHit = false;
                attempted = true;
            }

            if (AimInputManager.Launched && attempted)
            {
                attempts++;
                attempted = false;
            }

            bullet.Update(gameTime, AimInputManager.Angle, AimInputManager.Launched, AimInputManager.SpeedMulitiplier);
            weapon.Update(AimInputManager.Angle);
            explosion.Update(AimInputManager.Launched, false);           
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (attempts < 10) 
            {

                GraphicsDevice.Clear(Color.CornflowerBlue);

                // TODO: Add your drawing code here
                _spriteBatch.Begin();
                background.Draw(_spriteBatch);
                _spriteBatch.DrawString(myFont, $"Direction {AimInputManager.Angle}", new Vector2(30, 30), Color.Black);
                _spriteBatch.DrawString(myFont, $"Speed Multiplier {bullet.SpeedMultiplier}", new Vector2(30, 90), Color.Black);
                _spriteBatch.DrawString(myFont, $"Targets Hit / Attempted shots {hittargets} / {attempts}", new Vector2(30, 60), Color.Black);
                foreach (var target in targets)
                {
                    target.Draw(_spriteBatch);
                }
                bullet.Draw(gameTime, _spriteBatch);
                weapon.Draw(_spriteBatch);
                explosion.Draw(gameTime, _spriteBatch);

                _spriteBatch.End();

                base.Draw(gameTime);
            }
            else
            {
                _spriteBatch.Begin();
                _spriteBatch.DrawString(myFont, "Your Score", new Vector2(600, 360), Color.White);
                _spriteBatch.DrawString(myFont, $"Targets Hit / Attempted shots {hittargets} / {attempts}", new Vector2(600, 400), Color.White);
                _spriteBatch.DrawString(myFont, "Please Exit the Game to try again!", new Vector2(600, 440), Color.White);
                _spriteBatch.End();

            }

        }
    }
}
