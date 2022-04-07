using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Used to load <see cref="ModMethodAttribute"/>'s from an Assembly.
    /// </summary>
    public class ModMethodLoader
    {
        Dictionary<Type, List<ModMethodAttributeInfo>> allModMethods = new Dictionary<Type, List<ModMethodAttributeInfo>>();
        private Assembly targetAssembly;

        /// <summary>
        /// Initializes this object along with the Assembly to load from.
        /// </summary>
        /// <param name="modAssembly"></param>
        public ModMethodLoader(Assembly modAssembly)
        {
            targetAssembly = modAssembly;
        }

        /// <summary>
        /// Will automatically load every <see cref="ModMethodAttribute"/> within this assembly.
        /// </summary>
        public void LoadAllFromAssembly()
        {
            var types = targetAssembly.GetTypes();
            foreach (var type in types)
            {
                // Get all mod methods
                var modMethods = GetModMethodsFromType(type, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
                if (modMethods == null)
                    continue;

                // Add them to the dictionary, sorting by which ModMethodAttribute they are.
                foreach (var modMethod in modMethods)
                {
                    if (allModMethods.TryGetValue(modMethod.TargetClass, out var modMethodPairs))
                        modMethodPairs.Add(modMethod);
                    else
                    {
                        var pairs = new List<ModMethodAttributeInfo>();
                        pairs.Add(modMethod);
                        allModMethods.Add(modMethod.TargetClass, pairs);
                    }
                }
            }

            // at this point they are all sorted by ModMethodAttribute. 
            // load all ModMethodAttributes without dependencies
            foreach (var modMethod in allModMethods)
            {
                var attributes = modMethod.Value;
                var noDependents = attributes.FindAll(item => item.Attribute.dependencies == null || item.Attribute.dependencies.Length == 0);
                noDependents.ForEach(item =>
                {
                    item.Attribute.OnAttributeLoaded(item);
                    item.Attribute.IsAttributeLoaded = true;
                });
            }

            // Get the list of dependencies.
            List<ModMethodAttributeInfo> attributesByDependents = new List<ModMethodAttributeInfo>();
            foreach (var modMethod in allModMethods)
            {
                var attributes = modMethod.Value;
                foreach (var attribute in attributes)
                {
                    var parents = GetParentDependents_Recursive(attribute);
                    if (parents == null)
                        continue;

                    attributesByDependents.AddRange(parents);
                }
            }

            // We have all of the dependencies. Sort them, remove duplicates, then load them.
            var orderedParents = attributesByDependents.OrderBy(parent => attributesByDependents.Count(item => item == parent)).Reverse().ToHashSet();
            foreach (var item in orderedParents)
            {
                if (item.Attribute.IsAttributeLoaded)
                    continue;

                item.Attribute.OnAttributeLoaded(item);
            }
        }

        /// <summary>
        /// Recursively gets all dependencies for a <see cref="ModMethodAttributeInfo"/>.
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        private List<ModMethodAttributeInfo> GetParentDependents_Recursive(ModMethodAttributeInfo child)
        {
            List<ModMethodAttributeInfo> parents = new List<ModMethodAttributeInfo>();
            foreach (var item in allModMethods)
            {
                foreach (var pair in item.Value)
                {
                    if (child?.Attribute?.dependencies == null)
                        continue;

                    if (child.Attribute.dependencies.Contains(pair.TargetClass))
                        parents.Add(pair);
                }
            }

            for (int i = 0; i < parents.Count; i++)
            {
                var dependantParents = GetParentDependents_Recursive(parents.ElementAt(i));
                if (dependantParents == null)
                    break;

                foreach (var item in dependantParents)
                {
                    parents.Add(item);
                }                
            }

            return parents;
        }


        /// <summary>
        /// Returns a list of all <see cref="ModMethodAttribute"/> used in this class.
        /// </summary>
        /// <param name="type">The class to get all <see cref="ModMethodAttribute"/> from.</param>
        /// <returns>If successful, will return a list of all the <see cref="ModMethodAttribute"/> in this type, 
        /// stored as <see cref="ModMethodAttributeInfo"/>. Will return null if it fails and will throw Exceptions for critical errors.</returns>
        private List<ModMethodAttributeInfo> GetModMethodsFromType(Type type, BindingFlags flags)
        {
            List<ModMethodAttributeInfo> results = new List<ModMethodAttributeInfo>();
            var methods = type.GetMethods(flags);

            foreach (var method in methods)
            {
                if (!TryGetCustomAttributes(method, out IEnumerable<Attribute> customAttributes))
                    continue;

                foreach (var attribute in customAttributes)
                {
                    if (!(attribute is ModMethodAttribute modMethodAttribute))
                        continue;

                    if (!method.IsStatic)
                    {
                        throw new NotImplementedException($"{nameof(ModMethodAttribute)} currently can only be used on static methods." +
                                $" Please make \"{type.Name}.{method.Name}()\" a static method.");
                    }

                    // ignore attributes that have alread loaded since they should only load once.
                    if (modMethodAttribute.IsAttributeLoaded)
                        continue;

                    if (modMethodAttribute.dependencies == null || modMethodAttribute.dependencies.Length == 0)
                    {
                        results.Add(new ModMethodAttributeInfo(modMethodAttribute, type, method));
                        continue;
                    }

                    if (modMethodAttribute.dependencies.Contains(type)) // if it tries to load after itself.
                        throw new Exception($"Tried loading  \"{type.Name}.{method.Name}()\"  after the class  \"{type.Name}\". Cannot load a this method after itself.");

                    results.Add(new ModMethodAttributeInfo(modMethodAttribute, type, method));
                }
            }

            return results;
        }

        /// <summary>
        /// Attempts to get all of the custom attributes on a method.
        /// <br/>Will throw an exception if any of the custom attributes are referencing Types from another Assembly or project.
        /// </summary>
        /// <param name="targetMethod">The target method to try getting custom attributes from.</param>
        /// <param name="customAttributes">Any custom attributes that were found</param>
        /// <returns>If successful, true will be returned. Otherwise false.</returns>
        private bool TryGetCustomAttributes(MethodInfo targetMethod, out IEnumerable<Attribute> customAttributes)
        {
            try
            {
                customAttributes = targetMethod.GetCustomAttributes();
            }
            catch (Exception ex)
            {
                if (ex.Message == "A non-collectible assembly may not reference a collectible assembly.")
                {
                    throw new Exception($"Cannot use \"{nameof(ModMethodAttribute)}.{nameof(ModMethodAttribute.dependencies)}\"" +
                        $" with Types from other projects. Can only use Types from the same Mod Assemebly/project.");
                }
                else
                {
                    throw;
                }
            }

            return true;
        }
    }
}
