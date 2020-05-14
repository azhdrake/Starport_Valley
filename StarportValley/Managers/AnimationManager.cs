using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarportValley.Models;

namespace StarportValley.Managers
{
  public class AnimationManager
  { // Animation manager. It manages the animations. 
    private Animation _animation;
    private float _timer;
    public Vector2 Position { get; set; }
    public AnimationManager(Animation animation)
    {
      _animation = animation;
    }
    public void Play(Animation animation)
    {
      if (_animation == animation)
      {
        return;
      }
      _animation = animation;
      _animation.CurrentFrame = 0;
      _timer = 0;
    }
    public void Stop()
    {
      _timer = 0f;
      _animation.CurrentFrame = 0;
    }
    public void Update(GameTime gameTime)
    { 
      // adds the tick time to the timer
      _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

      // Checks the elapsed time vs the framespeed, if more then the framespeed time has passed we reset the time and bump to the next frame.
      if (_timer > _animation.FrameSpeed)
      {
        _timer = 0f;
        _animation.CurrentFrame++;

        // Completing the loop so we don't try to draw something that doesn't exist.
        if (_animation.CurrentFrame >= _animation.FrameCount)
        {
          _animation.CurrentFrame = 0;
        }
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    { // The rectagle is a destination rectangle. The spritesheet, which is the texture the animation is using, is a single long image with each frame placed next to each other. The destination rectangle is the rectangle selecting the current frame, and that is what drawn.
      spriteBatch.Draw(
        _animation.Texture, 
        Position, 
        new Rectangle(_animation.CurrentFrame * _animation.FrameWidth, 0, _animation.FrameWidth, _animation.FrameHeight), 
        Color.White);
    }
  }
}
