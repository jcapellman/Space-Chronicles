using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MysticChronicles.PCL.Enums;

namespace MysticChronicles.Android.GameStates {
    public class MainGameState : BaseGameState {
        private Texture2D _background;

        public override GAME_STATES GetGameState() => GAME_STATES.MAIN_GAME;

        public override GAME_STATES EventOnBack() => GAME_STATES.MAIN_MENU;

        public override void LoadContent(ContentManager contentManager) {
            _background = contentManager.Load<Texture2D>("Backgrounds/MainGame");
        }

        public override void Render(SpriteBatch spriteBatch, ContentManager contentManager, GameWindow window, GraphicsDeviceManager graphics) {
            spriteBatch.Begin();

            spriteBatch.Draw(_background, destinationRectangle: graphics.GraphicsDevice.Viewport.Bounds, color: Color.White);

            spriteBatch.End();
        }        
    }
}