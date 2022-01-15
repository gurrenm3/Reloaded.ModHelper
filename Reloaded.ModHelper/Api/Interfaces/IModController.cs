using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Reloaded.ModHelper
{
	/// <summary>
	/// Used to communicate between mod's and the API.
	/// </summary>
	public interface IModController
	{
		/// <summary>
		/// All loaded <see cref="IModBase"/> classes.
		/// </summary>
		List<IModBase> LoadedMods { get; set; }

		/// <summary>
		/// The running Process of the game.
		/// </summary>
		Process GameProcess { get; set; }

		/// <summary>
		/// Instance of Reloaded ModLoader.
		/// </summary>
        IModLoader ModLoader { get; set; }

		/// <summary>
		/// Instance of Reloaded Logger.
		/// </summary>
        ILogger Logger { get; set; }

		/// <summary>
		/// Register a ModBase to the API. Allows access to the events like Start, Update, etc, as well as other helpful features.
		/// </summary>
		/// <param name="mod">Mod to register to the API.</param>
		/// <param name="modInfo">Info about this specific mod.</param>
		public void RegisterMod(IModBase mod, IModConfigV1 modInfo);

		/// <summary>
		/// Unregister a ModBase from the API.
		/// <br/>Doing so will also call <see cref="IModBase.OnModUnregistered"/> for this mod.
		/// </summary>
		/// <param name="mod">Mod to unregister from the API.</param>
		public void UnregisterMod(IModBase mod);

		/// <summary>
		/// Used to run one of the events in <see cref="IModBase"/>.
		/// <br/>The events are any of the overridable methods found in <see cref="IModBase"/>.
		/// </summary>
		/// <param name="patch">Event to run.</param>
		public void RunModEvent(Action<IModBase> patch);
	}
}