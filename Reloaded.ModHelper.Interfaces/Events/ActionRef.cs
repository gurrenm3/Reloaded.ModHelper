namespace Reloaded.ModHelper
{
    /// <summary>
    /// A delegate type with a referenceable argument
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <param name="item1"></param>
    public delegate void ActionRef<T1>(ref T1 item1);


    /// <summary>
    /// A delegate type with a referenceable argument
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    public delegate void ActionRef<T1, T2>(ref T1 item1, ref T2 item2);

    /// <summary>
    /// A delegate type with a referenceable argument
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    public delegate void ActionRef1<T1, T2>(ref T1 item1, T2 item2);

    /// <summary>
    /// A delegate type with a referenceable argument
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    public delegate void ActionRef2<T1, T2>(T1 item1, ref T2 item2);


    /// <summary>
    /// A delegate type with a referenceable argument
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    public delegate void ActionRef<T1, T2, T3>(ref T1 item1, ref T2 item2, ref T3 item3);

    /// <summary>
    /// A delegate type with a referenceable argument
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    public delegate void ActionRef1<T1, T2, T3>(ref T1 item1, T2 item2, T3 item3);

    /// <summary>
    /// A delegate type with a referenceable argument
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    public delegate void ActionRef2<T1, T2, T3>(T1 item1, ref T2 item2, T3 item3);

    /// <summary>
    /// A delegate type with a referenceable argument
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    public delegate void ActionRef3<T1, T2, T3>(T1 item1, T2 item2, ref T3 item3);

    /// <summary>
    /// A delegate type with a referenceable argument
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    public delegate void ActionRef4<T1, T2, T3>(ref T1 item1, ref T2 item2, T3 item3);

    /// <summary>
    /// A delegate type with a referenceable argument
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    public delegate void ActionRef5<T1, T2, T3>(T1 item1, ref T2 item2, ref T3 item3);

    /// <summary>
    /// A delegate type with a referenceable argument
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    public delegate void ActionRef6<T1, T2, T3>(ref T1 item1, T2 item2, ref T3 item3);
}
