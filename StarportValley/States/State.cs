using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarportValley.States
{
  public abstract class State
  {
    protected ContentManager content;
    protected GraphicsDevice graphicsDevice;
    protected Game1 game;

    public abstract void LoadContent();
    public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    public abstract void Update(GameTime gameTime);
    public abstract void PostUpdate(GameTime gameTime);

    public State(Game1 stateGame, GraphicsDevice stateGraphicsDevice, ContentManager stateContent)
    {
      game = stateGame;
      graphicsDevice = stateGraphicsDevice;
      content = stateContent;
    }
  }
}
