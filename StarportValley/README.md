# Starport Valley V 0.1
## A farm sim about trying to survive and build a community in the shell of an old spaceport after an apocoliptic event wiped out all electronic devices. You want aliens? We got so many aliens. You want to get sick eating non-earthern plants? We can do that for you. You want money? Too bad it was all electronic credit and is now gone forever. I hope you like bardering, buddy.

## Current gameplay instruction
Use wasd to contol the human sprite, and q to water the black dot which is clearly recognizable as a seed. Press up down left right to control the alien, and shift to water the plant. The plant has those three classic plant growth stages we all know and love, being black, yellow, and yellow wih blue accents. Once a plant has reached yellow with blue accents it cannot grow any further. A sprite must be touching a plant to water it. A character touching another character and hitting the water button will do nothing.

That's the game, folks.

Most of my monogame knowledge came from these tutorials: https://www.youtube.com/playlist?list=PLV27bZtgVIJqoeHrQq6Mt_S1-Fvq_zzGZ

Game1.cs is the file that starts the whole thing. From there I would recomend looking at States/GameState.cs as it explains a lot of the reacurring methods of the game. 

## A Brief Explination of Directories
### Characters 
This is not used yet in game, and it is largely unfinished it is here so I can do things in the future. It contains the character and the player classes. 
Player is a derived class from character. Characters will have things like inventories, health points, and a mobileSprite. Players get all that and inputs and a bunch of other stuff unique to the player character.

### Content
This is a default directory of monogame. It contains the visual assets of the game and the content manager, which can be used to add more content to the game.

### Controls
This contains the button class. Buttons can be clicked to activate a method.

### Managers
So far this conains only the animation manager, which keeps track of what frame of the animation we are on.

### Models
This contains the Animation and Input classes. Animation contains the stuff the animation manager needs to show the next frame. Input ties keys to controls, so you can either set your own custom controls or have two players on the same keyboard, a thing that any game has totally done in the last decade. 

### Plants
This contains the plant class. The plant class represents a plant, and is derived from the sprite class. As this is a farm sim this is a pretty important class and contains a lot of information, most of which is not being used yet.

### Sprites
This contians the Sprite and MobileSprite classes. Sprites are anything (besides buttons) that has a physical appearence in game. The sprite class is derived from the component class. MobileSprites are things that have a physical appearence and also move. Right now the MobileSprite class has controls for user input, which will eventually be moved into the player class to leave the MobileSprite class more generic to anything that moves.

### States
This contains the State, GameState, and Menu classes. GameState and Menu are both derived from the abstract State class. A state contains all the contents for a stage of the game. States are changed within the Game1 file.

#### The component file
The component file is a super generic abstract class so we can group any game components together should we need to.

## Conclusion
And that's every file I did anything with, I believe. I hope you enjoyed the thilling gameplay of watering these two flowers.