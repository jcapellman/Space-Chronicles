using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MysticChronicles.PCL.Enums;

namespace MysticChronicles.Android.GameStates {
    public class MainGameState : BaseGameState {
        public override GAME_STATES GetGameState() => GAME_STATES.MAIN_GAME;

        public override GAME_STATES EventOnBack() => GAME_STATES.MAIN_MENU;

        public MainGameState(SpriteBatch spriteBatch, GameWindow window, GraphicsDeviceManager graphics) : base(spriteBatch, window, graphics) { }

        public override bool IsLocked() {
            return false;
        }

        public override void LoadContent(ContentManager contentManager) {
            LoadFont("GameFont", contentManager);
            LoadBackground(contentManager);
        }

        public override void Render() {
            _spriteBatch.Begin();

            DrawBackground();
            DrawText($"Level: {GlobalGame.PlayerProfile.Level} | Exp: {GlobalGame.PlayerProfile.Experience} | Credits: {GlobalGame.PlayerProfile.Credits} | Events: {GlobalGame.PlayerProfile.EventTurns}", null, Color.White, 5.0f, null);

            _spriteBatch.End();
        }        
    }
}