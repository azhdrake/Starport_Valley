using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using StarportValley.Models;
using StarportValley.Sprites;
using StarportValley.States;

namespace StarportValley
{ // Game1.cs. This is where it all starts. 
  // The three slash comments come with the Game1 file when a new monogame project is made.

  /// <summary>
  /// This is the main type for your game.
  /// </summary>
  public class Game1 : Game
  {
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;

    public static int ScreenWidth = 1500;
    public static int ScreenHeight = 750;

    private State currentState;
    private State nextState;

    public void ChangeState(State state)
    {
      nextState = state;
    }
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
      IsMouseVisible = true;
      graphics.PreferredBackBufferWidth = ScreenWidth;
      graphics.PreferredBackBufferHeight = ScreenHeight;
      graphics.ApplyChanges();
      base.Initialize();
      
    }

    /// <summary>
    /// LoadContent will be called once per game and is the place to load
    /// all of your content.
    /// </summary>
    protected override void LoadContent()
    {
      spriteBatch = new SpriteBatch(GraphicsDevice);

      // This is what triggers the game opening on it's menu.
      currentState = new Menu(this, graphics.GraphicsDevice, Content);
      currentState.LoadContent();

      nextState = null;

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
      if(nextState != null)
      { // Checks to see if the gamestate needs changing, aka if someone pressed the start game button.
        currentState = nextState;
        currentState.LoadContent();

        nextState = null;
      }

      currentState.Update(gameTime);
      currentState.PostUpdate(gameTime);

      base.Update(gameTime);
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.DarkSalmon);

      currentState.Draw(gameTime, spriteBatch);

      base.Draw(gameTime);
    }
  }
}
