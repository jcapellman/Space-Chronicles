using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MysticChronicles.Android.UI {
    public abstract class BaseUIControl {
        internal GameWindow _gameWindow;
        internal SpriteFont _gameFont;
        internal Vector2 _position;

        protected void DrawText(SpriteBatch _spriteBatch, string text, Vector2? position, Color color, float size, Vector2? origin) {
            if (origin == null) {
                origin = _gameFont.MeasureString(text) / 2;
            }

            if (position == null) {
                position = new Vector2(_gameWindow.ClientBounds.Width / 2, _gameWindow.ClientBounds.Height / 2);
            }

            _spriteBatch.DrawString(_gameFont, text, position.Value, Color.White, 0, origin.Value, size, SpriteEffects.None, 0.5f);
        }

        public bool IsHit(Vector2 position) {
            return false;
        }

        public abstract void Render(SpriteBatch spriteBatch);
    }
}