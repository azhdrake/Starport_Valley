using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarportValley.Managers;
using StarportValley.Models;

namespace StarportValley
{
  public class Sprite : Component
  { // The sprite class. For when you need something that looks like something.

    protected AnimationManager animationManger;
    protected Dictionary<string, Animation> spriteAnimations;

    protected Vector2 _position;
    protected Texture2D _texture;

    public virtual Rectangle HitBox
    {
      get
      {
        return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
      }
    }

    public Vector2 Position
    {
      get { return _position; }
      set
      {
        _position = value;
        if (animationManger != null)
        {
          animationManger.Position = _position;
        }
      }
    }
   
    public Sprite(Dictionary<string, Animation> animations)
    { // Constuctor for mobile sprites
      spriteAnimations = animations;
      animationManger = new AnimationManager(spriteAnimations.First().Value);
    }

    public Sprite(Texture2D texture)
    { // Constructor fo stationary sprites.
      _texture = texture;
    }
    public Sprite(Texture2D[] textures)
    { // Constructor fo stationary sprites with multiple textures.
      _texture = textures[0];
    }
    public virtual void Update(GameTime gameTime, List<Sprite> sprites)
    {

    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
      {
        if (_texture != null)
        {
          spriteBatch.Draw(_texture, Position, Color.White);
        }
        else if (animationManger != null)
        {
          animationManger.Draw(spriteBatch);
        }
        else throw new Exception("Somethings wrong in Sprite.Draw");
      }

    public override void Update(GameTime gameTime)
    {
    }
  }
}
