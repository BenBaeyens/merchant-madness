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

###### Developed by Kjip(Gamer). Original development since April 2019.
