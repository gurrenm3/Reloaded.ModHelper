using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A class that used <see cref="IModEventHook"/> to notify when it's properties are changed or being changed.
    /// </summary>
    public class PropertyChangedNotifier
    {
        protected ValueCache cache = new ValueCache();
        private Dictionary<string, IModEventHook<object>> propertyChangedEvents;
        protected Dictionary<string, bool> isEventFiring = new();
        private List<string> propertyNames;
        private bool sharedModEvents;

        // example:
        /*public int Units
        {
            get => _units;
            set
            {
                if (value == Units)
                    return;

                ChangePropertyValue(value, (newValue) => _units = (int)newValue);
            }
        }
        private int _units;*/

        public PropertyChangedNotifier() : this(sharedModHook: false)
        {

        }

        public PropertyChangedNotifier(bool sharedModHook)
        {
            sharedModEvents = sharedModHook;
            propertyChangedEvents = new Dictionary<string, IModEventHook<object>>();

            propertyNames = new List<string>();
            foreach (var prop in this.GetType().GetProperties())
            {
                propertyNames.Add(prop.Name);
                isEventFiring.Add(prop.Name, false);
            }
            //this.GetType().GetProperties().ForEach(p => propertyNames.Add(p.Name));
        }

        /// <summary>
        /// Listen for a property changed event based on the property name.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="onChanged"></param>
        /// <param name="isPrefix"></param>
        public void OnPropertyChanged(string propertyName, Action<EventParam<object>> onChanged, bool isPrefix = false)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                ConsoleUtils.WriteError($"You cannot use an empty property name. Please enter a valid property name to use {nameof(OnPropertyChanged)}");
                return;
            }

            if (!propertyNames.Any(p => p == propertyName))
            {
                ConsoleUtils.WriteError($"No property with the name of {propertyName} exists! Check that you spelled it correctly.");
                return;
            }


            IModEventHook<object> hook;

            if (!propertyChangedEvents.TryGetValue(propertyName, out hook))
            {
                if (sharedModEvents)
                    hook = (IModEventHook<object>)(new SharedModEventHook<object>());
                else
                    hook = (IModEventHook<object>)(new ModEventHook<object>());

                propertyChangedEvents.Add(propertyName, hook);
            }

            //var hook = propertyChangedEvents.GetOrAdd(propertyName, newHook);

            throw new Exception("FIX THIS, uncomment code below");
            /*if (isPrefix)
                hook.Before.AddRunner(onChanged);
            else
                hook.After.AddRunner(onChanged);*/
        }

        protected void ChangePropertyValue(object value, Action<object> setValue, [CallerMemberName] string propertyName = "")
        {
            if (isEventFiring[propertyName])
            {
                setValue.Invoke(value);
                return;
            }

            isEventFiring[propertyName] = true;

            // create args and fire prefix.
            EventParam<object> arg = new EventParam<object>(value);
            FirePropertyChangedPrefix(arg, propertyName);

            // change the actual value now.
            setValue.Invoke(arg.value);

            // fire postfix.
            FirePropertyChangedPostfix(arg, propertyName);
            isEventFiring[propertyName] = false;
        }

        private IModEventHook<object> GetHookFromProperty(string propertyName)
        {
            propertyChangedEvents.TryGetValue(propertyName, out var hook);
            return hook;
        }

        private void FirePropertyChangedPrefix(EventParam<object> value, [CallerMemberName] string propertyName = "")
            => GetHookFromProperty(propertyName)?.Before?.Run(value);

        private void FirePropertyChangedPostfix(EventParam<object> value, [CallerMemberName] string propertyName = "")
            => GetHookFromProperty(propertyName)?.After?.Run(value);
    }
}
