using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MysticChronicles.PCL.Enums;

namespace MysticChronicles.Android.UI {
    public class ActionButtonControl : BaseUIControl {
        private Vector2 _textPosition;
        private Texture2D _buttonTexture;
        private string _text;
        private Color _color;

        public ActionButtonControl(GameWindow window, SpriteFont gameFont, Texture2D buttonTexture, string text, Color color, TEXT_HORIZONTAL_ALIGNMENT hAlign, TEXT_VERTICAL_ALIGNMENT vAlign, int xOffset = 0, int yOffset = 0) {
            _buttonTexture = buttonTexture;
            _text = text;
            _color = color;
            _gameWindow = window;
            _gameFont = gameFont;

            _position = new Vector2();

            switch (hAlign) {
                case TEXT_HORIZONTAL_ALIGNMENT.CENTER:
                    _position.X = window.ClientBounds.Width / 2;
                    break;
                case TEXT_HORIZONTAL_ALIGNMENT.LEFT:
                    _position.X = 0 + xOffset;
                    break;
                case TEXT_HORIZONTAL_ALIGNMENT.RIGHT:
                    _position.X = window.ClientBounds.Width - _buttonTexture.Width - 10 - xOffset;
                    break;
            }

            switch (vAlign) {
                case TEXT_VERTICAL_ALIGNMENT.BOTTOM:
                    _position.Y = window.ClientBounds.Height - _buttonTexture.Height;
                    break;
                case TEXT_VERTICAL_ALIGNMENT.CENTER:
                    _position.Y = window.ClientBounds.Height / 2;
                    break;
                case TEXT_VERTICAL_ALIGNMENT.TOP:
                    _position.Y = yOffset;
                    break;
            }

            var textWidth = gameFont.MeasureString(text).X;
            var textHeight = gameFont.MeasureString(text).Y;

            _textPosition = new Vector2();

            _textPosition.X = _position.X + ((_buttonTexture.Width - textWidth) / 2) + 20;
            _textPosition.Y = _position.Y + ((_buttonTexture.Height - textHeight) / 2) + 10;
        }
        
        public override void Render(SpriteBatch spriteBatch) {
            spriteBatch.Draw(_buttonTexture, _position, Color.White);
            DrawText(spriteBatch, _text, _textPosition, _color, 3.0f, null);
        }
    }
}