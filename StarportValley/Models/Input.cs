using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarportValley.Models
{
  public class Input
  { 
    // The input class, to assign keys to values
    public Keys Left { get; set; }
    public Keys Right { get; set; }
    public Keys Up { get; set; }
    public Keys Down { get; set; }
    public Keys Interact { get; set; }
  }
}
