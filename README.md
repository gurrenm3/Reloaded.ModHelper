# Reloaded.ModHelper
A utility library for Reloaded2 that makes it significantly easier to create mods. It comes with dozens of tools and utilities to help unify your Reloaded2 projects and helps you make much more powerful mods without extra work.

## Why should you use this?
If you've ever made mods before you've probably trouble reusing code between mods. You'd have to rewrite the same code over and over, possibly introducing bugs and making future improvements impossible. That is inefficient and bad practice. It's much better to have one library with all your reusable code. That's what ``Reloaded.ModHelper`` is. It comes with a ton of optimized code, utilities, and "helper classes" so you can get straight to business making your mods.

## What features does it have?
This library has a lot of features already and will only gain more over time. Some of the current features are:

- ``ReloadedMod`` base class for mods to inherit. Doing so makes a significant amount of work happen automatically for the modder.
   - Automatically registers any hooks and mod attributes
   - Creates an instance of ``Harmonny`` for C# hooking
   - Custom Mod Logger
   - more
- A simple Signature Scanning class. It's essentially a wrapper around the Reloaded2 SigScanner that does a lot of stuff automatically.
- Info about the players hardware:
   - Computer screen and resolution
   - Keyboard and Mouse presses
- Game Loop integration:
   - Easily hook and integrate your mod with the game's actual Game Loop.
   - If you don't want to find and hook the actual loop you can use make a "Pseudo-GameLoop", which is essentially a "fake" game loop that runs outside of the game. Can be created in a single line of code.
- Mod Events and Hooks
   - A powerful event system that mods can use to easily create and subscribe to any game event. When the game event is called every subscriber will execute. It's based off of Unity's ``UnityEvent`` class.
- Time management
   - Get info about the passage of time within the game, for example the time between this frame and the last one.
   - Effectively the same as Unity's ``Time`` class.
- Vector2 and Vector3 classes for dealing with 2D and 3D locations.
- A ThreadSafe Randomizer to guarantee that all of your mods will work even when you use multi-threading
- Custom ``Attribute`` class called ``ModAttrAttribute`` which can be used for anything. Comes with an autoloader that automatically loads all ``ModAttrAttributes`` from an Assembly.
- An ``IModHook`` interface for automatically loading all Reloaded Hooks
- Many helpful extension methods added to general C# classes for ease of use.
- Much more

In addition to all of this, ``Reloaded.ModHelper`` is designed to support "one-off" mods that don't have dependent mods, as well as API's for those who are making big modding APIs that are shared amongst many mods.
