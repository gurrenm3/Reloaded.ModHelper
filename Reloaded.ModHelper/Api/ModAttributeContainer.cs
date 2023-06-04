using System.Collections.Generic;
using System.Linq;

namespace Reloaded.ModHelper;

/// <summary>
/// An object that has non-static <see cref="ModAttrAttribute"/>.
/// <br/>Useful for automatically loading them.
/// </summary>
public class ModAttributeContainer
{
    /// <summary>
    /// Contains any <see cref="ModAttrAttribute"/> that were registered for this mod.
    /// <br/>Will be empty if none were registered by this mod.
    /// </summary>
    public List<ModAttrAttribute> LoadedModAttributes => _loadedModAttributes;
    private List<ModAttrAttribute> _loadedModAttributes = new();

    public ModAttributeContainer()
    {
        
    }

    protected void LoadInstanceAttributes()
    {
        ModAttributeLoader.LoadAllFromInstance(this, out var loaded);
        _loadedModAttributes.AddRange(loaded);
    }
}
