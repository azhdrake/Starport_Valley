using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StarportValley.Models;
using StarportValley.Sprites;
using StarportValley.Plants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarportValley.States
{
  class GameState : State
  {
    // The gamestate, as in the state the game is in when playing happens.
    private SpriteBatch spriteBatch;
    private List<Sprite> sprites;
    private List<Component> components;

    public GameState(Game1 stateGame, GraphicsDevice stateGraphicsDevice, ContentManager stateContent) : base(stateGame, stateGraphicsDevice, stateContent)
    {
    }
    public override void LoadContent()
    { // LoadContent, where you create the content that will be used in the game such as spirtes.

      // The spritebatch deals with drawing 2D sprites. 
      spriteBatch = new SpriteBatch(graphicsDevice);

      // Animation dictionaries for our sprites
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

      // An array containing all the growth states sprites of the plant.
      Texture2D[] testPlantTextures = { content.Load<Texture2D>("Plant0"), content.Load<Texture2D>("Plant1"), content.Load<Texture2D>("Plant2")};
      
      Plant test_plant = new Plant("Test Plant", testPlantTextures, 0, 0);
      test_plant.Position = new Vector2(300, 300);

      // List of components so we can do things to all components, like test for colisions.
      components = new List<Component>()
      {
        test_plant,
        new MobileSprite(sethanie_animations)
          {
            input = new Input()
            {
              Up       = Keys.W,
              Down     = Keys.S,
              Left     = Keys.A,
              Right    = Keys.D,
              Interact = Keys.Q
            },
            Position = new Vector2(100, 200),
            Speed = 4f
          },
        new MobileSprite(animations)
          {
            input = new Input()
            {
              Up       = Keys.Up,
              Down     = Keys.Down,
              Left     = Keys.Left,
              Right    = Keys.Right,
              Interact = Keys.RightShift
            },
            Position = new Vector2(200, 200),
            Speed = 8f
          }
      };
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    { // The draw method redraws the screen every frame.

      sprites = new List<Sprite>();

      foreach(var component in components)
      { // What this is doing is checking what each sprite should look like depending on the sprite's type. For a plant it checks the plants current appearance. For a mobilesprite it just adds the sprite to the sprites list to be drawn, as mobilesprites' animation managers take care of changes to their appearances.
        if (component.GetType().Equals(typeof(Plant)))
        {
          Plant plant = (Plant)component;
          sprites.Add(plant);
        }
        else if (component.GetType().Equals(typeof(MobileSprite)))
        {
          MobileSprite mobileSprite = (MobileSprite)component;
          sprites.Add(mobileSprite);
        }
      }

      spriteBatch.Begin(); // Drawing.... START
      foreach (var sprite in sprites)
      {
        sprite.Draw(gameTime, spriteBatch);
      }
      spriteBatch.End(); // Drawing.... END
    }

    public override void PostUpdate(GameTime gameTime)
    {// This method is for cleanup things that are beyond the scope of the game as of now.
      
    }

    public override void Update(GameTime gameTime)
    { // The Update method. It's where things happen!™

      sprites = new List<Sprite>();

      // groups all the mobilesprites
      foreach (var component in components)
      {
        if (component.GetType().Equals(typeof(Plant)))
        {
          Plant plant = (Plant)component;
          sprites.Add(plant);
        }
        if (component.GetType().Equals(typeof(MobileSprite)))
        {
          MobileSprite sprite = (MobileSprite)component;
          sprites.Add(sprite);
        }
      }

      foreach (var sprite in sprites)
      {
        // Runs each sprite's update method.
        sprite.Update(gameTime, sprites);
      }
      if (Keyboard.GetState().IsKeyDown(Keys.Escape))
      { // Quit method
        game.ChangeState(new Menu(game, graphicsDevice, content)); 
      }
    }
  }
}
