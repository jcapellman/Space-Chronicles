using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MysticChronicles.PCL.Enums;

namespace MysticChronicles.Android.GameStates {
    public class MainMenuState : BaseGameState {
        private bool _isLocked = true;

        public override GAME_STATES GetGameState() => GAME_STATES.MAIN_MENU;

        public override GAME_STATES EventOnBack() => GAME_STATES.EXIT;

        public override bool IsLocked() => _isLocked;

        public override void LoadContent(ContentManager contentManager) {
            LoadFont("GameFont", contentManager);
            LoadBackground("MainMenu", contentManager);

            PlayMusic("MainMenu", contentManager);
        }

        private int increment = 0;
        private string loadingText = "LOADING";

        private void RenderLoadingIndicator() {
            if (increment == 600) {
                increment = 0;
                loadingText = "LOADING";
            } else {
                increment += 1;

                for (var x = 0; x < increment / 100; x++) {
                    loadingText += ".";
                }
            }
        }

        public override void Render(SpriteBatch spriteBatch, ContentManager contentManager, GameWindow window, GraphicsDeviceManager graphics) {
            spriteBatch.Begin();

            spriteBatch.Draw(_background, destinationRectangle: graphics.GraphicsDevice.Viewport.Bounds, color: Color.White);

            if (IsLocked()) {
                RenderLoadingIndicator();
            }

            var textMiddlePoint = _gameFont.MeasureString(loadingText) / 2;

            var position = new Vector2(window.ClientBounds.Width / 2, window.ClientBounds.Height / 2);
            spriteBatch.DrawString(_gameFont, loadingText, position, Color.White, 0, textMiddlePoint, 5.0f,
                SpriteEffects.None, 0.5f);

            spriteBatch.End();
        }
    }
}