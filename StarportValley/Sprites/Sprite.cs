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
    protected Dictionary<string, Animation> _animations;

    protected Vector2 _position;
    private Texture2D _texture;
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
    public Input input;

    public float Speed = 2f;

    public Vector2 Velocity;

    public Sprite(Texture2D texture)
    {
      _texture = texture;
    }

    private void Move()
    {
      if (input == null)
      {
        return;
      }
      if (Keyboard.GetState().IsKeyDown(input.Left))
      {
        Velocity.X -= Speed;
      }
      if (Keyboard.GetState().IsKeyDown(input.Right))
      {
        Velocity.X += Speed;
      }
      if (Keyboard.GetState().IsKeyDown(input.Up))
      {
        Velocity.Y -= Speed;
      }
      if (Keyboard.GetState().IsKeyDown(input.Down))
      {
        Velocity.Y += Speed;
      }
    }
    public Sprite(Dictionary<string, Animation> animations)
    {
      _animations = animations;
      _animationManger = new AnimationManager(_animations.First().Value);
    }
    public void Update(GameTime gameTime, List<Sprite> sprites)
    {
      Move();
      if (Velocity.X > 0) 
       { 
          _animationManger.Play(_animations["WalkRight"]); 
       }
      else if (Velocity.X < 0)
       { 
        _animationManger.Play(_animations["WalkLeft"]); 
       }
      else 
       { 
        _animationManger.Stop(); 
      }
      _animationManger.Update(gameTime);

      Position += Velocity;
      Velocity = Vector2.Zero;

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
