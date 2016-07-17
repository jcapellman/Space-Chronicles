using System;
using Android.OS;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

using MysticChronicles.PCL.Enums;

namespace MysticChronicles.Android.GameStates {
    public abstract class BaseGameState {        
        public abstract GAME_STATES GetGameState();

        public abstract void LoadContent(ContentManager contentManager);

        public abstract void Render(SpriteBatch spriteBatch, ContentManager contentManager, GameWindow window, GraphicsDeviceManager graphics);

        public abstract GAME_STATES EventOnBack();

        public abstract bool IsLocked();

        public class GameStateArgs : EventArgs {
            public GameStateArgs(GAME_STATES gameState) {
                GameState = gameState;
            }

            public GAME_STATES GameState { get; }
        }


        public delegate void ChangeStateHandler(object sender, GameStateArgs e);

        public event ChangeStateHandler OnChangeState;

        protected void ChangeState(GAME_STATES gameState) {
            OnChangeState(this, new GameStateArgs(gameState));
        }

        private string ContentName => GetGameState().ToString().Replace("_", "");

        private Song _bgMusic;

        public void PlayMusic(ContentManager cManager) {
            PlayMusic(ContentName, cManager);
        }

        public void PlayMusic(string song, ContentManager cManager) {
            _bgMusic = cManager.Load<Song>($"Music/{song}");

            MediaPlayer.Play(_bgMusic);
            MediaPlayer.IsRepeating = true;
        }

        protected SpriteFont _gameFont;

        public void LoadFont(string fontName, ContentManager cManager) {
            _gameFont = cManager.Load<SpriteFont>($"Fonts/{fontName}");
        }
        
        protected Texture2D _background;

        public void LoadBackground(ContentManager cManager) {
            LoadBackground(ContentName, cManager);
        }

        public void LoadBackground(string name, ContentManager cManager) {
            _background = LoadTexture2D($"Backgrounds/{name}", cManager);
        }

        public Texture2D LoadTexture2D(string textureName, ContentManager cManager) {
            return cManager.Load<Texture2D>(textureName);
        }
    }
}