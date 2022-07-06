using System;
using System.Threading;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// DotNet Random is not ThreadSafe so we need ThreadSafeRandom.
    /// See also: https://stackoverflow.com/questions/3049467/is-c-sharp-random-number-generator-thread-safe.
    /// Design notes:
    /// 1. Uses own Random for each thread (thread local).
    /// 2. Seed can be set in ThreadSafeRandom ctor. Note: Be careful - one seed for all threads can lead same values for several threads.
    /// 3. ThreadSafeRandom implements Random class for simple usage instead ordinary Random.
    /// 4. ThreadSafeRandom can be used by global static instance. Example: `int randomInt = ThreadSafeRandom.Global.Next()`.
    /// </summary>
    /// <remarks>Taken from: https://stackoverflow.com/a/68610454 </remarks>
    public class ThreadSafeRandom : System.Random
    {
        /// <summary>
        /// Gets global static instance.
        /// </summary>
        public static ThreadSafeRandom Global { get; } = new ThreadSafeRandom();

        // Thread local Random is safe to use on that thread.
        private ThreadLocal<System.Random> _threadLocalRandom;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreadSafeRandom"/> class.
        /// </summary>
        /// <param name="seed">Optional seed for <see cref="Random"/>. If not provided then random seed will be used.</param>
        public ThreadSafeRandom(int? seed = null)
        {
            _threadLocalRandom = new ThreadLocal<System.Random>(() => seed != null ? new System.Random(seed.Value) : new System.Random());
        }

        /// <summary>
        /// Initializes the random number generator state with a seed.
        /// </summary>
        /// <param name="seed"></param>
        public void InitSeed(int seed)
        {
            _threadLocalRandom = new ThreadLocal<System.Random>(() => new System.Random(seed));
        }

        /// <inheritdoc />
        public override int Next() => _threadLocalRandom.Value.Next();

        /// <inheritdoc />
        public override int Next(int maxValue) => _threadLocalRandom.Value.Next(maxValue);

        /// <inheritdoc />
        public override int Next(int minValue, int maxValue) => _threadLocalRandom.Value.Next(minValue, maxValue);

        /// <inheritdoc />
        public override void NextBytes(byte[] buffer) => _threadLocalRandom.Value.NextBytes(buffer);

        /// <inheritdoc />
        public override void NextBytes(Span<byte> buffer) => _threadLocalRandom.Value.NextBytes(buffer);

        /// <inheritdoc />
        public override double NextDouble() => _threadLocalRandom.Value.NextDouble();

        /// <summary>
        /// Returns a random floating point value between <paramref name="minValue"/> and <paramref name="maxValue"/>
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public double NextDouble(double minValue, double maxValue) => _threadLocalRandom.Value.NextDouble(minValue, maxValue);
    }
}
