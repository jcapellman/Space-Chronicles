using System;
using System.Reflection;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using MysticChronicles.Android.GameStates;
using MysticChronicles.PCL.Enums;

namespace MysticChronicles.Android {
    public class MainGame : Game {
        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
       
        private BaseGameState _currentGameState;

        public MainGame() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        private void changeGameState(GAME_STATES gameState) {
            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in types) {
                if (!type.IsSubclassOf(typeof(BaseGameState)) || type.IsAbstract) {
                    continue;
                }

                var bGameState = (BaseGameState)Activator.CreateInstance(type, spriteBatch, Window, graphics, Content);

                if (bGameState.GetGameState() != gameState) {
                    continue;
                }

                _currentGameState = bGameState;
                _currentGameState.OnChangeState += _currentGameState_OnChangeState;
                _currentGameState.LoadContent(this.Content);
            }
        }

        private void _currentGameState_OnChangeState(object sender, BaseGameState.GameStateArgs e) {
            changeGameState(e.GameState);
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            changeGameState(GAME_STATES.MAIN_MENU);
        }
        
        protected override void Update(GameTime gameTime) {
            if (_currentGameState.IsLocked()) {
                return;
            }
            
            var state = TouchPanel.GetState();

            foreach (var item in state) {
               if (_currentGameState.IsHit(item.Position)) {
                    return;
                }
            }

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            _currentGameState.Render();

            base.Draw(gameTime);
        }
    }
}