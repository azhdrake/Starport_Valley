using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StarportValley.Models;
using StarportValley.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarportValley.States
{
  class GameState : State
  {
    private SpriteBatch spriteBatch;
    private List<Component> gameComponents;
    
    MouseState previousMouseState;
    private List<Sprite> sprites;


    public GameState(Game1 stateGame, GraphicsDevice stateGraphicsDevice, ContentManager stateContent) : base(stateGame, stateGraphicsDevice, stateContent)
    {
    }
    public override void LoadContent()
    {
      spriteBatch = new SpriteBatch(graphicsDevice);
      var animations = new Dictionary<string, Animation>()
      {
        {"WalkRight", new Animation(content.Load<Texture2D>("TestWalkingSprite"), 4) },
        {"WalkLeft", new Animation(content.Load<Texture2D>("TestWalkingSpriteLeft"), 4) }
      };
      var sethanie_animations = new Dictionary<string, Animation>()
      {
        { "WalkRight", new Animation(content.Load<Texture2D>("sethanie_walk_right"), 4) },
        { "WalkLeft", new Animation(content.Load<Texture2D>("sethanie_walk_left"), 4) }
      };

      sprites = new List<Sprite>()
      {
        new MobileSprite(sethanie_animations)
          {
            input = new Input()
            {
              Up = Keys.W,
              Down = Keys.S,
              Left = Keys.A,
              Right = Keys.D
            },
            Position = new Vector2(100, 200),
            Speed = 4f
          },
        new MobileSprite(animations)
          {
            input = new Input()
            {
              Up = Keys.Up,
              Down = Keys.Down,
              Left = Keys.Left,
              Right = Keys.Right
            },
            Position = new Vector2(200, 200),
            Speed = 8f
          }
      };
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.Begin();
      foreach (var sprite in sprites)
      {
        sprite.Draw(gameTime, spriteBatch);
      }
      spriteBatch.End();
    }

    public override void PostUpdate(GameTime gameTime)
    {
      
    }

    public override void Update(GameTime gameTime)
    {
      foreach (var sprite in sprites)
      {
        sprite.Update(gameTime, sprites);
      }
    }
  }
}
