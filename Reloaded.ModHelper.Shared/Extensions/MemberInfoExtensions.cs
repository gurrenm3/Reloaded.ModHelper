using System.Reflection;

namespace Reloaded.ModHelper;

/// <summary>
/// Extensions for <see cref="MemberInfo"/>
/// </summary>
public static class MemberInfoExtensions
{
    /// <summary>
    /// Returns whether or not this member is static.
    /// </summary>
    /// <param name="member"></param>
    /// <returns></returns>
    public static bool IsStatic(this MemberInfo member)
    {
        if (member is MethodInfo method && method.IsStatic)
            return true;
        else if (member is PropertyInfo propery && propery.GetMethod.IsStatic && propery.SetMethod.IsStatic)
            return true;
        else if (member is FieldInfo field && field.IsStatic)
            return true;
        else if (member is ConstructorInfo ctor && ctor.IsStatic)
            return true;

        return false;
    }
}
