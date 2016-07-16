using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MysticChronicles.Android.GameStates;
using MysticChronicles.PCL.Enums;

namespace MysticChronicles.Android {
    public class MainGame : Game {
        GraphicsDeviceManager graphics;
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

                if (bGameState.GetGameState() == gameState)  {
                    _currentGameState = bGameState;

                    _currentGameState.LoadContent(this.Content);
                }
            }
        }
        
        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            changeGameState(GAME_STATES.MAIN_MENU);
        }
        
        protected override void UnloadContent() {
            
        }
        
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            _currentGameState.Render(spriteBatch, this.Content, Window, graphics);

            base.Draw(gameTime);
        }
    }
}