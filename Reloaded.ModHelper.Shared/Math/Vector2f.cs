using System;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Reloaded.ModHelper;

/// <summary>
/// Used to represent a 2D position. Heavily based off of Unity's Vector2 struct.
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Explicit)]
public struct Vector2f : IEquatable<Vector2f>, IEquatable<Vector2>
{

    #region Static Properties

    /// <summary>
    /// Shorthand for writing Vector2f(float.PositiveInfinity, float.PositiveInfinity).
    /// </summary>
    public static Vector2f PositiveInfinity { get; } = new Vector2f(float.PositiveInfinity, float.PositiveInfinity);

    /// <summary>
    /// Shorthand for writing Vector2f(float.NegativeInfinity, float.NegativeInfinity).
    /// </summary>
    public static Vector2f NegativeInfinity { get; } = new Vector2f(float.NegativeInfinity, float.NegativeInfinity);


    /// <summary>
    /// Shorthand for writing Vector2f(0, 0).
    /// </summary>
    public static Vector2f Zero { get ; } = new Vector2f(0, 0);

    /// <summary>
    /// Shorthand for writing Vector2f(0, -1).
    /// </summary>
    public static Vector2f Down { get ; } = new Vector2f(0, -1);

    /// <summary>
    /// 	Shorthand for writing Vector2f(-1, 0).
    /// </summary>
    public static Vector2f Left { get; } = new Vector2f(-1, 0);

    /// <summary>
    /// Shorthand for writing Vector2f(0, 1).
    /// </summary>
    public static Vector2f Up { get; } = new Vector2f(0, 1);

    /// <summary>
    /// Shorthand for writing Vector2f(1, 0).
    /// </summary>
    public static Vector2f Right { get; } = new Vector2f(1, 0);

    /// <summary>
    /// Shorthand for writing Vector2f(1, 1).
    /// </summary>
    public static Vector2f One { get; } = new Vector2f(1, 1);

    #endregion


    #region Properties

    /// <summary>
    /// The x coordinate of this position.
    /// </summary>
    [FieldOffset(0)] public float x;

    /// <summary>
    /// The y coordinate of this position.
    /// </summary>        
    [FieldOffset(4)] public float y;

    public float this[int index]
    {
        get
        {
            float result;
            switch (index)
            {
                case 0:
                    result = this.x;
                    break;
                case 1:
                    result = this.y;
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid Vector3 index!");
            }
            return result;
        }
        set
        {
            switch (index)
            {
                case 0:
                    this.x = value;
                    break;
                case 1:
                    this.y = value;
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid Vector3 index!");
            }
        }
    }

    #endregion


    #region Constructors

    /// <summary>
    /// Default constructor for <see cref="Vector2f"/>.
    /// </summary>
    /// <param name="x">x coordinate.</param>
    /// <param name="y">y coordinate.</param>
    public Vector2f(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    /// <summary>
    /// Creates a Vector2f out of a <see cref="Point"/>.
    /// </summary>
    /// <param name="point">Point to use for x and y coords.</param>
    public Vector2f(Point point)
    {
        x = point.X;
        y = point.Y;
    }

    #endregion


    #region Methods

    /// <summary>
    /// The length of the vector is square root of (x*x) + (y*y).
    /// <br/><br/>If you only need to compare magnitudes of some vectors, you can compare squared magnitudes of them using sqrMagnitude (computing squared magnitudes is faster).
    /// </summary>
    public float GetMagnitude() => Mathf.Sqrt(GetSqrMagnitude());


    /// <summary>
    /// Calculating the squared magnitude instead of the magnitude is much faster. Often if you are comparing magnitudes of two vectors you can just compare their squared magnitudes.
    /// </summary>
    public float GetSqrMagnitude() => (x * x) + (y * y);

    /// <summary>
    /// Returns a new Vector with a magnitude of 1 (Read Only)
    /// <br/>When NewNormalized, a vector keeps the same direction but its length is 1.0.
    /// <br/><br/>Note that the current vector is unchanged and a new NewNormalized vector is returned. 
    /// If you want to normalize the current vector, use <see cref="NormalizeThis"/> function.
    /// <br/>If this vector is too small to be NewNormalized it will be set to zero.
    /// </summary>
    public Vector2f NewNormalized()
    {
        return new Vector2f(x, y).NormalizeThis();
    }

    /// <summary>
    /// Makes this vector have a magnitude of 1.
    /// <br/>When NewNormalized, a vector keeps the same direction but its length is 1.0.
    /// <br/><br/>Note that this function will change the current vector.
    /// If you want to keep the current vector unchanged, use <see cref="NewNormalized"/> variable.
    /// <br/>If this vector is too small to be NewNormalized it will be set to zero.
    /// </summary>
    /// <returns>This Vector after it has been NewNormalized.</returns>
    public Vector2f NormalizeThis()
    {
        float magnitude = this.GetMagnitude();
        if (magnitude > 1E-05f)
        {
            this /= magnitude;
        }
        else
        {
            this = Vector2f.Zero;
        }

        return this;
    }

    /// <summary>
    /// Multiplies every component of this vector by the same component of <paramref name="scale"/>
    /// </summary>
    /// <param name="scale"></param>
    /// <returns>This Vector after it has been scaled.</returns>
    public Vector2f Scale(Vector2f scale)
    {
        x *= scale.x;
        y *= scale.y;
        return this;
    }

    /// <summary>
    /// Set x and y components of an existing Vector2f.
    /// </summary>
    /// <param name="newValue">The value to set both <see cref="x"/> and <see cref="y"/> to.</param>
    /// <returns>This Vector after it has been set.</returns>
    public Vector2f Set(float newValue)
    {
        return Set(newValue, newValue);
    }

    /// <summary>
    /// Set x and y components of an existing Vector2f.
    /// </summary>
    /// <param name="newX">New x coordinate.</param>
    /// <param name="newY">New y coordinate.</param>
    /// <returns>This Vector after it has been set.</returns>
    public Vector2f Set(float newX, float newY)
    {
        x = newX;
        y = newY;
        return this;
    }








    /// <summary>
    /// Returns the unsigned angle in degrees between this vector and <paramref name="to"/>.
    /// </summary>
    /// <param name="to"></param>
    /// <returns></returns>
    public float GetAngle(Vector2f to)
    {
        return GetAngle(this, to);
    }

    /// <summary>
    /// Returns a copy of this vector with its magnitude clamped to <paramref name="maxLength"/>
    /// </summary>
    /// <param name="maxLength"></param>
    /// <returns></returns>
    public Vector2f ClampMagnitude(float maxLength)
    {
        return ClampMagnitude(this, maxLength);
    }

    /// <summary>
    /// Returns the distance between this vector and <paramref name="other"/>.
    /// </summary>
    /// <param name="other">Ending point.</param>
    /// <returns>The distance between both points.</returns>
    public float GetDistance(Vector2f other)
    {
        return GetDistance(this, other);
    }

    /// <summary>
    /// Returns Dot Product of two Vectors.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public float GetDot(Vector2f other)
    {
        return GetDot(this, other);
    }

    /// <summary>
    /// Linearly interpolates between this vector and 
    /// <paramref name="other"/> by <paramref name="value"/>.
    /// 
    /// <br/>
    /// <br/>When <paramref name="value"/> = 0 returns this. 
    /// <br/>When <paramref name="value"/> = 1 return <paramref name="other"/>. 
    /// <br/>When <paramref name="value"/> = 0.5 returns the midpoint of this
    /// and <paramref name="other"/>.
    /// </summary>
    /// <param name="other"></param>
    /// <param name="value">The clamped to the range [0, 1].</param>
    /// <returns></returns>
    public Vector2f Lerp(Vector2f other, float value)
    {
        return Lerp(this, other, value);
    }

    /// <summary>
    /// Linearly interpolates between this vector and 
    /// <paramref name="other"/> by <paramref name="value"/>.
    /// 
    /// <br/>
    /// <br/>When <paramref name="value"/> = 0 returns this. 
    /// <br/>When <paramref name="value"/> = 1 return <paramref name="other"/>. 
    /// <br/>When <paramref name="value"/> = 0.5 returns the midpoint of this
    /// and <paramref name="other"/>.
    /// </summary>
    /// <param name="other"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public Vector2f LerpUnclamped(Vector2f other, float value)
    {
        return LerpUnclamped(other, value);
    }

    /// <summary>
    /// Returns a new vector that is made from the largest components of this and another vector.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public Vector2f GetMax(Vector2f other)
    {
        return GetMax(this, other);
    }

    /// <summary>
    /// Returns a vector that is made from the smallest components of this and another vector.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public Vector2f GetMin(Vector2f other)
    {
        return GetMin(this, other);
    }

    /// <summary>
    /// Moves this vector towards <paramref name="target"/>.
    /// <br/><br/>This is essentially the same as <see cref="Lerp(Vector2f, Vector2f, float)"/>
    /// but instead the function will ensure that the distance never exceeds <paramref name="maxDistanceDelta"/>.
    /// Negative values of <paramref name="maxDistanceDelta"/> pushes the vector away from <paramref name="target"/>.
    /// </summary>
    /// <param name="target"></param>
    /// <param name="maxDistanceDelta"></param>
    /// <returns></returns>
    public Vector2f MoveTowards(Vector2f target, float maxDistanceDelta)
    {
        return MoveTowards(this, target, maxDistanceDelta);
    }

    /// <summary>
    /// Returns a new 2D vector perpendicular to this 2D vector. The result is always rotated 90-degrees in a counter-clockwise direction for a 2D coordinate system where the positive y axis goes up.
    /// </summary>
    /// <returns>A new Vector2f in the perpendicular direction.</returns>
    public Vector2f Perpendicular()
    {
        return Perpendicular(this);
    }

    /// <summary>
    /// Reflects this vector off the vector defined by a normal.
    /// </summary>
    /// <param name="inNormal"></param>
    /// <returns></returns>
    public Vector2f Reflect(Vector2f inNormal)
    {
        return Reflect(this, inNormal);
    }

    /// <summary>
    /// Returns the signed angle in degrees between this vector and <paramref name="to"/>.
    /// <br/><br/>The angle returned is the signed acute clockwise angle between the two vectors. This means the smaller of the two possible angles between the two vectors is used. The result is never greater than 180 degrees or smaller than -180 degrees.
    /// </summary>
    /// <param name="to">The vector to which the angular difference is measured.</param>
    /// <returns></returns>
    public float SignedAngle(Vector2f to)
    {
        return SignedAngle(this, to);
    }

    /// <summary>
    /// Gradually changes this vector towards a desired goal over time.
    /// <br/>The vector is smoothed by some spring-damper like function, which will never overshoot.
    /// </summary>
    /// <param name="target">The position we are trying to reach.</param>
    /// <param name="currentVelocity">The current velocity, this value is modified by the function every time you call it.</param>
    /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
    /// <param name="deltaTime">The time since the last call to this function. Recommended to use <see cref="ITime.DeltaTime"/>.</param>
    /// <param name="maxSpeed">Optionally allows you to clamp the maximum speed.</param>
    /// <returns></returns>
    public Vector2f SmoothDamp(Vector2f target, ref Vector2f currentVelocity, float smoothTime, float deltaTime, float maxSpeed = Mathf.Infinity)
    {
        return SmoothDamp(this, target, ref currentVelocity, smoothTime, deltaTime, maxSpeed);
    }

    /// <summary>
    /// Returns true if the given vector is exactly equal to this vector.
    /// <br/>Due to floating point inaccuracies, this might return false for vectors which are essentially (but not exactly) equal. Use the == operator to test two vectors for approximate equality.
    /// </summary>
    /// <param name="other">Vector to comapre</param>
    /// <returns></returns>
    public bool Equals(Vector2f other)
    {
        return this.x == other.x && this.y == other.y;
    }

    /// <summary>
    /// Returns true if the given vector is exactly equal to this vector.
    /// <br/>Due to floating point inaccuracies, this might return false for vectors which are essentially (but not exactly) equal. Use the == operator to test two vectors for approximate equality.
    /// </summary>
    /// <param name="other">Vector to comapre</param>
    /// <returns></returns>
    public bool Equals(Vector2 other)
    {
        return this.x == other.X && this.y == other.Y;
    }

    /// <summary>
    /// Returns a formatted string for this vector.
    /// </summary>
    /// <returns>A string of all the coordinate properties in order.
    /// <br/>Ex: (0, 10)</returns>
    public override string ToString()
    {
        return $"({x}, {y})";
    }

    /// <summary>
    /// Returns true if the given vector is exactly equal to this vector.
    /// <br/>Due to floating point inaccuracies, this might return false for vectors which are essentially (but not exactly) equal. Use the == operator to test two vectors for approximate equality.
    /// </summary>
    /// <param name="other">Vector to comapre</param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        bool isVector = obj is Vector2f;
        return isVector ? this.Equals((Vector2f)obj) : false;
    }

    /// <summary>
    /// An override of the default GetHashCode method. Taken straigt from Unity.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return this.x.GetHashCode() ^ this.y.GetHashCode() << 2;
    }

    #endregion


    #region Static Methods

    /// <summary>
    /// Returns the unsigned angle in degrees between <paramref name="from"/> and <paramref name="to"/>.
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public static float GetAngle(Vector2f from, Vector2f to)
    {
        float num = (float)Math.Sqrt((double)(from.GetSqrMagnitude() * to.GetSqrMagnitude()));
        float result = 0f;

        if (num >= 1E-15f)
        {
            float num2 = Mathf.Clamp(Vector2f.GetDot(from, to) / num, -1f, 1f);
            result = (float)Math.Acos((double)num2) * 57.29578f;
        }

        return result;
    }

    /// <summary>
    /// Returns a copy of <paramref name="vector"/> with its magnitude clamped to <paramref name="maxLength"/>
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="maxLength"></param>
    /// <returns></returns>
    public static Vector2f ClampMagnitude(Vector2f vector, float maxLength)
    {
        float sqrMagnitude = vector.GetSqrMagnitude();
        Vector2f result = vector;

        if (sqrMagnitude > maxLength * maxLength)
        {
            float num = (float)Math.Sqrt((double)sqrMagnitude);
            float num2 = vector.x / num;
            float num3 = vector.y / num;
            result = new Vector2f(num2 * maxLength, num3 * maxLength);
        }

        return result;
    }

    /// <summary>
    /// Returns the distance between <paramref name="point1"/> and <paramref name="other"/>.
    /// </summary>
    /// <param name="point1">Starting point.</param>
    /// <param name="other">Ending point.</param>
    /// <returns>The distance between both points.</returns>
    public static float GetDistance(Vector2f point1, Vector2f point2)
    {
        float x = point1.x - point2.x;
        float y = point1.y - point2.y;
        float sqrMagnitude = (x * x + y * y);
        return (float)Math.Sqrt(sqrMagnitude);
    }

    /// <summary>
    /// Returns Dot Product of two Vectors.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <returns></returns>
    public static float GetDot(Vector2f point1, Vector2f point2)
    {
        return (point1.x * point2.x) + (point1.y * point2.y);
    }

    /// <summary>
    /// Linearly interpolates between vectors <paramref name="point1"/> and 
    /// <paramref name="point2"/> by <paramref name="value"/>.
    /// 
    /// <br/>
    /// <br/>When <paramref name="value"/> = 0 returns <paramref name="point1"/>. 
    /// <br/>When <paramref name="value"/> = 1 return <paramref name="point2"/>. 
    /// <br/>When <paramref name="value"/> = 0.5 returns the midpoint of <paramref name="point1"/>
    /// and <paramref name="point2"/>.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <param name="value">The clamped to the range [0, 1].</param>
    /// <returns></returns>
    public static Vector2f Lerp(Vector2f point1, Vector2f point2, float value)
    {
        value = Mathf.Clamp01(value);

        float x = point1.x + (point2.x - point1.x) * value;
        float y = point1.y + (point2.y - point1.y) * value;
        return new Vector2f(x, y);
    }

    /// <summary>
    /// Linearly interpolates between vectors <paramref name="point1"/> and 
    /// <paramref name="point2"/> by <paramref name="value"/>.
    /// 
    /// <br/>
    /// <br/>When <paramref name="value"/> = 0 returns <paramref name="point1"/>. 
    /// <br/>When <paramref name="value"/> = 1 return <paramref name="point2"/>. 
    /// <br/>When <paramref name="value"/> = 0.5 returns the midpoint of <paramref name="point1"/>
    /// and <paramref name="point2"/>.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Vector2f LerpUnclamped(Vector2f point1, Vector2f point2, float value)
    {
        float x = point1.x + (point2.x - point1.x) * value;
        float y = point1.y + (point2.y - point1.y) * value;
        return new Vector2f(x, y);
    }

    /// <summary>
    /// Returns a new vector that is made from the largest components of two vectors.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="other"></param>
    /// <returns></returns>
    public static Vector2f GetMax(Vector2f point1, Vector2f point2)
    {
        return new Vector2f(Mathf.Max(point1.x, point2.x), Mathf.Max(point1.y, point2.y));
    }

    /// <summary>
    /// Returns a vector that is made from the smallest components of two vectors.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <returns></returns>
    public static Vector2f GetMin(Vector2f point1, Vector2f point2)
    {
        return new Vector2f(Mathf.Min(point1.x, point2.y), Mathf.Min(point1.x, point2.y));
    }

    /// <summary>
    /// Moves a point <paramref name="current"/> towards <paramref name="target"/>.
    /// <br/><br/>This is essentially the same as <see cref="Lerp(Vector2f, Vector2f, float)"/>
    /// but instead the function will ensure that the distance never exceeds <paramref name="maxDistanceDelta"/>.
    /// Negative values of <paramref name="maxDistanceDelta"/> pushes the vector away from <paramref name="target"/>.
    /// </summary>
    /// <param name="current"></param>
    /// <param name="target"></param>
    /// <param name="maxDistanceDelta"></param>
    /// <returns></returns>
    public static Vector2f MoveTowards(Vector2f current, Vector2f target, float maxDistanceDelta)
    {
        float num = target.x - current.x;
        float num2 = target.y - current.y;
        float num3 = num * num + num2 * num2;

        Vector2f result;
        if (num3 == 0f || (maxDistanceDelta >= 0f && num3 <= maxDistanceDelta * maxDistanceDelta))
        {
            result = target;
        }
        else
        {
            float num4 = (float)Math.Sqrt((double)num3);
            result = new Vector2f(current.x + num / num4 * maxDistanceDelta, current.y + num2 / num4 * maxDistanceDelta);
        }
        return result;
    }

    /// <summary>
    /// Returns a new 2D vector perpendicular to this 2D vector. The result is always rotated 90-degrees in a counter-clockwise direction for a 2D coordinate system where the positive y axis goes up.
    /// </summary>
    /// <param name="inDirection">The input direction.</param>
    /// <returns>A new Vector2f in the perpendicular direction.</returns>
    public static Vector2f Perpendicular(Vector2f inDirection)
    {
        return new Vector2f(-inDirection.y, inDirection.x);
    }

    /// <summary>
    /// Reflects a vector off the vector defined by a normal.
    /// </summary>
    /// <param name="inDirection">The input direction.</param>
    /// <param name="inNormal"></param>
    /// <returns></returns>
    public static Vector2f Reflect(Vector2f inDirection, Vector2f inNormal)
    {
        float num = -2f * GetDot(inNormal, inDirection);
        return new Vector2f(num * inNormal.x + inDirection.x, num * inNormal.y + inDirection.y);
    }

    /// <summary>
    /// Multiplies two vectors component-wise.
    /// <br/><br/>Every component in the result is a component of a multiplied by the same component of b.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <returns></returns>
    public static Vector2f Scale(Vector2f point1, Vector2f point2)
    {
        return new Vector2f(point1.x * point2.x, point1.y * point2.y);
    }

    /// <summary>
    /// Returns the signed angle in degrees between <paramref name="from"/> and <paramref name="to"/>.
    /// <br/><br/>The angle returned is the signed acute clockwise angle between the two vectors. This means the smaller of the two possible angles between the two vectors is used. The result is never greater than 180 degrees or smaller than -180 degrees.
    /// </summary>
    /// <param name="from">The vector from which the angular difference is measured.</param>
    /// <param name="to">The vector to which the angular difference is measured.</param>
    /// <returns></returns>
    public static float SignedAngle(Vector2f from, Vector2f to)
    {
        float num = Vector2f.GetAngle(from, to);
        float num2 = Mathf.Sign(from.x * to.y - from.y * to.x);
        return num * num2;
    }

    /// <summary>
    /// Gradually changes a vector towards a desired goal over time.
    /// <br/>The vector is smoothed by some spring-damper like function, which will never overshoot.
    /// </summary>
    /// <param name="current">The current position.</param>
    /// <param name="target">The position we are trying to reach.</param>
    /// <param name="currentVelocity">The current velocity, this value is modified by the function every time you call it.</param>
    /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
    /// <param name="deltaTime">The time since the last call to this function. Recommended to use <see cref="ITime.DeltaTime"/>.</param>
    /// <param name="maxSpeed">Optionally allows you to clamp the maximum speed.</param>
    /// <returns></returns>
    public static Vector2f SmoothDamp(Vector2f current, Vector2f target, ref Vector2f currentVelocity, float smoothTime, float deltaTime, float maxSpeed = Mathf.Infinity)
    {
        smoothTime = Mathf.Max(0.0001f, smoothTime);
        float num = 2f / smoothTime;
        float num2 = num * deltaTime;
        float num3 = 1f / (1f + num2 + 0.48f * num2 * num2 + 0.235f * num2 * num2 * num2);
        float num4 = current.x - target.x;
        float num5 = current.y - target.y;
        Vector2f vector = target;
        float num6 = maxSpeed * smoothTime;
        float num7 = num6 * num6;
        float num8 = num4 * num4 + num5 * num5;
        if (num8 > num7)
        {
            float num9 = (float)Math.Sqrt((double)num8);
            num4 = num4 / num9 * num6;
            num5 = num5 / num9 * num6;
        }
        target.x = current.x - num4;
        target.y = current.y - num5;
        float num10 = (currentVelocity.x + num * num4) * deltaTime;
        float num11 = (currentVelocity.y + num * num5) * deltaTime;
        currentVelocity.x = (currentVelocity.x - num * num10) * num3;
        currentVelocity.y = (currentVelocity.y - num * num11) * num3;
        float num12 = target.x + (num4 + num10) * num3;
        float num13 = target.y + (num5 + num11) * num3;
        float num14 = vector.x - current.x;
        float num15 = vector.y - current.y;
        float num16 = num12 - vector.x;
        float num17 = num13 - vector.y;
        if (num14 * num16 + num15 * num17 > 0f)
        {
            num12 = vector.x;
            num13 = vector.y;
            currentVelocity.x = (num12 - vector.x) / deltaTime;
            currentVelocity.y = (num13 - vector.y) / deltaTime;
        }
        return new Vector2f(num12, num13);
    }

    #endregion


    #region Operators

    /// <summary>
    /// Returns a new <see cref="Vector3f"/> whose values are taken from a <see cref="Vector2f"/>.
    /// </summary>
    /// <param name="point"></param>
    public static implicit operator Vector3f(Vector2f point)
    {
        return new Vector3f(point.x, point.y, 0);
    }

    /// <summary>
    /// Returns a new <see cref="Vector2f"/> whose values are taken from a <see cref="Vector3f"/>.
    /// </summary>
    /// <param name="point"></param>
    public static implicit operator Vector2f(Vector3f point)
    {
        return new Vector2f(point.x, point.y);
    }

    /// <summary>
    /// Returns a new <see cref="Vector2f"/> whose values are taken from a <see cref="Vector3f"/>.
    /// </summary>
    /// <param name="point"></param>
    public static implicit operator Vector2f(System.Numerics.Vector2 point)
    {
        return new Vector2f(point.X, point.Y);
    }


    /// <summary>
    /// Returns true if two vectors are approximately equal.
    /// </summary>
    /// <param name="point1">Point to check.</param>
    /// <param name="point2">Point to compare against.</param>
    /// <returns>True if the values of each Vector are approximately equal, otherwise false.</returns>
    public static bool operator ==(Vector2f point1, Vector2f point2)
    {
        float num = point1.x - point2.x;
        float num2 = point1.y - point2.y;
        return num * num + num2 * num2 < 9.99999944E-11f;
    }

    /// <summary>
    /// Returns true if two vectors are not equal.
    /// </summary>
    /// <param name="point1">Point to check.</param>
    /// <param name="point2">Point to compare against.</param>
    /// <returns>True if the values of each Vector are approximately equal, otherwise false.</returns>
    public static bool operator !=(Vector2f point1, Vector2f point2)
    {
        return !(point1 == point2);
    }

    /// <summary>
    /// Returns true if two vectors are approximately equal.
    /// </summary>
    /// <param name="point1">Point to check.</param>
    /// <param name="point2">Point to compare against.</param>
    /// <returns>True if the values of each Vector are approximately equal, otherwise false.</returns>
    public static bool operator ==(Vector2f point1, Vector2 point2)
    {
        float num = point1.x - point2.X;
        float num2 = point1.y - point2.Y;
        return num * num + num2 * num2 < 9.99999944E-11f;
    }

    /// <summary>
    /// Returns true if two vectors are not equal.
    /// </summary>
    /// <param name="point1">Point to check.</param>
    /// <param name="point2">Point to compare against.</param>
    /// <returns>True if the values of each Vector are approximately equal, otherwise false.</returns>
    public static bool operator !=(Vector2f point1, Vector2 point2)
    {
        return !(point1 == point2);
    }

    /// <summary>
    /// Returns true if two vectors are approximately equal.
    /// </summary>
    /// <param name="point1">Point to check.</param>
    /// <param name="point2">Point to compare against.</param>
    /// <returns>True if the values of each Vector are approximately equal, otherwise false.</returns>
    public static bool operator ==(Vector2 point1, Vector2f point2)
    {
        float num = point1.X - point2.x;
        float num2 = point1.Y - point2.y;
        return num * num + num2 * num2 < 9.99999944E-11f;
    }

    /// <summary>
    /// Returns true if two vectors are not equal.
    /// </summary>
    /// <param name="point1">Point to check.</param>
    /// <param name="point2">Point to compare against.</param>
    /// <returns>True if the values of each Vector are approximately equal, otherwise false.</returns>
    public static bool operator !=(Vector2 point1, Vector2f point2)
    {
        return !(point1 == point2);
    }


    /// <summary>
    /// Adds one Vector to another.
    /// </summary>
    /// <param name="point1">Vector to add to.</param>
    /// <param name="point2">Vector whose values you want to add to <paramref name="point1"/>.</param>
    /// <returns>A new Vector whose values are <paramref name="point1"/> + <paramref name="point2"/>.</returns>
    public static Vector2f operator +(Vector2f point1, Vector2f point2)
    {
        return new Vector2f(point1.x + point2.x, point1.y + point2.y);
    }

    /// <summary>
    /// Add an amount to both points of a Vector.
    /// </summary>
    /// <param name="point1">Vector to add to.</param>
    /// <param name="amount">Amount to add by.</param>
    /// <returns>A new Vector whose values are <paramref name="point1"/> + <paramref name="amount"/>.</returns>
    public static Vector2f operator +(Vector2f point1, float amount)
    {
        return new Vector2f(point1.x + amount, point1.y + amount);
    }

    /// <summary>
    /// Subtracts one Vector from another.
    /// </summary>
    /// <param name="point1">Vector to subtract from.</param>
    /// <param name="point2">Vector whose values you want to subtract from <paramref name="point1"/>.</param>
    /// <returns>A new Vector whose values are <paramref name="point1"/> - <paramref name="point2"/>.</returns>
    public static Vector2f operator -(Vector2f point1, Vector2f point2)
    {
        return new Vector2f(point1.x - point2.x, point1.y - point2.y);
    }

    /// <summary>
    /// Subtracts an amount from both points of the Vector.
    /// </summary>
    /// <param name="point1">Vector to subtract from.</param>
    /// <param name="amount">Amount to subtract.</param>
    /// <returns>A new Vector whose values are <paramref name="point1"/> - <paramref name="amount"/>.</returns>
    public static Vector2f operator -(Vector2f point1, float amount)
    {
        return new Vector2f(point1.x - amount, point1.y - amount);
    }

    /// <summary>
    /// Multiplies one Vector by another.
    /// </summary>
    /// <param name="point1">Vector to multiply.</param>
    /// <param name="point2">Vector to multiply by.</param>
    /// <returns>A new Vector whose values are <paramref name="point1"/> * <paramref name="point2"/>.</returns>
    public static Vector2f operator *(Vector2f point1, Vector2f point2)
    {
        return new Vector2f(point1.x * point2.x, point1.y * point2.y);
    }

    /// <summary>
    /// Multiply both points of a Vector by an amount.
    /// </summary>
    /// <param name="point1">Vector to multiply.</param>
    /// <param name="amount">Amount to multiply by.</param>
    /// <returns>A new Vector whose values are <paramref name="point1"/> * <paramref name="amount"/>.</returns>
    public static Vector2f operator *(Vector2f point1, float amount)
    {
        return new Vector2f(point1.x * amount, point1.y * amount);
    }

    /// <summary>
    /// Divide one Vector by another.
    /// </summary>
    /// <param name="point1">Vector to divide.</param>
    /// <param name="point2">Vector to divide by.</param>
    /// <returns>A new Vector whose values are <paramref name="point1"/> / <paramref name="point2"/>.</returns>
    public static Vector2f operator /(Vector2f point1, Vector2f point2)
    {
        return new Vector2f(point1.x / point2.x, point1.y / point2.y);
    }

    /// <summary>
    /// Divide both points of a Vector by an amount.
    /// </summary>
    /// <param name="point1">Vector to divide.</param>
    /// <param name="amount">Amount to divide by.</param>
    /// <returns>A new Vector whose values are <paramref name="point1"/> / <paramref name="amount"/>.</returns>
    public static Vector2f operator /(Vector2f point1, float amount)
    {
        return new Vector2f(point1.x / amount, point1.y / amount);
    }

    #endregion
}