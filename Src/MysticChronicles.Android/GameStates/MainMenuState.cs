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

        public MainMenuState(SpriteBatch spriteBatch, GameWindow window, GraphicsDeviceManager graphics, ContentManager contentManager) : base(spriteBatch, window, graphics, contentManager) { }

        public override async void LoadContent(ContentManager contentManager) {
            LoadFont("GameFont", contentManager);
            LoadBackground(contentManager);

            PlayMusic(contentManager);

            // todo swap this out for google oauth
            var playProfileHandler = new PlayerProfileHandler(PCL.Common.Constants.PLAYER_TOKEN);

            var profile = await playProfileHandler.GetProfile();

            if (profile.HasError) {
                return;
            }

            GlobalGame.PlayerProfile = profile.ReturnValue;

            ChangeState(GAME_STATES.MAIN_GAME);
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

        public override void Render() {
            _spriteBatch.Begin();

            DrawBackground();

            if (IsLocked()) {
                RenderLoadingIndicator();
            }

            DrawText(loadingText, null, Color.White, 5.0f, null);

            _spriteBatch.End();
        }
    }
}