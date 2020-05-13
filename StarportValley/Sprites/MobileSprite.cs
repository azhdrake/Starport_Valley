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
  {// The mobileSprite class, for defining things that have sprites and also move.
     
    private KeyboardState currentKeyboardState;
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

    public bool HasWateringCan = false;
    public Sprite touchedSprite;

    public override Rectangle HitBox
    { // For collision stuff.
      get
      {
        return new Rectangle((int)Position.X, (int)Position.Y, spriteWidth, spriteHeight);
      }
    }

    public void Move(KeyboardState key)
    { // Moving! Idealy this would be in the player character class, but I haven't developed it enough to make that happen yet.
      if (input == null)
      {
        return;
      }
      if (key.IsKeyDown(input.Left))
      {
        Velocity.X -= Speed;
      }
      if (key.IsKeyDown(input.Right))
      {
        Velocity.X += Speed;
      }
      if (key.IsKeyDown(input.Up))
      {
        Velocity.Y -= Speed;
      }
      if (key.IsKeyDown(input.Down))
      {
        Velocity.Y += Speed;
      }
    }

    public void water()
    {
      if (HasWateringCan)
      {

      }
    }

    // Collisions. It's a lot of almost identical blocks of code and it works and I am not explaining all of it.
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
    { // Choosing the spritesheet that's facing the right direction, so long as that direction is either left or right.
      if (Velocity.X > 0)
      {
        animationManger.Play(spriteAnimations["WalkRight"]);
      }
      else if (Velocity.X < 0)
      {
        animationManger.Play(spriteAnimations["WalkLeft"]);
      }
      else if (Velocity.Y > 0)
      {
        animationManger.Play(spriteAnimations["WalkRight"]);
      }
      else if (Velocity.Y < 0)
      {
        animationManger.Play(spriteAnimations["WalkLeft"]);
      }

      else
      { // No change in velocity? Retun to standing position.
        animationManger.Stop();
      }
    }

    public void CheckColisions(List<Sprite> sprites) 
    { // checks to make sure that you're not wakling through something. 
      foreach (var sprite in sprites)
      {
        if (sprite == this)
        { // makes sure you don't stop because you're touching yourself.
          continue;
        }
        if (this.Velocity.X > 0 && this.isTouchingLeft(sprite) ||
          this.Velocity.X < 0 && this.isTouchingRight(sprite))
        {
          this.Velocity.X = 0;
          this.touchedSprite = sprite;
        }
        if (this.Velocity.Y > 0 && this.isTouchingTop(sprite) ||
          this.Velocity.Y < 0 && this.isTouchingBottom(sprite))
        {
          this.Velocity.Y = 0;
          this.touchedSprite = sprite;
        }
      }
    }

    public override void Update(GameTime gameTime, List<Sprite> sprites)
    { // checks the keyboard state, gets a velocity from the move function, checks for colisions, gets the right spitesheet, updates the animation, and moves the sprite and resets it's velocity.
      currentKeyboardState = Keyboard.GetState();

      Move(currentKeyboardState);

      CheckColisions(sprites);

      ChooseSpritesheet();

      animationManger.Update(gameTime);



      Position += Velocity;
      Velocity = Vector2.Zero;
    }
  }
}
