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

        public BulletJourney()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            AimInputManager = new AimAndShootInputManager();
            targets = new List<Target>();
            targets.Add(new Target(new Vector2(200, 200)));
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

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            AimInputManager.Update(gameTime);
            base.Update(gameTime);
            foreach (var target in targets)
            {
                //target.Update();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.DrawString(myFont, $"Direction {AimInputManager.Angle}", new Vector2(30,30),Color.Black);
            foreach (var target in targets)
            {
                target.Draw(gameTime, _spriteBatch);
            }
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
