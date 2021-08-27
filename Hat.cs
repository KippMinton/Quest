using System;
using System.Collections.Generic;

namespace Quest
{
  public class Hat
  {
    public int ShininessLevel { get; set; }

    public string ShininessDescription { 
      get {
        if (ShininessLevel < 2) 
        {
          return "dull";
        }
        else if (ShininessLevel >=2 && ShininessLevel <=5)
        {
          return "noticeable";
        }
        else if (ShininessLevel >= 6 && ShininessLevel <=9)
        {
          return "bright";
        }
        else
        {
          return "blinding";
        }
      }
    } 
  }
}




// Create a new class called Hat in its own file.
// Add a mutable integer property called ShininessLevel to indicate how shiny the hat is.
// Add a computed string property called ShininessDescription to return a text description of the hat's shininess according to the following rules.
// A ShininessLevel less than 2 should be "dull"
// A ShininessLevel between 2 and 5 should be "noticeable"
// A ShininessLevel between 6 and 9 should be "bright"
// A ShininessLevel greater than 9 should be "blinding"
// Add a Hat property and constructor parameter to the Adventurer class.
// Update the Adventurer's GetDescription method to include the description of the hat.
// Update the Program.cs file to create a Hat and pass it to the Adventurer's constructor.
