using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarportValley.Controls
{
  public class Button : Component
  {

    private MouseState currentMouse;
    private MouseState previousMouse;

    private SpriteFont font;
    
    private bool isHovering;

    private Texture2D texture;

    public EventHandler Click;
    public bool Clicked
    {
      get;
      private set;
    }
    public float Layer
    {
      get; 
      set;
    }

    public Vector2 Origin
    {
      get
      {
        return new Vector2(texture.Width / 2, texture.Height / 2);
      }
    }

    public Color PenColor
    {
      get;
      set;
    }
    public Vector2 Position
    {
      get;
      set;
    }

    public Rectangle ButtonRectangle
    {
      get
      {
        return new Rectangle((int)Position.X - ((int)Origin.X), (int)Position.Y - (int)Origin.Y, texture.Width, texture.Height);
      }
    }

    public string Text
    {
      get;
      set;
    }

    public Button(Texture2D btnTexture, SpriteFont btnFont, Color txtColor)
    {
      texture = btnTexture;
      font = btnFont;
      PenColor = txtColor;
    }
    

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      var color = Color.White;
      if (isHovering)
      {
        color = Color.Gray;
      }

      spriteBatch.Draw(texture, ButtonRectangle, color);

      if (!string.IsNullOrEmpty(Text))
      {
        // Finds the center of the button and goes back the length and height of the string (times it's scale multiplyer) so that the end result is properly centered text.
        var x = (ButtonRectangle.X + (ButtonRectangle.Width / 2)) - (font.MeasureString(Text).X * 3 / 2);
        var y = (ButtonRectangle.Y + (ButtonRectangle.Height / 2)) - (font.MeasureString(Text).Y * 3 / 2);

        spriteBatch.DrawString(font, Text, new Vector2(x, y), PenColor,0,new Vector2(0,0), 3, 0, 0);
      }
    }

    public override void Update(GameTime gameTime)
    {
      previousMouse = currentMouse;
      currentMouse = Mouse.GetState();

      var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);
      
      isHovering = false;
      if (mouseRectangle.Intersects(ButtonRectangle))
      {
        isHovering = true;

        if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
        {
          if (Click != null)
          {
            Click(this, new EventArgs());
          }
        }
      }
    }
  }
}
