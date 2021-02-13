using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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

        public BulletJourney()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            AimInputManager = new AimAndShootInputManager();
            targets = new List<Target>();
            targets.Add(new Target(new Vector2(650, 200)));
            bullet = new Bullet(new Vector2(100, 400), 0);
            weapon = new Weapon(new Vector2(100, 430), 0);
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

            // TODO: use this.Content to load your game content here
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
                    AimInputManager.ResetGame();
                    bullet.ResetGame(new Vector2(100, 400));
                    weapon.ResetGame();
                }
            }

            if (AimInputManager.Reset)
            {
                AimInputManager.ResetGame();
                bullet.ResetGame(new Vector2(100, 400));
                weapon.ResetGame();
            }

            bullet.Update(gameTime, AimInputManager.Angle, AimInputManager.Launched);
            weapon.Update(AimInputManager.Angle);

           
            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.DrawString(myFont, $"Direction {AimInputManager.Angle}", new Vector2(30,30),Color.Black);
            foreach (var target in targets)
            {
                target.Draw(_spriteBatch);
            }
            bullet.Draw(gameTime, _spriteBatch);
            weapon.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
