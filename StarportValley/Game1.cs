using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using StarportValley.Models;
using StarportValley.Sprites;

namespace StarportValley
{
  /// <summary>
  /// This is the main type for your game.
  /// </summary>
  public class Game1 : Game
  {
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    KeyboardState previousKeyboardState;
    MouseState previousMouseState;
    private List<Sprite> _sprites;

    public Game1()
    {
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
    }

    /// <summary>
    /// Allows the game to perform any initialization it needs to before starting to run.
    /// This is where it can query for any required services and load any non-graphic
    /// related content.  Calling base.Initialize will enumerate through any components
    /// and initialize them as well.
    /// </summary>
    protected override void Initialize()
    {
      // TODO: Add your initialization logic here

      base.Initialize();
      previousKeyboardState = Keyboard.GetState();
      previousMouseState = Mouse.GetState();
    }

    /// <summary>
    /// LoadContent will be called once per game and is the place to load
    /// all of your content.
    /// </summary>
    protected override void LoadContent()
    {
      spriteBatch = new SpriteBatch(GraphicsDevice);
      var animations = new Dictionary<string, Animation>()
      {
        {"WalkRight", new Animation(Content.Load<Texture2D>("TestWalkingSprite"), 4) },
        {"WalkLeft", new Animation(Content.Load<Texture2D>("TestWalkingSpriteLeft"), 4) }
      };
      var sethanie_animations = new Dictionary<string, Animation>()
      {
        { "WalkRight", new Animation(Content.Load<Texture2D>("sethanie_walk_right"), 4) },
        { "WalkLeft", new Animation(Content.Load<Texture2D>("sethanie_walk_left"), 4) }
      };

      _sprites = new List<Sprite>()
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

    /// <summary>
    /// UnloadContent will be called once per game and is the place to unload
    /// game-specific content.
    /// </summary>
    protected override void UnloadContent()
    {
      // TODO: Unload any non ContentManager content here
    }

    /// <summary>
    /// Allows the game to run logic such as updating the world,
    /// checking for collisions, gathering input, and playing audio.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Update(GameTime gameTime)
    {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        Exit();
      foreach (var sprite in _sprites)
      {
        sprite.Update(gameTime, _sprites);
      }

      // TODO: Add your update logic here

      base.Update(gameTime);
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.DarkSalmon);

      // TODO: Add your drawing code here
      spriteBatch.Begin();
      foreach (var sprite in _sprites)
      {
        sprite.Draw(spriteBatch);
      }
      spriteBatch.End();

      base.Draw(gameTime);
    }
  }
}
