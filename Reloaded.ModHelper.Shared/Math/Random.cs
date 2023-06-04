using System;
using System.Collections.Generic;
using System.Linq;

namespace Reloaded.ModHelper;

/// <summary>
/// A ThreadSafe way to easily generate random data for games. Based off of Unity's Random class.
/// </summary>
public sealed class Random
{
    /// <summary>
    /// Instance of ThreadSafeRandom that is used in this class.
    /// </summary>
    public static ThreadSafeRandom _random { get => ThreadSafeRandom.Global; }

    /// <summary>
    /// Initializes the random number generator state with a seed.
    /// </summary>
    /// <param name="seed"></param>
    public static void InitSeed(int seed)
    {
        _random.InitSeed(seed);
    }

    /// <summary>
    /// Returns a random number between min (inclusive) and max (exclusive).
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static int Range(int min, int max)
    {
        return _random.Next(min, max);
    }

    /// <summary>
    /// Returns a random number between min (inclusive) and max (exclusive).
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static float Range(float min, float max)
    {
        return (float)_random.NextDouble(min, max);
    }

    /// <summary>
    /// Returns a random number between min (inclusive) and max (exclusive).
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static double Range(double min, double max)
    {
        return _random.NextDouble(min, max);
    }

    /// <summary>
    /// Returns a random long from min (inclusive) to max (exclusive)
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static long Range(long min, long max)
    {
        return _random.NextLong(min, max);
    }

    /// <summary>
    /// Returns a random unsigned long (ulong) from min (inclusive) to max (exclusive)
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static ulong Range(ulong min, ulong max)
    {
        return _random.NextULong(min, max);
    }


    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="rectangle"></param>
    /// <returns></returns>
    public static Vector2f GetPoint(Rectangle rectangle)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="circle"></param>
    /// <returns></returns>
    public static Vector2f GetPoint(Circle circle)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="sphere"></param>
    /// <returns></returns>
    public static Vector3f GetPoint(Sphere sphere)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="cube"></param>
    /// <returns></returns>
    public static Vector3f GetPoint(Cube cube)
    {
        throw new NotImplementedException();
    }


    /// <summary>
    /// Returns a random enum value from the provided enum.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetEnum<T>()
    {
        return (T)GetEnum(typeof(T));
    }


    /// <summary>
    /// Returns a random enum value from the provided enum.
    /// </summary>
    /// <returns></returns>
    public static object GetEnum(Type enumType)
    {
        if (!enumType.IsEnum)
            throw new ArgumentException("Can't get random enum value because provided type is not an enum.");

        var values = Enum.GetValues(enumType);
        int maxRandomNumber = values.Length;

        int randomNumber = Random.Range(0, maxRandomNumber);
        return Convert.ChangeType(values.GetValue(randomNumber), enumType);
    }


    public static T GetElement<T>(List<T> list) => GetElement(list, 0, list.Count);

    public static T GetElement<T>(List<T> list, int startInclusive, int endExclusive)
    {
        if (startInclusive < 0 || endExclusive > list.Count)
            throw new IndexOutOfRangeException();

        var randomIndex = Range(startInclusive, endExclusive);
        return list[randomIndex];
    }

    public static T GetElement<T>(T[] array) => GetElement(array, 0, array.Length);

    public static T GetElement<T>(T[] array, int startInclusive, int endExclusive)
    {
        if (startInclusive < 0 || endExclusive > array.Length)
            throw new IndexOutOfRangeException();

        var randomIndex = Range(startInclusive, endExclusive);
        return array[randomIndex];
    }

    public static KeyValuePair<TKey, TValue> GetElement<TKey, TValue>(Dictionary<TKey, TValue> dictionary) => GetElement(dictionary, 0, dictionary.Count);

    public static KeyValuePair<TKey, TValue> GetElement<TKey, TValue>(Dictionary<TKey, TValue> dictionary, int startInclusive, int endExclusive)
    {
        if (startInclusive < 0 || endExclusive > dictionary.Count)
            throw new IndexOutOfRangeException();

        var randomIndex = Range(startInclusive, endExclusive);
        return dictionary.ElementAt(randomIndex);
    }
}
