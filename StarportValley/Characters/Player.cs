using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarportValley.Sprites;

namespace StarportValley.Characters
{
  class Player : Character
  { // This is me getting ahead of myself and planning for future needs.
    public Player(string name, MobileSprite physicality) : base(name, physicality)
    {

    }
    protected int health = 10;
    protected int energy = 10;
    protected int hunger = 0;


    public virtual void Update(GameTime gameTime, List<Sprite> sprites)
    {

    }
  }
}
