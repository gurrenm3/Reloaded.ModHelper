# Reloaded.ModHelper
A third party library meant to help programmers make mods with Reloaded2. It's designed to be similar to Unity so it's simpiler and more familiar to modders.

## Why should you use this?
If you've ever made mods before you've no doubt had to rewrite code over and over so it can be used between multiple mods. That is inefficient and bad practice. It's much better to have one library with all your reusable code. That's what ``Reloaded.ModHelper`` is. It comes with a ton of optimized code and "helper classes" so you can get straight to business making your mods.

## What features does it have?
This library is a work in progress and will gain new features over time. Some of the things already added are:

- An simple Signature Scanning class. It's essentially a wrapper around the Reloaded2 SigScanner that does a lot of stuff automatically.
- Info about the players hardware:
   - Computer screen and resolution
   - Keyboard and Mouse presses
- Game Loop integration:
   - Easily hook and integrate your mod with the game's actual Game Loop.
   - If you don't want to find and hook the actual loop you can use make a "Pseudo-GameLoop", which is essentially a "fake" game loop that runs outside of the game.
- Mod Events
   - An event system that mods can use to easily subscribe to any game event. When the game event is called every subscriber will execute. It's basically the same as Unity's UnityEvent class.
- Time management
   - Get info about the passage of time within the game, for example the time between this frame and the last one.
   - Effectively the same as Unity's Time class.
- Vector2 and Vector3 classes for dealing with 2D and 3D locations.
- A ThreadSafe Randomizer to guarantee that all of your mods will work even when you use multi-threading
- Info about the player's current computer screen/desktop size
- Many helpful extension methods added to general C# classes for ease of use.

In addition to all of this, ``Reloaded.ModHelper`` is designed to support "one-off" mods that don't have dependent mods, as well as API's for those who are making big modding APIs that are shared amongst many mods.
