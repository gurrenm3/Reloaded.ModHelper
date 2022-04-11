namespace Reloaded.ModHelper
{
    /// <summary>
    /// A wrapper class for ModEvent parameters. This is used by ModEventHooks to let you change hook arguments in
    /// a prefix patch.
    /// 
    /// <br/><br/>Normally you cannot directly change arguments from a function hook because they aren't reference types.
    /// By using this wrapper class, which IS a reference type, we effectively create a "package" to put the hook parameters
    /// in. This way they can be modified and passed back to the original function hook.
    /// </summary>
    /// <typeparam name="T">The type of Value1</typeparam>
    public class EventParam<T>
    {
        /// <summary>
        /// The Value being held
        /// </summary>
        public T value;

        private bool isNumber;

        /// <summary>
        /// Creates an instance of this class without setting any of the parameters.
        /// </summary>
        public EventParam()
        {
            isNumber = typeof(T).IsNumeric();
        }

        /// <summary>
        /// Creates an instance of this class while setting all of the parameters.
        /// </summary>
        public EventParam(T value1) : this()
        {
            this.value = value1;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is EventParam<T> eventParam)
            {
                return (dynamic)eventParam.value == value;
            }
            else if (obj is T t)
            {
                return (dynamic)t == value;
            }
            else
            {
                return false;
            }
        }

        public static implicit operator T(EventParam<T> param)
        {
            return param.value;
        }

        public static EventParam<T> operator +(EventParam<T> param, T amountToSubtract)
        {
            if (!param.isNumber)
                return param;

            var value = (dynamic)param.value + (dynamic)amountToSubtract;
            param.value = value;
            return param;
        }

        public static EventParam<T> operator -(EventParam<T> param, T amountToSubtract)
        {
            if (!param.isNumber)
                return param;

            var value = (dynamic)param.value - (dynamic)amountToSubtract;
            param.value = value;
            return param;
        }

        public static EventParam<T> operator *(EventParam<T> param, T amountToSubtract)
        {
            if (!param.isNumber)
                return param;

            var value = (dynamic)param.value * (dynamic)amountToSubtract;
            param.value = value;
            return param;
        }

        public static EventParam<T> operator /(EventParam<T> param, T amountToSubtract)
        {
            if (!param.isNumber)
                return param;

            var value = (dynamic)param.value / (dynamic)amountToSubtract;
            param.value = value;
            return param;
        }

        public static bool operator ==(EventParam<T> param, T amountToSubtract)
        {
            if (!param.isNumber)
                return false;

            return (dynamic)param.value == (dynamic)amountToSubtract;
        }

        public static bool operator !=(EventParam<T> param, T amountToSubtract)
        {
            if (!param.isNumber)
                return false;

            return !((dynamic)param.value == (dynamic)amountToSubtract);
        }
    }
}
