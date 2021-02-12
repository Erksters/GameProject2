using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace GameProject2
{
    class AimAndShootInputManager
    {
        public bool Exit { get; private set; } = false;

        private KeyboardState currentKeyboardState;
        private KeyboardState priorKeyboardState;

        public int Angle = 0;

        public bool Launched = false;

        public void reset()
        {
            Angle = 45;
        }
        public void Update(GameTime gameTime)
        {
            priorKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            //Direction = new Vector2(0, 0);

            ///Get Postion from Keyboard
        
            if (currentKeyboardState.IsKeyDown(Keys.Space) && priorKeyboardState.IsKeyUp(Keys.Space))
            {
                Launched = true;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Escape))
            {
                Exit = true;
            }

            //Up
            if (currentKeyboardState.IsKeyDown(Keys.Up) && priorKeyboardState.IsKeyUp(Keys.Up)
                || currentKeyboardState.IsKeyDown(Keys.W) && priorKeyboardState.IsKeyUp(Keys.W))
            {
                if (currentKeyboardState.IsKeyDown(Keys.LeftShift) || currentKeyboardState.IsKeyDown(Keys.RightShift))
                {
                    Angle += 4;
                }

                Angle++;
            }
            //Down
            if (currentKeyboardState.IsKeyDown(Keys.Down) && priorKeyboardState.IsKeyUp(Keys.Down)
                || currentKeyboardState.IsKeyDown(Keys.S) && priorKeyboardState.IsKeyUp(Keys.S))
            {
                if(currentKeyboardState.IsKeyDown(Keys.LeftShift) || currentKeyboardState.IsKeyDown(Keys.RightShift))
                {
                    Angle -= 4;
                }
                Angle--;
            }
        }
    }
}




    

