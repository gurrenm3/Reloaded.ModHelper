namespace Reloaded.ModHelper
{
    /// <summary>
    /// A delegate type with a referenceable argument
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <param name="item1"></param>
    public delegate void ActionRef<T1>(ref T1 item1);


    /// <summary>
    /// A delegate type with referenceable arguments.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    public delegate void ActionRef<T1, T2>(ref T1 item1, T2 item2);

    /// <summary>
    /// A delegate type with referenceable arguments.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    public delegate void ActionRef1<T1, T2>(ref T1 item1, ref T2 item2);




    /// <summary>
    /// A delegate type with referenceable arguments.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    public delegate void ActionRef<T1, T2, T3>(ref T1 item1, T2 item2, T3 item3);

    /// <summary>
    /// A delegate type with referenceable arguments.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    public delegate void ActionRef1<T1, T2, T3>(ref T1 item1, ref T2 item2, T3 item3);

    /// <summary>
    /// A delegate type with referenceable arguments.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    public delegate void ActionRef2<T1, T2, T3>(ref T1 item1, ref T2 item2, ref T3 item3);



    /// <summary>
    /// A delegate type with referenceable arguments.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    /// <param name="item4"></param>
    public delegate void ActionRef<T1, T2, T3, T4>(ref T1 item1, T2 item2, T3 item3, T4 item4);

    /// <summary>
    /// A delegate type with referenceable arguments.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    /// <param name="item4"></param>
    public delegate void ActionRef1<T1, T2, T3, T4>(ref T1 item1, ref T2 item2, T3 item3, T4 item4);

    /// <summary>
    /// A delegate type with referenceable arguments.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    /// <param name="item4"></param>
    public delegate void ActionRef2<T1, T2, T3, T4>(ref T1 item1, ref T2 item2, ref T3 item3, T4 item4);

    /// <summary>
    /// A delegate type with referenceable arguments.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    /// <param name="item4"></param>
    public delegate void ActionRef3<T1, T2, T3, T4>(ref T1 item1, ref T2 item2, ref T3 item3, ref T4 item4);



    /// <summary>
    /// A delegate type with referenceable arguments.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    /// <param name="item4"></param>
    /// <param name="item5"></param>
    public delegate void ActionRef<T1, T2, T3, T4, T5>(ref T1 item1, T2 item2, T3 item3, T4 item4, T5 item5);

    /// <summary>
    /// A delegate type with referenceable arguments.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    /// <param name="item4"></param>
    /// <param name="item5"></param>
    public delegate void ActionRef1<T1, T2, T3, T4, T5>(ref T1 item1, ref T2 item2, T3 item3, T4 item4, T5 item5);

    /// <summary>
    /// A delegate type with referenceable arguments.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    /// <param name="item4"></param>
    /// <param name="item5"></param>
    public delegate void ActionRef2<T1, T2, T3, T4, T5>(ref T1 item1, ref T2 item2, ref T3 item3, T4 item4, T5 item5);

    /// <summary>
    /// A delegate type with referenceable arguments.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    /// <param name="item4"></param>
    /// <param name="item5"></param>
    public delegate void ActionRef3<T1, T2, T3, T4, T5>(ref T1 item1, ref T2 item2, ref T3 item3, ref T4 item4, T5 item5);

    /// <summary>
    /// A delegate type with referenceable arguments.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <param name="item3"></param>
    /// <param name="item4"></param>
    /// <param name="item5"></param>
    public delegate void ActionRef4<T1, T2, T3, T4, T5>(ref T1 item1, ref T2 item2, ref T3 item3, ref T4 item4, ref T5 item5);
}
