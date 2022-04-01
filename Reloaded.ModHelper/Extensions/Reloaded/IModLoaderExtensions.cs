using System.Linq;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;

namespace Reloaded.ModHelper
{
	/// <summary>
	/// Extension methods for Reloaded2 IModLoader
	/// </summary>
	public static class IModLoaderExtensions
	{
		/// <summary>
		/// Try to get a ModConfig by a mod's ID
		/// </summary>
		/// <param name="iModLoader"></param>
		/// <param name="modId">The ID of the mod you want to get</param>
		/// <returns>If successful, returns the ModConfig for the mod. Otherwise, returns null</returns>
		public static IModConfigV1 GetModByID(this IModLoader iModLoader, string modId)
		{
			return iModLoader?.GetActiveMods()?.FirstOrDefault(mod => mod?.Generic?.ModId == modId)?.Generic;
		}
	}
}