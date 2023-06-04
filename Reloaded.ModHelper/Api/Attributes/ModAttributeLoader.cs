using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Used to load <see cref="ModMethodAttribute"/>'s from an Assembly.
    /// </summary>
    public class ModAttributeLoader
    {
        /// <summary>
        /// The list of all ModAttrAttributes found during <see cref="LoadAllFromAssembly"/>.
        /// </summary>
        private List<ModAttrAttribute> allModAttributes = new List<ModAttrAttribute>();

        /// <summary>
        /// The Assembly that is being loaded from.
        /// </summary>
        private Assembly targetAssembly;


        /// <summary>
        /// Initializes this object along with the Assembly to load from.
        /// </summary>
        /// <param name="modAssembly"></param>
        private ModAttributeLoader(Assembly modAssembly)
        {
            targetAssembly = modAssembly;
        }

        public static void LoadAllFromInstance(object instance, out List<ModAttrAttribute> loadedAttributes)
        {
            ModAttributeLoader loader = new ModAttributeLoader(instance.GetType().Assembly);
            loader.GetModAttributesFromType(instance.GetType(), instance);
            loader.ProcessLoadedAttrbutes();
            loadedAttributes = loader.allModAttributes;
        }

        /// <summary>
        /// Loads all <see cref="ModAttrAttribute"/> from the provided Assembly.
        /// </summary>
        /// <param name="modAssembly"></param>
        /// <param name="loadedAttributes">A list of all the <see cref="ModAttrAttribute"/> that were loaded.</param>
        public static void LoadAllFromAssembly(Assembly modAssembly, out List<ModAttrAttribute> loadedAttributes)
        {
            var loader = new ModAttributeLoader(modAssembly);
            loader.LoadAllFromAssembly();
            loader.ProcessLoadedAttrbutes();
            loadedAttributes = loader.allModAttributes;
        }


        /// <summary>
        /// Will automatically load every <see cref="ModAttrAttribute"/> within this assembly.
        /// </summary>
        public void LoadAllFromAssembly()
        {
            // Get all current ModAttrAttributes.
            allModAttributes.Clear();
            //targetAssembly.GetTypes().ForEach(type => GetModAttributesFromType(type));
            Parallel.ForEach(targetAssembly.GetTypes(), type => GetModAttributesFromType(type, null));            
        }

        private void ProcessLoadedAttrbutes()
        {
            // load all ModAttrAttributes without dependencies.
            Parallel.ForEach(allModAttributes, modAttr =>
            {
                if (!modAttr.HasDependencies && !modAttr.Info.IsAttributeLoaded)
                {
                    modAttr.OnAttributeLoaded();
                    modAttr.Info.IsAttributeLoaded = true;
                }
            });

            // Get list of dependencies from remaining ModAttrAttributes.
            List<ModAttrAttribute> attributesByDependents = new List<ModAttrAttribute>();
            Parallel.ForEach(allModAttributes, modAttr =>
            {
                var parents = GetParentDependents_Recursive(modAttr);
                if (parents == null || parents.Count == 0)
                    return;

                attributesByDependents.AddRange(parents);
            });

            // We have all of the dependencies. Sort them, remove duplicates, then load them.
            var orderedParents = attributesByDependents.OrderBy(parent => attributesByDependents.Count(item => item == parent)).Reverse().ToHashSet();
            Parallel.ForEach(orderedParents, parent =>
            {
                if (!parent.Info.IsAttributeLoaded)
                {
                    parent.OnAttributeLoaded();
                    parent.Info.IsAttributeLoaded = true;
                }
            });

            Parallel.ForEach(allModAttributes, modAttr =>
            {
                if (!modAttr.Info.IsAttributeLoaded)
                {
                    modAttr.OnAttributeLoaded();
                    modAttr.Info.IsAttributeLoaded = true;
                }
            });

            /*allModAttributes.ForEach(modAttr =>
            {
                if (!modAttr.HasDependencies && !modAttr.Info.IsAttributeLoaded)
                {
                    modAttr.OnAttributeLoaded();
                    modAttr.Info.IsAttributeLoaded = true;
                }
            });

            // Get list of dependencies from remaining ModAttrAttributes.
            List<ModAttrAttribute> attributesByDependents = new List<ModAttrAttribute>();
            foreach (var modAttr in allModAttributes)
            {
                var parents = GetParentDependents_Recursive(modAttr);
                if (parents == null || parents.Count == 0)
                    continue;

                attributesByDependents.AddRange(parents);
            }

            // We have all of the dependencies. Sort them, remove duplicates, then load them.
            var orderedParents = attributesByDependents.OrderBy(parent => attributesByDependents.Count(item => item == parent)).Reverse().ToHashSet();
            orderedParents.ForEach(parent =>
            {
                if (!parent.Info.IsAttributeLoaded)
                {
                    parent.OnAttributeLoaded();
                    parent.Info.IsAttributeLoaded = true;
                }
            });

            // Now that all dependencies are loaded, it's safe to load everything else.
            allModAttributes.ForEach(modAttr =>
            {
                if (!modAttr.Info.IsAttributeLoaded)
                {
                    modAttr.OnAttributeLoaded();
                    modAttr.Info.IsAttributeLoaded = true;
                }
            });*/
        }

        /// <summary>
        /// Recursively gets all dependencies for a <see cref="ModAttrInfo"/>.
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        private List<ModAttrAttribute> GetParentDependents_Recursive(ModAttrAttribute child)
        {
            List<ModAttrAttribute> parents = new List<ModAttrAttribute>();
            allModAttributes.ForEach(modAttr =>
            {
                if (child.HasDependencies && child.Info.dependencies.Contains(modAttr.Info.TargetClass)) // target class is a dependent
                    parents.Add(modAttr);
            });

            for (int i = 0; i < parents.Count; i++)
            {
                var dependantParents = GetParentDependents_Recursive(parents.ElementAt(i));
                dependantParents?.ForEach(item => parents.Add(item));
            }

            return parents;
        }

        /// <summary>
        /// Loads all <see cref="ModAttrAttribute"/> from <paramref name="targetType"/> and adds them to <see cref="allModAttributes"/>.
        /// </summary>
        /// <param name="targetType"></param>
        private void GetModAttributesFromType(Type targetType, object instance)
        {
            // Get all mod methods
            var modAttributes = GetModAttributesFromType(targetType, instance, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            modAttributes?.ForEach(modAttr =>
            {
                allModAttributes.Add(modAttr);
            });
        }

        /// <summary>
        /// Returns a list of all <see cref="ModAttrAttribute"/> used in <paramref name="targetType"/>.
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        private List<ModAttrAttribute> GetModAttributesFromType(Type targetType, object instance, BindingFlags flags)
        {
            List<ModAttrAttribute> results = new List<ModAttrAttribute>();

            bool onlyLoadStatic = instance == null;
            bool onlyLoadInstance = instance != null;

            // load all custom attributes attached to targetType
            var classAttributes = TryGetCustomAttributes(targetType);
            foreach (var attribute in classAttributes)
            {
                if ((attribute is ModAttrAttribute modAttr) && !modAttr.Info.IsAttributeLoaded)
                {
                    modAttr.ClassInstance = instance;
                    modAttr.Info.TargetClass = targetType;
                    results.Add(modAttr);
                }
            }


            // Load all custom members
            var members = targetType.GetMembers(flags);            
            foreach (var member in members)
            {
                var customAttributes = TryGetCustomAttributes(member);
                foreach (var attribute in customAttributes)
                {
                    if (!(attribute is ModAttrAttribute modAttr) || modAttr.Info.IsAttributeLoaded)
                        continue;

                    if (onlyLoadInstance && member.IsStatic())
                        continue;

                    if (onlyLoadStatic && !member.IsStatic())
                        continue;

                    modAttr.ClassInstance = instance;

                    // we found a static one but we're only trying to load instance ones
                    if (member.IsStatic() && instance != null)
                        continue;

                    // we found a non-static one but instance is null.
                    // we're currently only loading static ones.
                    if (!member.IsStatic() && instance == null)
                        continue;

                    //ThrowIfMemberNotStatic(targetType, member);

                    modAttr.Info.TargetClass = targetType;

                    if (member is MethodInfo method)
                        modAttr.Info.TargetMethod = method;
                    else if (member is PropertyInfo property)
                        modAttr.Info.TargetProperty = property;
                    else if (member is FieldInfo field)
                        modAttr.Info.TargetField = field;
                    else if (member is ConstructorInfo constructor)
                        modAttr.Info.TargetConstructor = constructor;

                    results.Add(modAttr);
                }
            }

            // double check that we don't have self referencing dependencies
            foreach (var result in results)
            {
                if (result.HasDependencies)
                {
                    if (result.Info.dependencies.Contains(targetType)) // if it tries to load after itself.
                        throw new Exception($"A {nameof(ModAttrAttribute)} located in \"{targetType.Name}\" had itself as a dependency." +
                            $" Cannot load a {nameof(ModAttrAttribute)} after itself.");
                }
            }

            return results;
        }

        /// <summary>
        /// Throw an exception if <paramref name="targetMember"/> is not static.
        /// <br/>Currently the API only supports static members which is why this is needed.
        /// <br/>This will likely change in the future once there's a good way to support it.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="targetMember"></param>
        private void ThrowIfMemberNotStatic(Type owner, MemberInfo targetMember)
        {
            bool shouldThrow = false;
            if (targetMember is MethodInfo method && !method.IsStatic)
                shouldThrow = true;
            else if (targetMember is PropertyInfo propery && (!propery.GetMethod.IsStatic || !propery.SetMethod.IsStatic))
                shouldThrow = true;
            else if (targetMember is FieldInfo field && !field.IsStatic)
                shouldThrow = true;

            if (shouldThrow)
            {
                throw new NotImplementedException($"{nameof(ModAttrAttribute)} currently can only be used on Static Members." +
                        $" Make \"{owner.Name}.{targetMember.Name}\" static to fix this error.");
            }
        }

        /// <summary>
        /// Attempts to get all of the custom attributes on a member of a class.
        /// <br/>Will throw an exception if any of the custom attributes are referencing Types from another Assembly or project.
        /// </summary>
        /// <param name="targetMember">The target to try getting custom attributes from.</param>
        /// <returns>If successful, the list of custom attributes will be returned, otherwise null..</returns>
        private IEnumerable<Attribute> TryGetCustomAttributes(MemberInfo targetMember)
        {
            try
            {
                return targetMember.GetCustomAttributes();
            }
            catch (Exception ex)
            {
                HandleCustomAttrException(ex);
                return null;
            }
        }

        /// <summary>
        /// Attempts to get all of the custom attributes on a class.
        /// <br/>Will throw an exception if any of the custom attributes are referencing Types from another Assembly or project.
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        private IEnumerable<Attribute> TryGetCustomAttributes(Type targetType)
        {
            try
            {
                return targetType.GetCustomAttributes();
            }
            catch (Exception ex)
            {
                HandleCustomAttrException(ex);
                return null;
            }
        }

        /// <summary>
        /// Used to throw exceptions that occur from getting CustomAttribtues from seperate projects.
        /// </summary>
        /// <param name="ex"></param>
        private void HandleCustomAttrException(Exception ex)
        {
            if (ex.Message == "A non-collectible assembly may not reference a collectible assembly.")
            {
                throw new Exception($"Cannot use \"{nameof(ModAttrAttribute)}.{nameof(ModAttrAttribute.Info)}.{nameof(ModAttrInfo.dependencies)}\"" +
                    $" with Types from other projects. Can only use Types from the same Mod Assemebly/project.");
            }
            else
            {
                throw ex;
            }
        }
    }
}
