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
    /// <typeparam name="T1">The type of Value1</typeparam>
    public class EventParams<T1>
    {
        /// <summary>
        /// First Value
        /// </summary>
        public T1 value;

        /// <summary>
        /// Creates an instance of this class without setting any of the parameters.
        /// </summary>
        public EventParams()
        {

        }

        /// <summary>
        /// Creates an instance of this class while setting all of the parameters.
        /// </summary>
        public EventParams(T1 value1)
        {
            this.value = value1;
        }
    }


    /// <summary>
    /// A wrapper class for ModEvent parameters. This is used by ModEventHooks to let you change hook arguments in
    /// a prefix patch.
    /// 
    /// <br/><br/>Normally you cannot directly change arguments from a function hook because they aren't reference types.
    /// By using this wrapper class, which IS a reference type, we effectively create a "package" to put the hook parameters
    /// in. This way they can be modified and passed back to the original function hook.
    /// </summary>
    /// <typeparam name="T1">The type of Value1</typeparam>
    /// <typeparam name="T2">The type of Value2</typeparam>
    public class EventParams<T1, T2>
    {
        /// <summary>
        /// First Value
        /// </summary>
        public T1 value1;

        /// <summary>
        /// Second Value
        /// </summary>
        public T2 value2;

        /// <summary>
        /// Creates an instance of this class without setting any of the parameters.
        /// </summary>
        public EventParams()
        {

        }

        /// <summary>
        /// Creates an instance of this class while setting all of the parameters.
        /// </summary>
        public EventParams(T1 value1, T2 value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }
    }


    /// <summary>
    /// A wrapper class for ModEvent parameters. This is used by ModEventHooks to let you change hook arguments in
    /// a prefix patch.
    /// 
    /// <br/><br/>Normally you cannot directly change arguments from a function hook because they aren't reference types.
    /// By using this wrapper class, which IS a reference type, we effectively create a "package" to put the hook parameters
    /// in. This way they can be modified and passed back to the original function hook.
    /// </summary>
    /// <typeparam name="T1">The type of Value1</typeparam>
    /// <typeparam name="T2">The type of Value2</typeparam>
    /// <typeparam name="T3">The type of Value3</typeparam>
    public class EventParams<T1, T2, T3>
    {
        /// <summary>
        /// First Value
        /// </summary>
        public T1 value1;

        /// <summary>
        /// Second Value
        /// </summary>
        public T2 value2;

        /// <summary>
        /// Third Value
        /// </summary>
        public T3 value3;

        /// <summary>
        /// Creates an instance of this class without setting any of the parameters.
        /// </summary>
        public EventParams()
        {

        }

        /// <summary>
        /// Creates an instance of this class while setting all of the parameters.
        /// </summary>
        public EventParams(T1 value1, T2 value2, T3 value3)
        {
            this.value1 = value1;
            this.value2 = value2;
            this.value3 = value3;
        }
    }


    /// <summary>
    /// A wrapper class for ModEvent parameters. This is used by ModEventHooks to let you change hook arguments in
    /// a prefix patch.
    /// 
    /// <br/><br/>Normally you cannot directly change arguments from a function hook because they aren't reference types.
    /// By using this wrapper class, which IS a reference type, we effectively create a "package" to put the hook parameters
    /// in. This way they can be modified and passed back to the original function hook.
    /// </summary>
    /// <typeparam name="T1">The type of Value1</typeparam>
    /// <typeparam name="T2">The type of Value2</typeparam>
    /// <typeparam name="T3">The type of Value3</typeparam>
    /// <typeparam name="T4">The type of Value4</typeparam>
    public class EventParams<T1, T2, T3, T4>
    {
        /// <summary>
        /// First Value
        /// </summary>
        public T1 value1;

        /// <summary>
        /// Second Value
        /// </summary>
        public T2 value2;

        /// <summary>
        /// Third Value
        /// </summary>
        public T3 value3;

        /// <summary>
        /// Fourth Value
        /// </summary>
        public T4 value4;

        /// <summary>
        /// Creates an instance of this class without setting any of the parameters.
        /// </summary>
        public EventParams()
        {

        }

        /// <summary>
        /// Creates an instance of this class while setting all of the parameters.
        /// </summary>
        public EventParams(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            this.value1 = value1;
            this.value2 = value2;
            this.value3 = value3;
            this.value4 = value4;
        }
    }


    /// <summary>
    /// A wrapper class for ModEvent parameters. This is used by ModEventHooks to let you change hook arguments in
    /// a prefix patch.
    /// 
    /// <br/><br/>Normally you cannot directly change arguments from a function hook because they aren't reference types.
    /// By using this wrapper class, which IS a reference type, we effectively create a "package" to put the hook parameters
    /// in. This way they can be modified and passed back to the original function hook.
    /// </summary>
    /// <typeparam name="T1">The type of Value1</typeparam>
    /// <typeparam name="T2">The type of Value2</typeparam>
    /// <typeparam name="T3">The type of Value3</typeparam>
    /// <typeparam name="T4">The type of Value4</typeparam>
    /// <typeparam name="T5">The type of Value5</typeparam>
    public class EventParams<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// First Value
        /// </summary>
        public T1 value1;

        /// <summary>
        /// Second Value
        /// </summary>
        public T2 value2;

        /// <summary>
        /// Third Value
        /// </summary>
        public T3 value3;

        /// <summary>
        /// Fourth Value
        /// </summary>
        public T4 value4;

        /// <summary>
        /// Fifth Value
        /// </summary>
        public T5 value5;

        /// <summary>
        /// Creates an instance of this class without setting any of the parameters.
        /// </summary>
        public EventParams()
        {

        }

        /// <summary>
        /// Creates an instance of this class while setting all of the parameters.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <param name="value5"></param>
        public EventParams(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            this.value1 = value1;
            this.value2 = value2;
            this.value3 = value3;
            this.value4 = value4;
            this.value5 = value5;
        }
    }
}
