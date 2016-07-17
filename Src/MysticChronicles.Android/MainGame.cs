using System;
using System.Linq;
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

        protected override void Initialize() {            
            base.Initialize();
        }

        private void changeGameState(GAME_STATES gameState) {
            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in types) {
                if (!type.IsSubclassOf(typeof(BaseGameState)) || type.IsAbstract) {
                    continue;
                }

                var bGameState = (BaseGameState)Activator.CreateInstance(type);

                if (bGameState.GetGameState() != gameState) {
                    continue;
                }

                _currentGameState = bGameState;

                _currentGameState.LoadContent(this.Content);
            }
        }
        
        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            changeGameState(GAME_STATES.MAIN_MENU);
        }
        
        protected override void UnloadContent() {
            
        }
        
        protected override void Update(GameTime gameTime) {
            if (_currentGameState.IsLocked()) {
                return;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) {
                var eventState = _currentGameState.EventOnBack();

                if (eventState == GAME_STATES.EXIT) {
                    Exit();
                } else {
                    changeGameState(eventState);
                }
            }

            var state = TouchPanel.GetState();

            if (state.Any()) {
                changeGameState(GAME_STATES.MAIN_GAME);
            }

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            _currentGameState.Render(spriteBatch, this.Content, Window, graphics);

            base.Draw(gameTime);
        }
    }
}