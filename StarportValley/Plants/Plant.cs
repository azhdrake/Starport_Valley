using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarportValley.Plants
{ // The plant class. There's a lot of stuff in here that's planning for the future and will not see use for quite some time.
  public class Plant : Sprite
  {
    private Texture2D[] AllTextures;
    private Dictionary<string, int[]> Drops; // We're going to worry about this a little later. { Name : [minDrop, maxDrop, 0/1 where 0 = plant dies when harvested 1 = plant does not die when harvested] }
    private string Name;
    private int Age;
    private int Color;
    private int Health;
    private int Season;
    private Boolean IsDead;
    private Boolean IsHarvestable;
    private Boolean IsPerennial;
    private Boolean IsWatered;
    private Boolean Spreads;

    public Plant(string name, Texture2D[] textures, int color, int season) : base(textures)
    { // All plants need to have defined sprites, name, color (relates to what species can eat them once we get to the point where we have a bunch of aliens.), and growth season.
      this.AllTextures = textures;
      this.Name = name;
      this.Color = color;
      this.Season = season;

      this.Age = 0;
      this.Health = 10;

      this._texture = AllTextures[Age];

      this.IsDead = false;
      this.IsHarvestable = false;
      this.IsPerennial = false;
      this.IsWatered = false;
      this.Spreads = false;
    }

    public void WaterPlant()
    { // What makes the plant grow. By going up an age tick the apperance moves onto the next growth sprite.
      if(Age < 2)
      {
        Age++;
        _texture = AllTextures[Age];
      }
    }

    public override void Update(GameTime gameTime)
    {
     
    }


  }
}
