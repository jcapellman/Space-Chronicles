using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MysticChronicles.PCL.Enums;

namespace MysticChronicles.Android.GameStates {
    public abstract class BaseGameState {        
        public abstract GAME_STATES GetGameState();

        public abstract void LoadContent(ContentManager contentManager);

        public abstract void Render(SpriteBatch spriteBatch, ContentManager contentManager, GameWindow window, GraphicsDeviceManager graphics);
    }
}