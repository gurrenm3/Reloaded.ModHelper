using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Reloaded.ModHelper;

/// <summary>
/// Used to represent vector 4D position. Heavily based off of Unity's Vector4 class.
/// </summary>
/// <remarks>Documentation: https://docs.unity3d.com/2023.2/Documentation/ScriptReference/Vector4.html </remarks>
[StructLayout(LayoutKind.Explicit)]
public struct Vector4f : IEquatable<Vector4f>, IEquatable<Vector4>
{
    #region Static Properties

    /// <summary>
    /// Shorthand for writing Vector4(0,0,0,0).
    /// </summary>
    private static Vector4f Zero { get; } = new Vector4f(0f, 0f, 0f, 0f);

    /// <summary>
    /// Shorthand for writing Vector4(1,1,1,1).
    /// </summary>
    private static Vector4f One { get; } = new Vector4f(1f, 1f, 1f, 1f);

    /// <summary>
    /// Shorthand for writing Vector4(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity).
    /// </summary>
    private static Vector4f PositiveInfinity { get; } = new Vector4f(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

    /// <summary>
    /// Shorthand for writing Vector4(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity).
    /// </summary>
    private static Vector4f NegativeInfinity { get; } = new Vector4f(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
    
    public const float kEpsilon = 1E-05f;

    #endregion


    #region Properties

    /// <summary>
    /// X component of the vector.
    /// </summary>
    [FieldOffset(0x0)] public float x;

    /// <summary>
    /// Y component of the vector.
    /// </summary>
    [FieldOffset(0x4)] public float y;

    /// <summary>
    /// Z component of the vector.
    /// </summary>
    [FieldOffset(0x8)] public float z;

    /// <summary>
    /// W component of the vector.
    /// </summary>
    [FieldOffset(0xC)] public float w;

    /// <summary>
    /// Access the x, y, z, w components using [0], [1], [2], [3] respectively.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
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
                case 2:
                    result = this.z;
                    break;
                case 3:
                    result = this.w;
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid Vector4 index!");
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
                case 2:
                    this.z = value;
                    break;
                case 3:
                    this.w = value;
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid Vector4 index!");
            }
        }
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates vector <see cref="Vector4f"/> with all of it's values equal to <paramref name="value"/>.
    /// </summary>
    /// <param name="value"></param>
    public Vector4f(float value) : this(value, value, value, value)
    {

    }

    /// <summary>
    /// Creates vector <see cref="Vector4f"/> providing only it's X and Y coordinates, with Z and W set to zero. 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Vector4f(float x, float y) : this(x, y, 0, 0)
    {

    }

    /// <summary>
    /// Creates vector <see cref="Vector4f"/> providing only it's X, Y, and Z, coordinates with W set to zero.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public Vector4f(float x, float y, float z) : this(x, y, z, 0)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = 0f;
    }

    /// <summary>
    /// Creates vector <see cref="Vector4f"/> with all of it's corresponding coordinates.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <param name="w"></param>
    public Vector4f(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    #endregion


    #region Methods

    /// <summary>
    /// Set x, y, z and w components of an existing Vector4 to vector new value.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public Vector4f Set(float value)
    {
        return Set(value, value, value, value);
    }

    /// <summary>
    /// Set x, y, z and w components of an existing Vector4.
    /// </summary>
    /// <param name="newX"></param>
    /// <param name="newY"></param>
    /// <param name="newZ"></param>
    /// <param name="newW"></param>
    /// <returns></returns>
    public Vector4f Set(float newX, float newY, float newZ, float newW)
    {
        this.x = newX;
        this.y = newY;
        this.z = newZ;
        this.w = newW;
        
        return this;
    }

    /// <summary>
    /// Multiplies this vector and another component-wise.
    /// </summary>
    /// <param name="scale"></param>
    /// <returns></returns>
    public Vector4f Scale(Vector4f scale)
    {
        return Scale(this, scale);
    }

    /// <summary>
    /// Returns true if the given vector is exactly equal to this vector.
    /// </summary>
    /// <param name="other"></param>
    /// <returns>Returns true if the given vector is exactly equal to this vector.
    /// <br/>Due to floating point inaccuracies, this might return false for vectors which are essentially (but not exactly) equal. Use the == operator to test two vectors for approximate equality.</returns>
    public bool Equals(Vector4f other)
    {
        return this.x == other.x && this.y == other.y && this.z == other.z && this.w == other.w;
    }

    /// <summary>
    /// Returns true if the given vector is exactly equal to this vector.
    /// </summary>
    /// <param name="other"></param>
    /// <returns>Returns true if the given vector is exactly equal to this vector.
    /// <br/>Due to floating point inaccuracies, this might return false for vectors which are essentially (but not exactly) equal. Use the == operator to test two vectors for approximate equality.</returns>
    public bool Equals(Vector4 other)
    {
        return this.x == other.X && this.y == other.Y && this.z == other.Z && this.w == other.W;
    }

    /// <summary>
    /// Returns the squared length of this vector
    /// </summary>
    /// <returns></returns>
    public float GetSqrMagnitude()
    {
        return Vector4f.Dot(this, this);
    }

    /// <summary>
    /// Makes this vector have vector magnitude of 1.
    /// <br/>Note that this function will change the current vector.
    /// <br/>If this vector is too small to be normalized it will be set to zero.
    /// </summary>
    /// <returns></returns>
    public Vector4f NormalizeThis()
    {
        float num = Vector4f.GetMagnitude(this);
        bool flag = num > 1E-05f;
        if (flag)
        {
            this /= num;
        }
        else
        {
            this = Vector4f.Zero;
        }

        return this;
    }

    /// <summary>
    /// Returns vector new vector that has vector magnitude of 1.
    /// <br/>If this vector is too small to be normalized it will be set to zero.
    /// </summary>
    /// <returns></returns>
    public Vector4f NewNormalized()
    {
        return new Vector4f(x, y, z, w).NormalizeThis();
    }

    /// <summary>
    /// Linearly interpolates between two vectors.
    /// </summary>
    /// <param name="other"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public Vector4f Lerp(Vector4f other, float t)
    {
        return Lerp(this, other, t);
    }

    /// <summary>
    /// Linearly interpolates between this vector and another.
    /// </summary>
    /// <param name="other"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public Vector4f LerpUnclamped(Vector4f other, float t)
    {
        return LerpUnclamped(this, other, t);
    }

    /// <summary>
    /// Moves this point towards target.
    /// </summary>
    /// <param name="target"></param>
    /// <param name="maxDistanceDelta"></param>
    /// <returns></returns>
    public Vector4f MoveTowards(Vector4f target, float maxDistanceDelta)
    {
        return MoveTowards(this, target, maxDistanceDelta);
    }

    /// <summary>
    /// Dot Product of this vector and another.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public float Dot(Vector4f other)
    {
        return Dot(this, other);
    }

    /// <summary>
    /// Projects a vector onto another vector.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public Vector4f Project(Vector4f other)
    {
        return Project(this, other);
    }

    /// <summary>
    /// Returns the distance between this vector and another.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public float Distance(Vector4f other)
    {
        return Distance(this, other);
    }

    /// <summary>
    /// Returns the length of this vector.
    /// </summary>
    /// <returns></returns>
    public float GetMagnitude()
    {
        return GetMagnitude(this);
    }

    /// <summary>
    /// Returns a new vector that is made from the smallest components of this and another vector.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public Vector4f Min(Vector4f other)
    {
        return Min(this, other);
    }

    /// <summary>
    /// Returns a new vector that is made from the largest components of this and another vector.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public Vector4f Max(Vector4f other)
    {
        return Max(this, other);
    }

    #endregion















    #region Static Methods

    /// <summary>
    /// Returns the squared length of vector vector.
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    public static float SqrMagnitude(Vector4f vector)
    {
        return Vector4f.Dot(vector, vector);
    }

    /// <summary>
    /// Linearly interpolates between two vectors.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static Vector4f Lerp(Vector4f a, Vector4f b, float t)
    {
        t = Mathf.Clamp01(t);
        return new Vector4f(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t, a.z + (b.z - a.z) * t, a.w + (b.w - a.w) * t);
    }

    /// <summary>
    /// Linearly interpolates between two vectors.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static Vector4f LerpUnclamped(Vector4f a, Vector4f b, float t)
    {
        return new Vector4f(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t, a.z + (b.z - a.z) * t, a.w + (b.w - a.w) * t);
    }

    /// <summary>
    /// Moves a point current towards target.
    /// </summary>
    /// <param name="current"></param>
    /// <param name="target"></param>
    /// <param name="maxDistanceDelta"></param>
    /// <returns></returns>
    public static Vector4f MoveTowards(Vector4f current, Vector4f target, float maxDistanceDelta)
    {
        float num = target.x - current.x;
        float num2 = target.y - current.y;
        float num3 = target.z - current.z;
        float num4 = target.w - current.w;
        float num5 = num * num + num2 * num2 + num3 * num3 + num4 * num4;
        bool flag = num5 == 0f || (maxDistanceDelta >= 0f && num5 <= maxDistanceDelta * maxDistanceDelta);
        Vector4f result;
        if (flag)
        {
            result = target;
        }
        else
        {
            float num6 = (float)Mathf.Sqrt(num5);
            result = new Vector4f(current.x + num / num6 * maxDistanceDelta, current.y + num2 / num6 * maxDistanceDelta, current.z + num3 / num6 * maxDistanceDelta, current.w + num4 / num6 * maxDistanceDelta);
        }
        return result;
    }

    /// <summary>
    /// Multiplies two vectors component-wise.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Vector4f Scale(Vector4f a, Vector4f b)
    {
        return new Vector4f(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
    }

    /// <summary>
    /// Dot Product of two vectors.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static float Dot(Vector4f a, Vector4f b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
    }

    /// <summary>
    /// Projects a vector onto another vector.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Vector4f Project(Vector4f a, Vector4f b)
    {
        return b * (Vector4f.Dot(a, b) / Vector4f.Dot(b, b));
    }

    /// <summary>
    /// Returns the distance between a and b.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static float Distance(Vector4f a, Vector4f b)
    {
        return Vector4f.GetMagnitude(a - b);
    }

    /// <summary>
    /// Returns the length of a vector.
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static float GetMagnitude(Vector4f a)
    {
        return (float)Mathf.Sqrt(Vector4f.Dot(a, a));
    }

    /// <summary>
    /// Returns a new vector that is made from the smallest components of two vectors.
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Vector4f Min(Vector4f lhs, Vector4f rhs)
    {
        return new Vector4f(Mathf.Min(lhs.x, rhs.x), Mathf.Min(lhs.y, rhs.y), Mathf.Min(lhs.z, rhs.z), Mathf.Min(lhs.w, rhs.w));
    }

    /// <summary>
    /// Returns a new vector that is made from the largest components of two vectors.
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Vector4f Max(Vector4f lhs, Vector4f rhs)
    {
        return new Vector4f(Mathf.Max(lhs.x, rhs.x), Mathf.Max(lhs.y, rhs.y), Mathf.Max(lhs.z, rhs.z), Mathf.Max(lhs.w, rhs.w));
    }

    #endregion


    #region Overrides

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return this.x.GetHashCode() ^ this.y.GetHashCode() << 2 ^ this.z.GetHashCode() >> 2 ^ this.w.GetHashCode() >> 1;
    }

    /// <summary>
    /// Returns true if the given vector is exactly equal to this vector.
    /// </summary>
    /// <param name="other"></param>
    /// <returns>Returns true if the given vector is exactly equal to this vector.
    /// <br/>Due to floating point inaccuracies, this might return false for vectors which are essentially (but not exactly) equal. Use the == operator to test two vectors for approximate equality.</returns>
    public override bool Equals(object other)
    {
        bool isDifferentType = !(other is Vector4f);
        return !isDifferentType && this.Equals((Vector4f)other);
    }

    /// <summary>
    /// Returns vector formatted string for this vector.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"({x}, {y}, {z}, {w})";
    }

    #endregion


    #region Operators

    public static Vector4f operator +(Vector4f a, Vector4f b)
    {
        return new Vector4f(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
    }

    public static Vector4f operator -(Vector4f a, Vector4f b)
    {
        return new Vector4f(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
    }

    public static Vector4f operator -(Vector4f a)
    {
        return new Vector4f(-a.x, -a.y, -a.z, -a.w);
    }

    public static Vector4f operator *(Vector4f a, float d)
    {
        return new Vector4f(a.x * d, a.y * d, a.z * d, a.w * d);
    }

    public static Vector4f operator *(float d, Vector4f a)
    {
        return new Vector4f(a.x * d, a.y * d, a.z * d, a.w * d);
    }

    public static Vector4f operator /(Vector4f a, float d)
    {
        return new Vector4f(a.x / d, a.y / d, a.z / d, a.w / d);
    }

    public static bool operator ==(Vector4f lhs, Vector4f rhs)
    {
        float num = lhs.x - rhs.x;
        float num2 = lhs.y - rhs.y;
        float num3 = lhs.z - rhs.z;
        float num4 = lhs.w - rhs.w;
        float num5 = num * num + num2 * num2 + num3 * num3 + num4 * num4;
        return num5 < 9.9999994E-11f;
    }

    public static bool operator !=(Vector4f lhs, Vector4f rhs)
    {
        return !(lhs == rhs);
    }

    public static bool operator ==(Vector4f lhs, Vector4 rhs)
    {
        float num = lhs.x - rhs.X;
        float num2 = lhs.y - rhs.Y;
        float num3 = lhs.z - rhs.Z;
        float num4 = lhs.w - rhs.W;
        float num5 = num * num + num2 * num2 + num3 * num3 + num4 * num4;
        return num5 < 9.9999994E-11f;
    }

    public static bool operator !=(Vector4f lhs, Vector4 rhs)
    {
        return !(lhs == rhs);
    }

    public static bool operator ==(Vector4 lhs, Vector4f rhs)
    {
        float num = lhs.X - rhs.x;
        float num2 = lhs.Y - rhs.y;
        float num3 = lhs.Z - rhs.z;
        float num4 = lhs.W - rhs.w;
        float num5 = num * num + num2 * num2 + num3 * num3 + num4 * num4;
        return num5 < 9.9999994E-11f;
    }

    public static bool operator !=(Vector4 lhs, Vector4f rhs)
    {
        return !(lhs == rhs);
    }


    public static implicit operator Vector4(Vector4f v)
    {
        return new Vector4(v.x, v.y, v.z, v.w);
    }

    public static implicit operator Vector4f(Vector3 v)
    {
        return new Vector4f(v.X, v.Y, v.Z, 0f);
    }

    public static implicit operator Vector4f(Vector3f v)
    {
        return new Vector4f(v.x, v.y, v.z, 0f);
    }

    public static implicit operator Vector4f(Vector2 v)
    {
        return new Vector4f(v.X, v.Y, 0f, 0f);
    }

    public static implicit operator Vector4f(Vector2f v)
    {
        return new Vector4f(v.x, v.y, 0f, 0f);
    }

    public static implicit operator Vector3(Vector4f v)
    {
        return new Vector3(v.x, v.y, v.z);
    }

    public static implicit operator Vector3f(Vector4f v)
    {
        return new Vector3f(v.x, v.y, v.z);
    }

    public static implicit operator Vector2(Vector4f v)
    {
        return new Vector2(v.x, v.y);
    }

    public static implicit operator Vector2f(Vector4f v)
    {
        return new Vector2f(v.x, v.y);
    }

    #endregion
}
