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

        public Vector2 Angle = new Vector2(90,0);

        public bool Launched = false;

        public bool Reset = false;

        public void ResetGame()
        {
            Angle = new Vector2(90, 0);
            Launched = false;
            Reset = false;
        }
        public void Update(GameTime gameTime)
        {
            priorKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

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
                if (Angle.X >= 0 && Angle.Y < 1)
                {
                    Angle = new Vector2(Angle.X - 5, Angle.Y - 5);
                }

                else if (Angle.X >= 0 && Angle.Y > -1)
                {
                    Angle = new Vector2(Angle.X + 5, Angle.Y - 5);
                }
                else { }
            }
            //Down
            if (currentKeyboardState.IsKeyDown(Keys.Down) && priorKeyboardState.IsKeyUp(Keys.Down)
                || currentKeyboardState.IsKeyDown(Keys.S) && priorKeyboardState.IsKeyUp(Keys.S))
            {

                if (Angle.X >= 0 && Angle.Y > -1)
                {
                    Angle = new Vector2(Angle.X - 5, Angle.Y + 5);
                }

                else if (Angle.X >= 0 && Angle.Y < 1)
                {
                    Angle = new Vector2(Angle.X + 5, Angle.Y + 5);
                }
                //else { }
            };

            //Reset
            if (currentKeyboardState.IsKeyDown(Keys.R) && priorKeyboardState.IsKeyUp(Keys.R))
            {
                Reset = true;
            }


        }
    }
}




    

