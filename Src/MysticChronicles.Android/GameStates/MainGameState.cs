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

        private Texture2D _metricTexture;
        private Texture2D _CreditsIcon;
        private Texture2D _TurnsIcon;
        private Texture2D _windowTexture;
        private Texture2D _menuButton;
        private Texture2D _solarSystemTexture;
        private Texture2D _shipWindowTexture;
        private Texture2D _playerShipTexture;
        
        public override void LoadContent(ContentManager contentManager) {
            LoadFont("GameFont", contentManager);
            LoadButton(contentManager);

            _metricTexture = LoadUITexture("GameMetricButton", contentManager);
            _CreditsIcon = LoadUITexture("CreditsIcon", contentManager);
            _TurnsIcon = LoadUITexture("TurnsIcon", contentManager);
            _windowTexture = LoadUITexture("GameWindow", contentManager);
            _menuButton = LoadUITexture("MenuButton", contentManager);
            _solarSystemTexture = LoadUITexture("SolarSystemWindow", contentManager);
            _shipWindowTexture = LoadUITexture("ShipWindow", contentManager);
            _playerShipTexture = LoadTexture2D("Ships/Blocky", contentManager);
            
            LoadBackground(contentManager);

            LoadSolarSystemMap(contentManager);
        }
        
        private void DrawMetric(string text, Texture2D icon, int xOrigin) {
            var position = new Vector2 {
                Y = 0,
                X = (xOrigin*450) + 5
            };

            var textPosition = new Vector2 {
                Y = 25,
                X = position.X + 110
            };

            var iconPosition = new Vector2 {
                Y = 15,
                X = position.X + 20
            };

            _spriteBatch.Draw(_metricTexture, position, Color.White);
            _spriteBatch.Draw(icon, iconPosition, Color.White);
            DrawText(text, textPosition, Color.White, 3.0f, Vector2.Zero);
        }
        
        public override void Render() {
            _spriteBatch.Begin();

            DrawBackground();

            DrawMetric($"{GlobalGame.PlayerProfile.Level}", _TurnsIcon, 0);
            DrawMetric($"{GlobalGame.PlayerProfile.Experience}", _CreditsIcon, 1);
            DrawMetric($"{GlobalGame.PlayerProfile.Credits}", _CreditsIcon, 2);
            DrawMetric($"{GlobalGame.PlayerProfile.EventTurns}", _TurnsIcon, 3);

            DrawUIElement(_menuButton, TEXT_HORIZONTAL_ALIGNMENT.RIGHT, TEXT_VERTICAL_ALIGNMENT.TOP);
            DrawUIElement(_solarSystemTexture, TEXT_HORIZONTAL_ALIGNMENT.RIGHT, TEXT_VERTICAL_ALIGNMENT.BOTTOM);
            DrawUIElement(_shipWindowTexture, TEXT_HORIZONTAL_ALIGNMENT.LEFT, TEXT_VERTICAL_ALIGNMENT.BOTTOM);

            DrawButton("UPGRADE", Color.White, TEXT_HORIZONTAL_ALIGNMENT.LEFT, TEXT_VERTICAL_ALIGNMENT.TOP, 100, 650);
            DrawButton("BUY NEW", Color.White, TEXT_HORIZONTAL_ALIGNMENT.LEFT, TEXT_VERTICAL_ALIGNMENT.TOP, 100, 775);
            DrawButton("WARP", Color.White, TEXT_HORIZONTAL_ALIGNMENT.LEFT, TEXT_VERTICAL_ALIGNMENT.TOP, 100, 950);

            DrawUIElement(_playerShipTexture, TEXT_HORIZONTAL_ALIGNMENT.LEFT, TEXT_VERTICAL_ALIGNMENT.TOP, 100, 250);

            DrawText("Blunky Class 1", 3.0f, TEXT_HORIZONTAL_ALIGNMENT.LEFT, TEXT_VERTICAL_ALIGNMENT.CENTER, Color.White, 125, -25);

            DrawText(GlobalGame.CurrentSolarSystem, 3.0f, TEXT_HORIZONTAL_ALIGNMENT.LEFT, TEXT_VERTICAL_ALIGNMENT.TOP, Color.White, 1075, 200);

            DrawSolarSystemMap();

            _spriteBatch.End();
        }        
    }
}