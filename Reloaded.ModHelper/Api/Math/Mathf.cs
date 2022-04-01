using System;

namespace Reloaded.ModHelper
{
	/// <summary>
	/// A collection of common math functions. This is taken straight from Unity.
	/// </summary>
	/// <remarks>Documentation: https://docs.unity3d.com/ScriptReference/Mathf.html </remarks>
	public struct Mathf
    {
		internal struct MathfInternal
		{
			public static volatile float FloatMinNormal = 1.17549435E-38f;
			public static volatile float FloatMinDenormal = float.Epsilon;
			public static bool IsFlushToZeroEnabled = MathfInternal.FloatMinDenormal == 0f;
		}

		/// <summary>
		/// A tiny floating point value (Read Only).
		/// </summary>
		public static readonly float Epsilon = (!MathfInternal.IsFlushToZeroEnabled) ? MathfInternal.FloatMinDenormal : MathfInternal.FloatMinNormal;

		/// <summary>
		/// Degrees-to-radians conversion constant (Read Only).
		/// </summary>
		public const float Deg2Rad = 0.0174532924f;

		/// <summary>
		/// A representation of positive infinity (Read Only).
		/// </summary>
		public const float Infinity = float.PositiveInfinity;

		/// <summary>
		/// A representation of negative infinity (Read Only).
		/// </summary>
		public const float NegativeInfinity = float.NegativeInfinity;

		/// <summary>
		/// The well-known 3.14159265358979... value (Read Only).
		/// </summary>
		public const float PI = 3.14159274f;

		/// <summary>
		/// Radians-to-degrees conversion constant (Read Only).
		/// </summary>
		public const float Rad2Deg = 57.29578f;

		/// <summary>
		/// Returns the absolute value of f.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static float Abs(float f)
		{
			return Math.Abs(f);
		}

		/// <summary>
		/// Returns the absolute value of f.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static int Abs(int value)
		{
			return Math.Abs(value);
		}

		/// <summary>
		/// Returns the arc-cosine of f - the angle in radians whose cosine is f.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static float Acos(float f)
		{
			return (float)Math.Acos((double)f);
		}

		/// <summary>
		/// Compares two floating point values and returns true if they are similar.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static bool Approximately(float a, float b)
		{
			return Mathf.Abs(b - a) < Mathf.Max(1E-06f * Mathf.Max(Mathf.Abs(a), Mathf.Abs(b)), Mathf.Epsilon * 8f);
		}

		/// <summary>
		/// Returns the arc-sine of f - the angle in radians whose sine is f.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static float Asin(float f)
		{
			return (float)Math.Asin((double)f);
		}

		/// <summary>
		/// Returns the arc-tangent of f - the angle in radians whose tangent is f.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static float Atan(float f)
		{
			return (float)Math.Atan((double)f);
		}

		/// <summary>
		/// Returns the angle in radians whose Tan is y/x.
		/// </summary>
		/// <param name="y"></param>
		/// <param name="x"></param>
		/// <returns></returns>
		public static float Atan2(float y, float x)
		{
			return (float)Math.Atan2((double)y, (double)x);
		}

		/// <summary>
		/// Returns the smallest integer greater to or equal to f.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static float Ceil(float f)
		{
			return (float)Math.Ceiling((double)f);
		}

		/// <summary>
		/// Returns the smallest integer greater to or equal to f.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static int CeilToInt(float f)
		{
			return (int)Math.Ceiling((double)f);
		}

		/// <summary>
		/// Clamps the given value between a range defined by the given minimum integer and 
		/// maximum integer values. Returns the given value if it is within min and max.
		/// </summary>
		/// <param name="value">The integer point value to restrict inside the min-to-max range.</param>
		/// <param name="min">The minimum integer point value to compare against.</param>
		/// <param name="max"> 	The maximum integer point value to compare against.</param>
		/// <returns>The int result between min and max values.</returns>
		/// <remarks>Taken from Unity.</remarks>
		public static int Clamp(int value, int min, int max)
        {
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				value = max;
			}
			return value;
		}

		/// <summary>
		/// Clamps the given value between the given minimum float and maximum float values. 
		/// Returns the given value if it is within the min and max range.
		/// </summary>
		/// <param name="value">The floating point value to restrict inside the range defined by the min and max values.</param>
		/// <param name="min">The minimum floating point value to compare against.</param>
		/// <param name="max">The maximum floating point value to compare against.</param>
		/// <returns>The float result between the min and max values.</returns>
		/// <remarks>Taken from Unity.</remarks>
		public static float Clamp(float value, float min, float max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				value = max;
			}
			return value;
		}

		/// <summary>
		/// Clamps value between 0 and 1 and returns value.
		/// <br/><br/>If the value is negative then zero is returned.If value is greater than one then one is returned.
		/// </summary>
		/// <param name="value">The floating point value to clamp.</param>
		/// <returns></returns>
		public static float Clamp01(float value)
		{
			float result;
			if (value < 0f)
			{
				result = 0f;
			}
			else if (value > 1f)
			{
				result = 1f;
			}
			else
			{
				result = value;
			}
			return result;
		}

		/// <summary>
		/// Returns the cosine of angle f.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static float Cos(float f)
		{
			return (float)Math.Cos((double)f);
		}

		/// <summary>
		/// Calculates the shortest difference between two given angles given in degrees.
		/// </summary>
		/// <param name="current"></param>
		/// <param name="target"></param>
		/// <returns></returns>
		public static float DeltaAngle(float current, float target)
		{
			float num = Mathf.Repeat(target - current, 360f);
			if (num > 180f)
			{
				num -= 360f;
			}
			return num;
		}

		/// <summary>
		/// Returns e raised to the specified power.
		/// </summary>
		/// <param name="power"></param>
		/// <returns></returns>
		public static float Exp(float power)
		{
			return (float)Math.Exp((double)power);
		}

		/// <summary>
		/// Returns the largest integer smaller than or equal to f.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static float Floor(float f)
		{
			return (float)Math.Floor((double)f);
		}

		/// <summary>
		/// Returns the largest integer smaller to or equal to f.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static int FloorToInt(float f)
		{
			return (int)Math.Floor((double)f);
		}

		/// <summary>
		/// Calculates the linear parameter t that produces the interpolant value within the range [a, b].
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static float InverseLerp(float a, float b, float value)
		{
			float result;
			if (a != b)
			{
				result = Mathf.Clamp01((value - a) / (b - a));
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		/// <summary>
		/// Linearly interpolates between a and b by t.
		/// </summary>
		/// <param name="a">The start value.</param>
		/// <param name="b">The end value.</param>
		/// <param name="t">The interpolation between the two floats, clamped to the range [0, 1].</param>
		/// <returns></returns>
		public static float Lerp(float a, float b, float t)
		{
			return a + (b - a) * Mathf.Clamp01(t);
		}

		/// <summary>
		/// Same as Lerp but makes sure the values interpolate correctly when they wrap around 360 degrees.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="t"></param>
		/// <returns></returns>
		public static float LerpAngle(float a, float b, float t)
		{
			float num = Mathf.Repeat(b - a, 360f);
			if (num > 180f)
			{
				num -= 360f;
			}
			return a + num * Mathf.Clamp01(t);
		}

		/// <summary>
		/// Linearly interpolates between a and b by t with no limit to t.
		/// </summary>
		/// <param name="a">The start value.</param>
		/// <param name="b">The end value.</param>
		/// <param name="t">The interpolation between the two floats.</param>
		/// <returns>The float value as a result from the linear interpolation.</returns>
		public static float LerpUnclamped(float a, float b, float t)
		{
			return a + (b - a) * t;
		}

		/// <summary>
		/// Returns the logarithm of a specified number in a specified base.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static float Log(float f)
		{
			return (float)Math.Log((double)f);
		}

		/// <summary>
		/// Returns the logarithm of a specified number in a specified base.
		/// </summary>
		/// <param name="f"></param>
		/// <param name="p"></param>
		/// <returns></returns>
		public static float Log(float f, float p)
		{
			return (float)Math.Log((double)f, (double)p);
		}

		/// <summary>
		/// Returns the base 10 logarithm of a specified number.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static float Log10(float f)
		{
			return (float)Math.Log10((double)f);
		}

		/// <summary>
		/// Returns largest of two or more values.
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public static float Max(params float[] values)
		{
			int num = values.Length;
			float result;
			if (num == 0)
			{
				result = 0f;
			}
			else
			{
				float num2 = values[0];
				for (int i = 1; i < num; i++)
				{
					if (values[i] > num2)
					{
						num2 = values[i];
					}
				}
				result = num2;
			}
			return result;
		}

		/// <summary>
		/// Returns largest of two or more values.
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public static int Max(params int[] values)
		{
			int num = values.Length;
			int result;
			if (num == 0)
			{
				result = 0;
			}
			else
			{
				int num2 = values[0];
				for (int i = 1; i < num; i++)
				{
					if (values[i] > num2)
					{
						num2 = values[i];
					}
				}
				result = num2;
			}
			return result;
		}

		/// <summary>
		/// Returns largest of two or more values.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static float Max(float a, float b)
		{
			return (a <= b) ? b : a;
		}

		/// <summary>
		/// Returns largest of two or more values.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static int Max(int a, int b)
		{
			return (a <= b) ? b : a;
		}

		/// <summary>
		/// Returns the smallest of two or more values.
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public static float Min(params float[] values)
		{
			int num = values.Length;
			float result;
			if (num == 0)
			{
				result = 0f;
			}
			else
			{
				float num2 = values[0];
				for (int i = 1; i < num; i++)
				{
					if (values[i] < num2)
					{
						num2 = values[i];
					}
				}
				result = num2;
			}
			return result;
		}

		/// <summary>
		/// Returns the smallest of two or more values.
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public static int Min(params int[] values)
		{
			int num = values.Length;
			int result;
			if (num == 0)
			{
				result = 0;
			}
			else
			{
				int num2 = values[0];
				for (int i = 1; i < num; i++)
				{
					if (values[i] < num2)
					{
						num2 = values[i];
					}
				}
				result = num2;
			}
			return result;
		}

		/// <summary>
		/// Returns the smallest of two or more values.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static float Min(float a, float b)
		{
			return (a >= b) ? b : a;
		}

		/// <summary>
		/// Returns the smallest of two or more values.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static int Min(int a, int b)
		{
			return (a >= b) ? b : a;
		}

		/// <summary>
		/// Moves a value current towards target.
		/// <br/><br/>This is essentially the same as <see cref="Mathf.Lerp(float, float, float)"/>
		/// but instead the function will ensure that the speed never exceeds <paramref name="maxDelta"/>.
		/// Negative values of <paramref name="maxDelta"/> pushes the value away from <paramref name="target"/>
		/// </summary>
		/// <param name="current">The current value.</param>
		/// <param name="target">The value to move towards.</param>
		/// <param name="maxDelta">The maximum change that should be applied to the value.</param>
		/// <returns></returns>
		public static float MoveTowards(float current, float target, float maxDelta)
		{
			float result;
			if (Mathf.Abs(target - current) <= maxDelta)
			{
				result = target;
			}
			else
			{
				result = current + Mathf.Sign(target - current) * maxDelta;
			}
			return result;
		}

		/// <summary>
		/// Same as <see cref="MoveTowards(float, float, float)"/> but makes sure the values interpolate correctly when they wrap around 360 degrees.
		/// </summary>
		/// <param name="current"></param>
		/// <param name="target"></param>
		/// <param name="maxDelta"></param>
		/// <returns></returns>
		public static float MoveTowardsAngle(float current, float target, float maxDelta)
		{
			float num = Mathf.DeltaAngle(current, target);
			float result;
			if (-maxDelta < num && num < maxDelta)
			{
				result = target;
			}
			else
			{
				target = current + num;
				result = Mathf.MoveTowards(current, target, maxDelta);
			}
			return result;
		}

		/// <summary>
		/// PingPong returns a value that will increment and decrement between the value 0 and length.
		/// </summary>
		/// <param name="t"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static float PingPong(float t, float length)
		{
			t = Mathf.Repeat(t, length * 2f);
			return length - Mathf.Abs(t - length);
		}

		/// <summary>
		/// Returns f raised to power p.
		/// </summary>
		/// <param name="f"></param>
		/// <param name="p"></param>
		/// <returns></returns>
		public static float Pow(float f, float p)
		{
			return (float)Math.Pow((double)f, (double)p);
		}

		/// <summary>
		/// Loops the value t, so that it is never larger than length and never smaller than 0.
		/// </summary>
		/// <param name="t"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static float Repeat(float t, float length)
		{
			return Mathf.Clamp(t - Mathf.Floor(t / length) * length, 0f, length);
		}

		/// <summary>
		/// Returns f rounded to the nearest integer.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static float Round(float f)
		{
			return (float)Math.Round((double)f);
		}

		/// <summary>
		/// Returns f rounded to the nearest integer.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static int RoundToInt(float f)
		{
			return (int)Math.Round((double)f);
		}

		/// <summary>
		/// Returns the sign of f.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static float Sign(float f)
		{
			return (f < 0f) ? -1f : 1f;
		}

		/// <summary>
		/// Returns the sine of angle f.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static float Sin(float f)
		{			
			return (float)Math.Sin((double)f);
		}

		/// <summary>
		/// Gradually changes a value towards a desired goal over time.
		/// </summary>
		/// <param name="current">The current position.</param>
		/// <param name="target">The position we are trying to reach.</param>
		/// <param name="currentVelocity">The current velocity, this value is modified by the function every time you call it.</param>
		/// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
		/// <param name="deltaTime">The time since the last call to this function. Recommended to use <see cref="Time.DeltaTime"/>.</param>
		/// <param name="maxSpeed">Optionally allows you to clamp the maximum speed.</param>
		/// <returns></returns>
		public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float deltaTime, float maxSpeed = Mathf.Infinity)
		{
			smoothTime = Mathf.Max(0.0001f, smoothTime);
			float num = 2f / smoothTime;
			float num2 = num * deltaTime;
			float num3 = 1f / (1f + num2 + 0.48f * num2 * num2 + 0.235f * num2 * num2 * num2);
			float num4 = current - target;
			float num5 = target;
			float num6 = maxSpeed * smoothTime;
			num4 = Mathf.Clamp(num4, -num6, num6);
			target = current - num4;
			float num7 = (currentVelocity + num * num4) * deltaTime;
			currentVelocity = (currentVelocity - num * num7) * num3;
			float num8 = target + (num4 + num7) * num3;
			if (num5 - current > 0f == num8 > num5)
			{
				num8 = num5;
				currentVelocity = (num8 - num5) / deltaTime;
			}
			return num8;
		}

		/// <summary>
		/// Gradually changes an angle given in degrees towards a desired goal angle over time.
		/// </summary>
		/// <param name="current">The current position.</param>
		/// <param name="target">The position we are trying to reach</param>
		/// <param name="currentVelocity">The current velocity, this value is modified by the function every time you call it.</param>
		/// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
		/// <param name="deltaTime">The time since the last call to this function. Recommended to use <see cref="Time.DeltaTime"/>.</param>
		/// <param name="maxSpeed">Optionally allows you to clamp the maximum speed.</param>
		/// <returns></returns>
		public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float deltaTime, float maxSpeed = Mathf.Infinity)
		{
			target = current + Mathf.DeltaAngle(current, target);
			return Mathf.SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
		}


		/// <summary>
		/// Interpolates between <paramref name="from"/> and <paramref name="to"/> with smoothing at the limits.
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <param name="t"></param>
		/// <returns></returns>
		public static float SmoothStep(float from, float to, float t)
		{
			t = Mathf.Clamp01(t);
			t = -2f * t * t * t + 3f * t * t;
			return to * t + from * (1f - t);
		}

		/// <summary>
		/// Returns square root of f.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static float Sqrt(float f)
		{
			return (float)Math.Sqrt((double)f);
		}

		/// <summary>
		/// Returns the tangent of angle f in radians.
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		public static float Tan(float f)
		{
			return (float)Math.Tan((double)f);
		}
	}
}
