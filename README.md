# Merchant Madness
##### Developed by Kjip

## Introduction
As of writing this, a brand new project. As time goes on I will continue to update this file and post any relevant information.
Once I complete the project, I will post a reflection sheet, as I did in my [Happiness Tracker Project](https://github.com/KjipGamer/happiness-tracker).

## What I hope to accomplish with this project
I want to try a few different things with this project, such as:
- Maintaining a cleaner code structure
- Not nesting if-statements
- Scriptable objects
- Learning more about custom inspector windows in Unity
- A little bit of procedural color generation

## Things I got stuck with 
#### Color generator
- What is it? How did I get stuck?
  - The color generator was supposed to be a cleanly-written algorithm that changed the color of trees and merchants based on one of a few presets of colors. 
  - For some reason, the algorithm can't find the colors from the asset folder.
- How will I try to fix it?
  - At the moment, the best way to fix it seems to manually input the colors into the prefab, which is still better than spaghetti-code, but not quite what I wanted it to be. 
- How did I solve it?
  - The current way I solved it is by having several lists of 2 colors each, which the script picks from based on a random lerp value to get multiple million different color combinations based off of presets that you can predefine (Currently you can only define this in script or editor). 
  
#### Item selling/buying
- What is it? How did I get stuck?
  - As a result of not planning out properly, or rather thinking I had planned out when in reality the system was flaud, organising item selling for all different merchants and salesmen was getting slightly difficult.
  - There was no oversight of which merchants sold which items
- How will I try to fix it?
  - I have planned out a system that I will be using for future trading/item buying/selling by having scriptable item objects.
- How did I solve it?
  - I used scriptable item objects, and attach them in a list so you can see which items the merchant is selling. This is way easier to see which merchants sell which items. And if you want the info for the item, you double click the item and all the information is layed out right there.



###### Developed by Kjip(Gamer). Original development since April 2019.
