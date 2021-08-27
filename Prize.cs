using System;
using System.Collections.Generic;

namespace Quest
{
  public class Prize
  {
    private string _text { get; set; }
    
    public void ShowPrize(Adventurer adventurer)
    {
      if (adventurer.Awesomeness > 0)
      {
        for (int i = 0; i < adventurer.Awesomeness; i++)
        {
          Console.WriteLine(_text);
        }
      }
      else
      {
        Console.WriteLine("No prize for you! How pitiful...");
      }
    }

    public Prize (string text)
    {
      _text = text;
    }
  }
}





// Create a new class called Prize.
// Create a private field in the class called _text to contain a textual description of the prize.
// Create a constructor in the class that takes a text parameter and uses it to set the _text field.
// Create a method in the class called ShowPrize.
// The method should accept an Adventurer as a parameter.
// If the adventurer's Awesomeness is greater than zero, write the _text field to the console the same number of times as the value of the Awesomeness property.
// If the adventurer's Awesomeness is zero or less than zero, write a message of pity to the console.
// In Program.cs create an instance of the Prize.
// At the end of the quest (before you ask if the user wants to repeat the quest) call the ShowPrize method.