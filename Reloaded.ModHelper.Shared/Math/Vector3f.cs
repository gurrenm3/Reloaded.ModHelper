using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Reloaded.ModHelper;

/// <summary>
/// Used to represent a 3D position. Heavily based off of Unity's Vector3 class.
/// </summary>
/// <remarks>Documentation: https://docs.unity3d.com/ScriptReference/Vector3f.html </remarks>
[Serializable]
[StructLayout(LayoutKind.Explicit)]
public struct Vector3f :  IEquatable<Vector3f>, IEquatable<Vector3>
{
    #region Static Properties

    /// <summary>
    /// Shorthand for writing Vector3f(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity).
    /// </summary>
    public static Vector3f PositiveInfinity { get; } = new Vector3f(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

    /// <summary>
    /// Shorthand for writing Vector3f(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity).
    /// </summary>
    public static Vector3f NegativeInfinity { get; } = new Vector3f(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);


    /// <summary>
    /// Shorthand for writing Vector3f(0, 0, 0).
    /// </summary>
    public static Vector3f Zero { get ; } = new Vector3f(0, 0, 0);

    /// <summary>
    /// Shorthand for writing Vector3f(1, 1, 1).
    /// </summary>
    public static Vector3f One { get ; } = new Vector3f(1f, 1f, 1f);

    /// <summary>
    /// Shorthand for writing Vector3f(0, 1, 0).
    /// </summary>
    public static Vector3f Up { get ; } = new Vector3f(0f, 1f, 0f);

    /// <summary>
    /// Shorthand for writing Vector3f(0, -1, 0).
    /// </summary>
    public static Vector3f Down { get ; } = new Vector3f(0f, -1f, 0f);

    /// <summary>
    /// Shorthand for writing Vector3f(-1, 0, 0).
    /// </summary>
    public static Vector3f Left { get ; } = new Vector3f(-1f, 0f, 0f);

    /// <summary>
    /// Shorthand for writing Vector3f(1, 0, 0).
    /// </summary>
    public static Vector3f Right { get ; } = new Vector3f(1f, 0f, 0f);

    /// <summary>
    /// Shorthand for writing Vector3f(0, 0, 1).
    /// </summary>
    public static Vector3f Forward { get ; } = new Vector3f(0f, 0f, 1f);

    /// <summary>
    /// Shorthand for writing Vector3f(0, 0, -1).
    /// </summary>
    public static Vector3f Back { get; } = new Vector3f(0f, 0f, -1f);

    #endregion


    #region Properties

    /// <summary>
    /// The x coordinate of this position.
    /// <br/><br/>TODO: Check if this works with Json.
    /// </summary>
    [FieldOffset(0x0)] public float x;

    /// <summary>
    /// The y coordinate of this position.
    /// <br/><br/>TODO: Check if this works with Json.
    /// </summary>
    [FieldOffset(0x4)] public float y;

    /// <summary>
    /// The z coordinate of this position.
    /// <br/><br/>TODO: Check if this works with Json.
    /// </summary>
    [FieldOffset(0x8)] public float z;

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
                case 2:
                    this.z = value;
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid Vector3 index!");
            }
        }
    }

    #endregion



    #region Fields

    public const float kEpsilon = 1E-05f;
    public const float kEpsilonNormalSqrt = 1E-15f;

    #endregion



    #region Constructors


    /// <summary>
    /// Creates a Vector3f whose x, y, z coordinates are all set to <paramref name="value"/>.
    /// </summary>
    /// <param name="value"></param>
    public Vector3f(float value) : this (value, value, value)
    {

    }


    /// <summary>
    /// Creates a Vector3f while providing it with it's X and Y coordinates, setting Z to zero.
    /// </summary>
    /// <param name="x">x coordinate.</param>
    /// <param name="y">y coordinate.</param>
    /// <param name="z">z coordinate.</param>
    public Vector3f(float x, float y) : this(x, y, 0)
    {

    }

    /// <summary>
    /// Creates a Vector3f while providing it with all of its coordinates.
    /// </summary>
    /// <param name="x">x coordinate.</param>
    /// <param name="y">y coordinate.</param>
    /// <param name="z">z coordinate.</param>
    public Vector3f(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    #endregion


    #region Methods

    /// <summary>
    /// The length of the vector is square root of (x*x) + (y*y) + (z*z).
    /// <br/><br/>If you only need to compare magnitudes of some vectors, you can compare squared magnitudes of them using sqrMagnitude (computing squared magnitudes is faster).
    /// </summary>
    public float GetMagnitude() => Mathf.Sqrt(GetSqrMagnitude());


    /// <summary>
    /// Calculating the squared magnitude instead of the magnitude is much faster. Often if you are comparing magnitudes of two vectors you can just compare their squared magnitudes.
    /// </summary>
    public float GetSqrMagnitude() => (x * x) + (y * y) + (z * z);


    /// <summary>
    /// Returns a new Vector with a magnitude of 1 (Read Only)
    /// <br/>When NewNormalized, a vector keeps the same direction but its length is 1.0.
    /// <br/><br/>Note that the current vector is unchanged and a new NewNormalized vector is returned. 
    /// If you want to normalize the current vector, use <see cref="NormalizeThis(Vector3f)"/> function.
    /// <br/>If this vector is too small to be NewNormalized it will be set to zero.
    /// </summary>
    public Vector3f NewNormalized()
    {
        return new Vector3f(x, y, z).NormalizeThis();
    }

    /// <summary>
    /// Makes this vector have a magnitude of 1.
    /// <br/>When NewNormalized, a vector keeps the same direction but its length is 1.0.
    /// <br/><br/>Note that this function will change the current vector.
    /// If you want to keep the current vector unchanged, use <see cref="NewNormalized"/> variable.
    /// <br/>If this vector is too small to be NewNormalized it will be set to zero.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public Vector3f NormalizeThis()
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
    /// Multiplies two vectors component-wise.
    /// </summary>
    /// <param name="scale"></param>
    /// <returns>This Vector after it has been scaled.</returns>
    public Vector3f Scale(Vector3f scale)
    {
        x *= scale.x;
        y *= scale.y;
        z *= scale.z;
        return this;
    }

    /// <summary>
    /// Set x, y and z components of an existing Vector3f.
    /// </summary>
    /// <param name="value">Value to set all components to.</param>
    /// <returns>This Vector after it has been set.</returns>
    public Vector3f Set(float value)
    {
        return Set(value, value, value);
    }

    /// <summary>
    /// Set x, y and z components of an existing Vector3f.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns>This Vector after it has been set.</returns>
    public Vector3f Set(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        return this;
    }

    /// <summary>
    /// Calculates the angle between this and another vector.
    /// </summary>
    /// <param name="to">The vector to which the angular difference is measured.</param>
    /// <returns>The angle in degrees between the two vectors.</returns>
    public float GetAngle(Vector3f to)
    {
        return GetAngle(this, to);
    }

    /// <summary>
    /// Returns a copy of this vector with its magnitude clamped to maxLength.
    /// </summary>
    /// <param name="maxLength"></param>
    /// <returns></returns>
    public Vector3f ClampMagnitude(float maxLength)
    {
        return ClampMagnitude(this, maxLength);
    }

    /// <summary>
    /// Cross Product of this and another vector.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public Vector3f Cross(Vector3f other)
    {
        return Cross(this, other);
    }

    /// <summary>
    /// Returns the distance between this and <paramref name="other"/>.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public float Distance(Vector3f other)
    {
        return Distance(this, other);
    }

    /// <summary>
    /// Dot Product of this and another vector.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public float GetDot(Vector3f other)
    {
        return GetDot(this, other);
    }

    /// <summary>
    /// Linearly interpolates between this and another vector, where <paramref name="value"/> will be
    /// clamped between [0, 1].
    /// 
    /// <br/>
    /// <br/>When <paramref name="value"/> = 0 returns <paramref name="point1"/>. 
    /// <br/>When <paramref name="value"/> = 1 return <paramref name="other"/>. 
    /// <br/>When <paramref name="value"/> = 0.5 returns the midpoint of <paramref name="point1"/> and <paramref name="other"/>.
    /// </summary>
    /// <param name="other">End value, returned when value = 1.</param>
    /// <param name="value">Value used to interpolate between point1 and other, clamped to the range of [0, 1].</param>
    /// <returns>Interpolated value, equals to <paramref name="point1"/> +
    /// (<paramref name="other"/> - <paramref name="point1"/>) * <paramref name="value"/>. </returns>
    public Vector3f Lerp(Vector3f other, float value)
    {
        return Lerp(this, other, value);
    }

    /// <summary>
    /// Linearly interpolates between two points.
    /// 
    /// <br/>
    /// <br/>When <paramref name="value"/> = 1 return <paramref name="other"/>. 
    /// <br/>When <paramref name="value"/> = 0.5 returns the midpoint of this and <paramref name="other"/>.
    /// </summary>
    /// <param name="other">End value, returned when value = 1.</param>
    /// <param name="value">Value used to interpolate between point1 and other.</param>
    /// <returns>Interpolated value, equals to this +
    /// (<paramref name="other"/> - this) * <paramref name="value"/>. </returns>
    public Vector3f LerpUnclamped(Vector3f other, float value)
    {
        return LerpUnclamped(this, other, value);
    }

    /// <summary>
    /// Returns a vector that is made from the largest components of this and another vector.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public Vector3f GetMax(Vector3f other)
    {
        return GetMax(this, other);
    }

    /// <summary>
    /// Returns a vector that is made from the smallest components of this and another vector.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public Vector3f GetMin(Vector3f other)
    {
        return GetMin(this, other);
    }

    /// <summary>
    /// Calculate a position between the points specified by this vector and target, moving no 
    /// farther than the distance specified by maxDistanceDelta.
    /// </summary>
    /// <param name="target">The position to move towards.</param>
    /// <param name="maxDistanceDelta">Distance to move this per call.</param>
    /// <returns></returns>
    public Vector3f MoveTowards(Vector3f target, float maxDistanceDelta)
    {
        return MoveTowards(this, target, maxDistanceDelta);
    }

    /// <summary>
    /// Projects a vector onto another vector.
    /// </summary>
    /// <param name="onNormal"></param>
    /// <returns></returns>
    public Vector3f Project(Vector3f onNormal)
    {
        return Project(this, onNormal);
    }

    /// <summary>
    /// Projects this vector onto a plane defined by a normal orthogonal to the plane.
    /// </summary>
    /// <param name="planeNormal">The direction from the vector towards the plane.</param>
    /// <returns></returns>
    public Vector3f ProjectOnPlane(Vector3f planeNormal)
    {
        return ProjectOnPlane(this, planeNormal);
    }

    /// <summary>
    /// Reflects this vector off the plane defined by a normal.
    /// </summary>
    /// <param name="inNormal"></param>
    /// <returns></returns>
    public Vector3f Reflect(Vector3f inNormal)
    {
        return Reflect(this, inNormal);
    }

    /// <summary>
    /// Calculates the signed angle between this and another vector in relation to axis.
    /// </summary>
    /// <param name="from">The vector from which the angular difference is measured.</param>
    /// <param name="to">The vector to which the angular difference is measured.</param>
    /// <param name="axis">A vector around which the other vectors are rotated.</param>
    /// <returns></returns>
    public float SignedAngle(Vector3f to, Vector3f axis)
    {
        return SignedAngle(this, to, axis);
    }

    /// <summary>
    /// Gradually changes this vector towards a desired goal over time.
    /// </summary>
    /// <param name="target">The position we are trying to reach.</param>
    /// <param name="currentVelocity">The current velocity, this value is modified by the function every time you call it.</param>
    /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
    /// <param name="deltaTime">The time since the last call to this function. By default <see cref="ITime.DeltaTime"/>.</param>
    /// <param name="maxSpeed">Optionally allows you to clamp the maximum speed.</param>
    /// <returns></returns>
    public Vector3f SmoothDamp(Vector3f target, ref Vector3f currentVelocity, float smoothTime, float deltaTime, float maxSpeed = Mathf.Infinity)
    {
        return SmoothDamp(this, target, ref currentVelocity, smoothTime, deltaTime, maxSpeed);
    }

    /// <summary>
    /// Returns true if the given vector is exactly equal to this vector.
    /// <br/>Due to floating point inaccuracies, this might return false for vectors which are essentially (but not exactly) equal. Use the == operator to test two vectors for approximate equality
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(Vector3f other)
    {
        return this.x == other.x && this.y == other.y && this.z == other.z;
    }

    /// <summary>
    /// Returns true if the given vector is exactly equal to this vector.
    /// <br/>Due to floating point inaccuracies, this might return false for vectors which are essentially (but not exactly) equal. Use the == operator to test two vectors for approximate equality
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(Vector3 other)
    {
        return this.x == other.X && this.y == other.Y && this.z == other.Z;
    }

    /// <summary>
    /// Returns a formatted string for this vector.
    /// </summary>
    /// <returns>A string of all the coordinate properties in order.
    /// <br/>Ex: (0, 10, 5)</returns>
    public override string ToString()
    {
        return $"({x}, {y}, {z})";
    }

    /// <summary>
    /// Returns true if the given vector is exactly equal to this vector.
    /// <br/>Due to floating point inaccuracies, this might return false for vectors which are essentially (but not exactly) equal. Use the == operator to test two vectors for approximate equality
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public override bool Equals(object other)
    {
        return other is Vector3f && this.Equals((Vector3f)other);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return this.x.GetHashCode() ^ this.y.GetHashCode() << 2 ^ this.z.GetHashCode() >> 2;
    }

    #endregion


    #region Static Methods

    /// <summary>
    /// Calculates the angle between two Vectors.
    /// </summary>
    /// <param name="from">The vector from which the angular difference is measured.</param>
    /// <param name="to">The vector to which the angular difference is measured.</param>
    /// <returns>The angle in degrees between the two vectors.</returns>
    public static float GetAngle(Vector3f from, Vector3f to)
    {
        float num = (float)Math.Sqrt((double)(from.GetSqrMagnitude() * to.GetSqrMagnitude()));
        float result;
        if (num < 1E-15f)
        {
            result = 0f;
        }
        else
        {
            float num2 = Mathf.Clamp(Vector3f.GetDot(from, to) / num, -1f, 1f);
            result = (float)Math.Acos((double)num2) * 57.29578f;
        }
        return result;
    }

    /// <summary>
    /// Returns a copy of vector with its magnitude clamped to maxLength.
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="maxLength"></param>
    /// <returns></returns>
    public static Vector3f ClampMagnitude(Vector3f vector, float maxLength)
    {
        float sqrMagnitude = vector.GetSqrMagnitude();
        Vector3f result;
        if (sqrMagnitude > maxLength * maxLength)
        {
            float num = (float)Math.Sqrt((double)sqrMagnitude);
            float num2 = vector.x / num;
            float num3 = vector.y / num;
            float num4 = vector.z / num;
            result = new Vector3f(num2 * maxLength, num3 * maxLength, num4 * maxLength);
        }
        else
        {
            result = vector;
        }
        return result;
    }

    /// <summary>
    /// Cross Product of two vectors.
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Vector3f Cross(Vector3f lhs, Vector3f rhs)
    {
        return new Vector3f(lhs.y * rhs.z - lhs.z * rhs.y, lhs.z * rhs.x - lhs.x * rhs.z, lhs.x * rhs.y - lhs.y * rhs.x);
    }

    /// <summary>
    /// Returns the distance between <paramref name="point1"/> and <paramref name="point2"/>.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <returns></returns>
    public static float Distance(Vector3f point1, Vector3f point2)
    {
        float num = point1.x - point2.x;
        float num2 = point1.y - point2.y;
        float num3 = point1.z - point2.z;
        return (float)Math.Sqrt((double)(num * num + num2 * num2 + num3 * num3));
    }

    /// <summary>
    /// Dot Product of two vectors.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <returns></returns>
    public static float GetDot(Vector3f point1, Vector3f point2)
    {
        return (point1.x * point2.x) + (point1.y * point2.y) + (point1.z * point2.z);
    }

    /// <summary>
    /// Linearly interpolates between two points, where <paramref name="value"/> will be
    /// clamped between [0, 1].
    /// 
    /// <br/>
    /// <br/>When <paramref name="value"/> = 0 returns <paramref name="point1"/>. 
    /// <br/>When <paramref name="value"/> = 1 return <paramref name="point2"/>. 
    /// <br/>When <paramref name="value"/> = 0.5 returns the midpoint of <paramref name="point1"/> and <paramref name="point2"/>.
    /// </summary>
    /// <param name="point1">Start value, returned when value = 0.</param>
    /// <param name="point2">End value, returned when value = 1.</param>
    /// <param name="value">Value used to interpolate between point1 and other, clamped to the range of [0, 1].</param>
    /// <returns>Interpolated value, equals to <paramref name="point1"/> +
    /// (<paramref name="point2"/> - <paramref name="point1"/>) * <paramref name="value"/>. </returns>
    public static Vector3f Lerp(Vector3f point1, Vector3f point2, float value)
    {
        value = Mathf.Clamp01(value);
        return new Vector3f(point1.x + (point2.x - point1.x) * value, point1.y + (point2.y - point1.y) * value, point1.z + (point2.z - point1.z) * value);
    }

    /// <summary>
    /// Linearly interpolates between two points.
    /// 
    /// <br/>
    /// <br/>When <paramref name="value"/> = 0 returns <paramref name="point1"/>. 
    /// <br/>When <paramref name="value"/> = 1 return <paramref name="point2"/>. 
    /// <br/>When <paramref name="value"/> = 0.5 returns the midpoint of <paramref name="point1"/> and <paramref name="point2"/>.
    /// </summary>
    /// <param name="point1">Start value, returned when value = 0.</param>
    /// <param name="point2">End value, returned when value = 1.</param>
    /// <param name="value">Value used to interpolate between point1 and other.</param>
    /// <returns>Interpolated value, equals to <paramref name="point1"/> +
    /// (<paramref name="point2"/> - <paramref name="point1"/>) * <paramref name="value"/>. </returns>
    public static Vector3f LerpUnclamped(Vector3f point1, Vector3f point2, float value)
    {
        return new Vector3f(point1.x + (point2.x - point1.x) * value, point1.y + (point2.y - point1.y) * value, point1.z + (point2.z - point1.z) * value);
    }

    /// <summary>
    /// Returns a vector that is made from the largest components of two vectors.
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Vector3f GetMax(Vector3f lhs, Vector3f rhs)
    {
        return new Vector3f(Mathf.Max(lhs.x, rhs.x), Mathf.Max(lhs.y, rhs.y), Mathf.Max(lhs.z, rhs.z));
    }

    /// <summary>
    /// Returns a vector that is made from the smallest components of two vectors.
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Vector3f GetMin(Vector3f lhs, Vector3f rhs)
    {
        return new Vector3f(Mathf.Min(lhs.x, rhs.x), Mathf.Min(lhs.y, rhs.y), Mathf.Min(lhs.z, rhs.z));
    }

    /// <summary>
    /// Calculate a position between the points specified by current and target, moving no 
    /// farther than the distance specified by maxDistanceDelta.
    /// </summary>
    /// <param name="current">The position to move from.</param>
    /// <param name="target">The position to move towards.</param>
    /// <param name="maxDistanceDelta">Distance to move <paramref name="current"/> per call.</param>
    /// <returns></returns>
    public static Vector3f MoveTowards(Vector3f current, Vector3f target, float maxDistanceDelta)
    {
        float num = target.x - current.x;
        float num2 = target.y - current.y;
        float num3 = target.z - current.z;
        float num4 = num * num + num2 * num2 + num3 * num3;
        Vector3f result;
        if (num4 == 0f || (maxDistanceDelta >= 0f && num4 <= maxDistanceDelta * maxDistanceDelta))
        {
            result = target;
        }
        else
        {
            float num5 = (float)Math.Sqrt((double)num4);
            result = new Vector3f(current.x + num / num5 * maxDistanceDelta, current.y + num2 / num5 * maxDistanceDelta, current.z + num3 / num5 * maxDistanceDelta);
        }
        return result;
    }

    /// <summary>
    /// Projects a vector onto another vector.
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="onNormal"></param>
    /// <returns></returns>
    public static Vector3f Project(Vector3f vector, Vector3f onNormal)
    {
        float num = Vector3f.GetDot(onNormal, onNormal);
        Vector3f result;
        if (num < Mathf.Epsilon)
        {
            result = Vector3f.Zero;
        }
        else
        {
            float num2 = Vector3f.GetDot(vector, onNormal);
            result = new Vector3f(onNormal.x * num2 / num, onNormal.y * num2 / num, onNormal.z * num2 / num);
        }
        return result;
    }

    /// <summary>
    /// Projects a vector onto a plane defined by a normal orthogonal to the plane.
    /// </summary>
    /// <param name="vector">The location of the vector above the plane.</param>
    /// <param name="planeNormal">The direction from the vector towards the plane.</param>
    /// <returns></returns>
    public static Vector3f ProjectOnPlane(Vector3f vector, Vector3f planeNormal)
    {
        float num = Vector3f.GetDot(planeNormal, planeNormal);
        Vector3f result;
        if (num < Mathf.Epsilon)
        {
            result = vector;
        }
        else
        {
            float num2 = Vector3f.GetDot(vector, planeNormal);
            result = new Vector3f(vector.x - planeNormal.x * num2 / num, vector.y - planeNormal.y * num2 / num, vector.z - planeNormal.z * num2 / num);
        }
        return result;
    }

    /// <summary>
    /// Reflects a vector off the plane defined by a normal.
    /// </summary>
    /// <param name="inDirection"></param>
    /// <param name="inNormal"></param>
    /// <returns></returns>
    public static Vector3f Reflect(Vector3f inDirection, Vector3f inNormal)
    {
        float num = -2f * Vector3f.GetDot(inNormal, inDirection);
        return new Vector3f(num * inNormal.x + inDirection.x, num * inNormal.y + inDirection.y, num * inNormal.z + inDirection.z);
    }

    /// <summary>
    /// Multiplies two vectors component-wise.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Vector3f Scale(Vector3f a, Vector3f b)
    {
        return new Vector3f(a.x * b.x, a.y * b.y, a.z * b.z);
    }

    /// <summary>
    /// Calculates the signed angle between vectors from and to in relation to axis.
    /// </summary>
    /// <param name="from">The vector from which the angular difference is measured.</param>
    /// <param name="to">The vector to which the angular difference is measured.</param>
    /// <param name="axis">A vector around which the other vectors are rotated.</param>
    /// <returns></returns>
    public static float SignedAngle(Vector3f from, Vector3f to, Vector3f axis)
    {
        float num = Vector3f.GetAngle(from, to);
        float num2 = from.y * to.z - from.z * to.y;
        float num3 = from.z * to.x - from.x * to.z;
        float num4 = from.x * to.y - from.y * to.x;
        float num5 = Mathf.Sign(axis.x * num2 + axis.y * num3 + axis.z * num4);
        return num * num5;
    }

    /// <summary>
    /// Gradually changes a vector towards a desired goal over time.
    /// </summary>
    /// <param name="current">The current position.</param>
    /// <param name="target">The position we are trying to reach.</param>
    /// <param name="currentVelocity">The current velocity, this value is modified by the function every time you call it.</param>
    /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
    /// <param name="deltaTime">The time since the last call to this function. By default <see cref="ITime.DeltaTime"/>.</param>
    /// <param name="maxSpeed">Optionally allows you to clamp the maximum speed.</param>
    /// <returns></returns>
    public static Vector3f SmoothDamp(Vector3f current, Vector3f target, ref Vector3f currentVelocity, float smoothTime, float deltaTime, float maxSpeed = Mathf.Infinity)
    {
        smoothTime = Mathf.Max(0.0001f, smoothTime);
        float num = 2f / smoothTime;
        float num2 = num * deltaTime;
        float num3 = 1f / (1f + num2 + 0.48f * num2 * num2 + 0.235f * num2 * num2 * num2);
        float num4 = current.x - target.x;
        float num5 = current.y - target.y;
        float num6 = current.z - target.z;
        Vector3f vector = target;
        float num7 = maxSpeed * smoothTime;
        float num8 = num7 * num7;
        float num9 = num4 * num4 + num5 * num5 + num6 * num6;
        if (num9 > num8)
        {
            float num10 = (float)Math.Sqrt((double)num9);
            num4 = num4 / num10 * num7;
            num5 = num5 / num10 * num7;
            num6 = num6 / num10 * num7;
        }
        target.x = current.x - num4;
        target.y = current.y - num5;
        target.z = current.z - num6;
        float num11 = (currentVelocity.x + num * num4) * deltaTime;
        float num12 = (currentVelocity.y + num * num5) * deltaTime;
        float num13 = (currentVelocity.z + num * num6) * deltaTime;
        currentVelocity.x = (currentVelocity.x - num * num11) * num3;
        currentVelocity.y = (currentVelocity.y - num * num12) * num3;
        currentVelocity.z = (currentVelocity.z - num * num13) * num3;
        float num14 = target.x + (num4 + num11) * num3;
        float num15 = target.y + (num5 + num12) * num3;
        float num16 = target.z + (num6 + num13) * num3;
        float num17 = vector.x - current.x;
        float num18 = vector.y - current.y;
        float num19 = vector.z - current.z;
        float num20 = num14 - vector.x;
        float num21 = num15 - vector.y;
        float num22 = num16 - vector.z;
        if (num17 * num20 + num18 * num21 + num19 * num22 > 0f)
        {
            num14 = vector.x;
            num15 = vector.y;
            num16 = vector.z;
            currentVelocity.x = (num14 - vector.x) / deltaTime;
            currentVelocity.y = (num15 - vector.y) / deltaTime;
            currentVelocity.z = (num16 - vector.z) / deltaTime;
        }
        return new Vector3f(num14, num15, num16);
    }


    #endregion


    #region Operators

    /// <summary>
    /// Returns true if two vectors are approximately equal.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <returns></returns>
    public static bool operator ==(Vector3f point1, Vector3f point2)
    {
        float num = point1.x - point2.x;
        float num2 = point1.y - point2.y;
        float num3 = point1.z - point2.z;
        float num4 = num * num + num2 * num2 + num3 * num3;
        return num4 < 9.99999944E-11f;
    }

    /// <summary>
    /// Returns true if vectors are different.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <returns></returns>
    public static bool operator !=(Vector3 point1, Vector3f point2)
    {
        return !(point1 == point2);
    }

    /// <summary>
    /// Returns true if two vectors are approximately equal.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <returns></returns>
    public static bool operator ==(Vector3 point1, Vector3f point2)
    {
        float num = point1.X - point2.x;
        float num2 = point1.Y - point2.y;
        float num3 = point1.Z - point2.z;
        float num4 = num * num + num2 * num2 + num3 * num3;
        return num4 < 9.99999944E-11f;
    }

    /// <summary>
    /// Returns true if two vectors are approximately equal.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <returns></returns>
    public static bool operator ==(Vector3f point1, Vector3 point2)
    {
        float num = point1.x - point2.X;
        float num2 = point1.y - point2.Y;
        float num3 = point1.z - point2.Z;
        float num4 = num * num + num2 * num2 + num3 * num3;
        return num4 < 9.99999944E-11f;
    }

    /// <summary>
    /// Returns true if vectors are different.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <returns></returns>
    public static bool operator !=(Vector3f point1, Vector3 point2)
    {
        return !(point1 == point2);
    }

    /// <summary>
    /// Returns true if vectors are different.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <returns></returns>
    public static bool operator !=(Vector3f point1, Vector3f point2)
    {
        return !(point1 == point2);
    }


    /// <summary>
    /// Returns a new Vector whose components are the sum of 2 Vectors.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Vector3f operator +(Vector3f a, Vector3f b)
    {
        return new Vector3f(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    /// <summary>
    /// Returns a new Vector whose components are the sum of a Vector and a value.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="value">Value to add to Vector components</param>
    /// <returns></returns>
    public static Vector3f operator +(Vector3f a, float value)
    {
        return new Vector3f(a.x + value, a.y + value, a.z + value);
    }

    /// <summary>
    /// Returns a new Vector whose components are the difference between two Vectors.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Vector3f operator -(Vector3f a, Vector3f b)
    {
        return new Vector3f(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    /// <summary>
    /// Returns a new Vector whose components are the difference between a Vector and a value.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="value">Value to subtract from Vector components.</param>
    /// <returns></returns>
    public static Vector3f operator -(Vector3f a, float value)
    {
        return new Vector3f(a.x - value, a.y - value, a.z - value);
    }

    /// <summary>
    /// Returns a new Vector whose components are the product of two Vectors.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Vector3f operator *(Vector3f a, Vector3f b)
    {
        return new Vector3f(a.x * b.x, a.y * b.y, a.z * b.z);
    }

    /// <summary>
    /// Returns a new Vector whose components are the product of a Vector and a value.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="value">Value to multiply Vector components by.</param>
    /// <returns></returns>
    public static Vector3f operator *(Vector3f a, float value)
    {
        return new Vector3f(a.x * value, a.y * value, a.z * value);
    }

    /// <summary>
    /// Returns a new Vector whose components are the result of one Vector divided by another.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Vector3f operator /(Vector3f a, Vector3f b)
    {
        return new Vector3f(a.x / b.x, a.y / b.y, a.z / b.z);
    }

    /// <summary>
    /// Returns a new Vector whose components are the result of one Vector divided by a value.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="value">Value to divide Vector components by.</param>
    /// <returns></returns>
    public static Vector3f operator /(Vector3f a, float value)
    {
        return new Vector3f(a.x / value, a.y / value, a.z / value);
    }

    #endregion
}
