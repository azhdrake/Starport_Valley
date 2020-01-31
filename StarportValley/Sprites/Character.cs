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

namespace StarportValley.Sprites
{
  public class Character : Sprite
  {
    public Character(Dictionary<string, Animation> animations) : base(animations)
    {

    }

    public void Move()
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

    public override void Update(GameTime gameTime, List<Sprite> sprites)
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
  }
}
