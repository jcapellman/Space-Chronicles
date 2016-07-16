using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

using MysticChronicles.PCL.Enums;

namespace MysticChronicles.Android.GameStates {
    public class MainMenuState : BaseGameState {
        private SpriteFont _font;
        private Texture2D _background;
        private Texture2D _uiButton;
        private Song _music;
        
        public override GAME_STATES GetGameState() => GAME_STATES.MAIN_MENU;

        public override GAME_STATES EventOnBack() => GAME_STATES.EXIT;
        
        public override void LoadContent(ContentManager contentManager) {
            _font = contentManager.Load<SpriteFont>("Fonts/GameFont");
            _background = contentManager.Load<Texture2D>("Backgrounds/MainMenu");
            _uiButton = contentManager.Load<Texture2D>("UI/Button");
            _music = contentManager.Load<Song>("Music/MainMenu");

            MediaPlayer.Play(_music);
            MediaPlayer.IsRepeating = true;
        }

        public override void Render(SpriteBatch spriteBatch, ContentManager contentManager, GameWindow window, GraphicsDeviceManager graphics) {
            spriteBatch.Begin();

            spriteBatch.Draw(_background, destinationRectangle: graphics.GraphicsDevice.Viewport.Bounds, color: Color.White);

            var text = "TAP ANYWHERE TO PLAY";
            
            Vector2 textMiddlePoint = _font.MeasureString(text) / 2;
            
            Vector2 position = new Vector2(window.ClientBounds.Width / 2, window.ClientBounds.Height / 2);
            spriteBatch.DrawString(_font, text, position, Color.White, 0, textMiddlePoint, 3.0f,
                SpriteEffects.None, 0.5f);
            
            spriteBatch.End();
        }        
    }
}