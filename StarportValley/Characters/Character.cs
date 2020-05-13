using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarportValley.Sprites;

namespace StarportValley.Characters
{ // This is me getting ahead of myself and planning for future needs.
  class Character
  {
    protected string Name;
    protected MobileSprite Physicality;
    
    public Character(string name, MobileSprite physicality)
    {
      this.Name = name;
      this.Physicality = physicality;
    } 
  }
}
