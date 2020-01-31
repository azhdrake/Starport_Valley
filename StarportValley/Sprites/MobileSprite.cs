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
  public class MobileSprite : Sprite
  {
    int spriteWidth;
    int spriteHeight;
    public MobileSprite(Dictionary<string, Animation> animations) : base(animations)
    {
      this.spriteHeight = animations["WalkRight"].FrameHeight;
      this.spriteWidth = animations["WalkLeft"].FrameWidth;
    }

    public Input input;
    public float Speed = 4f;
    public Vector2 Velocity;

    public override Rectangle HitBox
    {
      get
      {
        return new Rectangle((int)Position.X, (int)Position.Y, spriteWidth, spriteHeight);
      }
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

    // Collision
    protected bool isTouchingLeft(Sprite sprite)
    {
      return this.HitBox.Right + this.Velocity.X > sprite.HitBox.Left &&
        this.HitBox.Left < sprite.HitBox.Left &&
        this.HitBox.Bottom > sprite.HitBox.Top &&
        this.HitBox.Top < sprite.HitBox.Bottom;
    }
    protected bool isTouchingRight(Sprite sprite)
    {
      return this.HitBox.Left + this.Velocity.X < sprite.HitBox.Right &&
        this.HitBox.Right > sprite.HitBox.Right &&
        this.HitBox.Bottom > sprite.HitBox.Top &&
        this.HitBox.Top < sprite.HitBox.Bottom;
    }
    protected bool isTouchingTop(Sprite sprite)
    {
      return this.HitBox.Bottom + this.Velocity.Y > sprite.HitBox.Top &&
        this.HitBox.Top < sprite.HitBox.Top &&
        this.HitBox.Right > sprite.HitBox.Left &&
        this.HitBox.Left < sprite.HitBox.Right;
    }
    protected bool isTouchingBottom(Sprite sprite)
    {
      return this.HitBox.Top + this.Velocity.Y < sprite.HitBox.Bottom &&
        this.HitBox.Bottom > sprite.HitBox.Bottom &&
        this.HitBox.Right > sprite.HitBox.Left &&
        this.HitBox.Left < sprite.HitBox.Right;
    }
    // No more collision bools

    public void ChooseSpritesheet()
    {
      if (Velocity.X > 0)
      {
        _animationManger.Play(spriteAnimations["WalkRight"]);
      }
      else if (Velocity.X < 0)
      {
        _animationManger.Play(spriteAnimations["WalkLeft"]);
      }
      else if (Velocity.Y > 0)
      {
        _animationManger.Play(spriteAnimations["WalkRight"]);
      }
      else if (Velocity.Y < 0)
      {
        _animationManger.Play(spriteAnimations["WalkLeft"]);
      }

      else
      {
        _animationManger.Stop();
      }
    }

    public void CheckColisions(List<Sprite> sprites) 
    {
      foreach (var sprite in sprites)
      {
        if (sprite == this)
        {
          continue;
        }
        if (this.Velocity.X > 0 && this.isTouchingLeft(sprite) ||
          this.Velocity.X < 0 && this.isTouchingRight(sprite))
        {
          this.Velocity.X = 0;
        }
        if (this.Velocity.Y > 0 && this.isTouchingTop(sprite) ||
          this.Velocity.Y < 0 && this.isTouchingBottom(sprite))
        {
          this.Velocity.Y = 0;
        }
      }
    }

    public override void Update(GameTime gameTime, List<Sprite> sprites)
    {
      Move();

      CheckColisions(sprites);

      ChooseSpritesheet();

      _animationManger.Update(gameTime);

      Position += Velocity;
      Velocity = Vector2.Zero;
    }
  }
}
