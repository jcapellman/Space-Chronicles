using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MysticChronicles.PCL.Enums;
using MysticChronicles.PCL.Handlers;

namespace MysticChronicles.Android.GameStates {
    public class MainMenuState : BaseGameState {
        private bool _isLocked = true;

        public override GAME_STATES GetGameState() => GAME_STATES.MAIN_MENU;

        public override GAME_STATES EventOnBack() => GAME_STATES.EXIT;

        public override bool IsLocked() => _isLocked;

        public override async void LoadContent(ContentManager contentManager) {
            LoadFont("GameFont", contentManager);
            LoadBackground(contentManager);

            PlayMusic(contentManager);

            var playProfileHandler = new PlayerProfileHandler(PCL.Common.Constants.PLAYER_TOKEN);

            var profile = await playProfileHandler.GetProfile();

            if (!profile.HasError) {
                ChangeState(GAME_STATES.MAIN_GAME);
            }
        }

        private int increment = 0;
        private string loadingText = "LOADING";

        private void RenderLoadingIndicator() {
            if (increment == 100) {
                increment = 0;
                loadingText = "LOADING";
            } else {
                increment += 1;

                if (increment % 10 == 0) {                
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