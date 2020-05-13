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
  { // The button class. Buttons know if they are clicked and how to fire off a method when clicked.

    private MouseState currentMouse;
    private MouseState previousMouse;

    private SpriteFont font;
    
    private bool isHovering;

    private Texture2D texture;

    public EventHandler Click;
    public bool Clicked
    { get; private set; }
    public float Layer
    { get; set; }

    public Vector2 Origin
    { get { return new Vector2(texture.Width / 2, texture.Height / 2); } }

    public Color PenColor
    { get; set; }
    public Vector2 Position
    { get; set; }

    public Rectangle ButtonRectangle
    {
      get
      {
        return new Rectangle((int)Position.X - ((int)Origin.X), (int)Position.Y - (int)Origin.Y, texture.Width, texture.Height);
      }
    }

    public string Text
    { get; set; }

    public Color penColor = Color.Black;
    public Color buttonColor = Color.White;
    public Color hoverColor = Color.Gray;

    public Button(Texture2D btnTexture, SpriteFont btnFont)
    {
      texture = btnTexture;
      font = btnFont;
    }
    

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    { // Draws the button. Draws it a different color if the mouse is on it.
      var color = buttonColor;
      if (isHovering)
      {
        color = hoverColor;
      }

      spriteBatch.Draw(texture, ButtonRectangle, color);

      if (!string.IsNullOrEmpty(Text))
      {
        // Finds the center of the button and goes back the length and height of the string (times it's scale multiplyer) so that the end result is properly centered text.
        var x = (ButtonRectangle.X + (ButtonRectangle.Width / 2)) - (font.MeasureString(Text).X * 3 / 2);
        var y = (ButtonRectangle.Y + (ButtonRectangle.Height / 2)) - (font.MeasureString(Text).Y * 3 / 2);

        spriteBatch.DrawString(font, Text, new Vector2(x, y), penColor,0,new Vector2(0,0), 3, 0, 0);
      }
    }

    public override void Update(GameTime gameTime)
    { // The method that does things.

      // Saves the mousestate from last tick as previousmouse so we can tell if the mouse state has changed.
      previousMouse = currentMouse;
      currentMouse = Mouse.GetState();

      var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);
      
      isHovering = false;

      // Checks if the mouse is over the button, checks if the mousestate changed, and fires off method if both of those things are true and there is a method to fire off.
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
