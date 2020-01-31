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
  public class Sprite
  {
    protected AnimationManager _animationManger;
    protected Dictionary<string, Animation> spriteAnimations;

    protected Vector2 _position;
    private Texture2D _texture;

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
        if (_animationManger != null)
        {
          _animationManger.Position = _position;
        }
      }
    }
   
    public Sprite(Dictionary<string, Animation> animations)
    {
      spriteAnimations = animations;
      _animationManger = new AnimationManager(spriteAnimations.First().Value);
    }

    public Sprite(Texture2D texture)
    {
      _texture = texture;
    }

    public virtual void Update(GameTime gameTime, List<Sprite> sprites)
    {

    }

    public void Draw(SpriteBatch spriteBatch)
      {
        if (_texture != null)
        {
          spriteBatch.Draw(_texture, Position, Color.White);
        }
        else if (_animationManger != null)
        {
          _animationManger.Draw(spriteBatch);
        }
        else throw new Exception("Somethings wrong in Sprite.Draw");
      }
  }
}
