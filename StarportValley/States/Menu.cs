using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using StarportValley.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarportValley.States
{
  public class Menu : State
  {
    private List<Component> components;
    public Menu(Game1 menuGame, GraphicsDevice menuGraphicsDevice, ContentManager menuContent) : base(menuGame, menuGraphicsDevice, menuContent)
    {
      
    }

    public override void LoadContent()
    {
      var buttonTexture = content.Load<Texture2D>("button");
      var buttonFont = content.Load<SpriteFont>("Fonts/Font");

      Button newGameButton = new Button(buttonTexture, buttonFont, Color.Black)
      {
        Position = new Vector2(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2 - 100),
        Text = "New Game",
        Click = new EventHandler(NewGameButton_Click)
      };
      Button quitButton = new Button(buttonTexture, buttonFont, Color.Red)
      {
        Position = new Vector2(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2 + 100),
        Text = "Quit",
        Click = new EventHandler(QuitButton_Click)
      };

      components = new List<Component>()
      {
        newGameButton,
        quitButton
      };
    }

    private void NewGameButton_Click(object sender, EventArgs e)
    {
      game.ChangeState(new GameState(game, graphicsDevice, content));
    }

    private void QuitButton_Click(object sender, EventArgs e)
    {
      game.Exit();
    }
    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.Begin();

      foreach(var component in components)
      {
        component.Draw(gameTime, spriteBatch);
      }

      spriteBatch.End();
    }

    public override void PostUpdate(GameTime gameTime)
    {
      
    }

    public override void Update(GameTime gameTime)
    {
      foreach (var component in components)
        component.Update(gameTime);
    }
  }
}
