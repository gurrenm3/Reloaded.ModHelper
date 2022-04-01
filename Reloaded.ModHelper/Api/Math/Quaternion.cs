/////////
/// Cannot use for the time being. Need to figure out how to see code from
/// internal and "injected" methods like "FromToRotation_Injected"
/////////

/*using System;

namespace Reloaded.ModHelper
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public struct Quaternion : IEquatable<Quaternion>
	{
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public static Quaternion identity
		{
			get => Quaternion.identityQuaternion;
		}

		/// <summary>
		/// 
		/// </summary>
        public float X { get; private set; }

		/// <summary>
		/// 
		/// </summary>
        public float Y { get; private set; }

		/// <summary>
		/// 
		/// </summary>
        public float Z { get; private set; }

		/// <summary>
		/// 
		/// </summary>
        public float W { get; private set; }

		/// <summary>
		/// 
		/// </summary>
        public Quaternion normalized
		{
			get => Quaternion.Normalize(this);
		}

        #endregion

        private static readonly Quaternion identityQuaternion = new Quaternion(0f, 0f, 0f, 1f);
		public const float kEpsilon = 1E-06f;


		public Quaternion(float x, float y, float z, float w)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}

		public static Quaternion FromToRotation(Vector3 fromDirection, Vector3 toDirection)
		{
			Quaternion result;
			Quaternion.FromToRotation_Injected(ref fromDirection, ref toDirection, out result);
			return result;
		}

		public static Quaternion Inverse(Quaternion rotation)
		{
			Quaternion result;
			Quaternion.Inverse_Injected(ref rotation, out result);
			return result;
		}

		public static Quaternion Slerp(Quaternion a, Quaternion b, float t)
		{
			Quaternion result;
			Quaternion.Slerp_Injected(ref a, ref b, t, out result);
			return result;
		}

		public static Quaternion SlerpUnclamped(Quaternion a, Quaternion b, float t)
		{
			Quaternion result;
			Quaternion.SlerpUnclamped_Injected(ref a, ref b, t, out result);
			return result;
		}

		public static Quaternion Lerp(Quaternion a, Quaternion b, float t)
		{
			Quaternion result;
			Quaternion.Lerp_Injected(ref a, ref b, t, out result);
			return result;
		}

		public static Quaternion LerpUnclamped(Quaternion a, Quaternion b, float t)
		{
			Quaternion result;
			Quaternion.LerpUnclamped_Injected(ref a, ref b, t, out result);
			return result;
		}

		private static Quaternion Internal_FromEulerRad(Vector3 euler)
		{
			Quaternion result;
			Quaternion.Internal_FromEulerRad_Injected(ref euler, out result);
			return result;
		}

		private static Vector3 Internal_ToEulerRad(Quaternion rotation)
		{
			Vector3 result;
			Quaternion.Internal_ToEulerRad_Injected(ref rotation, out result);
			return result;
		}

		private static void Internal_ToAxisAngleRad(Quaternion q, out Vector3 axis, out float angle)
		{
			Quaternion.Internal_ToAxisAngleRad_Injected(ref q, out axis, out angle);
		}

		public static Quaternion AngleAxis(float angle, Vector3 axis)
		{
			Quaternion result;
			Quaternion.AngleAxis_Injected(angle, ref axis, out result);
			return result;
		}

		public static Quaternion LookRotation(Vector3 forward, Vector3 upwards)
		{
			Quaternion result;
			Quaternion.LookRotation_Injected(ref forward, ref upwards, out result);
			return result;
		}

		public static Quaternion LookRotation(Vector3 forward)
		{
			return Quaternion.LookRotation(forward, Vector3.Up);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public float this[int index]
		{
			get
			{
				switch (index)
				{
					case 0:
						return this.X;
					case 1:
						return this.Y;
					case 2:
						return this.Z;
					case 3:
						return this.W;
					default:
						throw new IndexOutOfRangeException("Invalid Quaternion index!");
				}
			}
			set
			{
				switch (index)
				{
					case 0:
						this.X = value;
						break;
					case 1:
						this.Y = value;
						break;
					case 2:
						this.Z = value;
						break;
					case 3:
						this.W = value;
						break;
					default:
						throw new IndexOutOfRangeException("Invalid Quaternion index!");
				}
			}
		}

		public void Set(float newX, float newY, float newZ, float newW)
		{
			this.X = newX;
			this.Y = newY;
			this.Z = newZ;
			this.W = newW;
		}

		public void SetLookRotation(Vector3 view)
		{
			Vector3 up = Vector3.Up;
			this.SetLookRotation(view, up);
		}

		public void SetLookRotation(Vector3 view, Vector3 up)
		{
			this = Quaternion.LookRotation(view, up);
		}

		public static Quaternion operator *(Quaternion lhs, Quaternion rhs)
		{
			return new Quaternion(lhs.W * rhs.X + lhs.X * rhs.W + lhs.Y * rhs.Z - lhs.Z * rhs.Y, lhs.W * rhs.Y + lhs.Y * rhs.W + lhs.Z * rhs.X - lhs.X * rhs.Z, lhs.W * rhs.Z + lhs.Z * rhs.W + lhs.X * rhs.Y - lhs.Y * rhs.X, lhs.W * rhs.W - lhs.X * rhs.X - lhs.Y * rhs.Y - lhs.Z * rhs.Z);
		}

		public static Vector3 operator *(Quaternion rotation, Vector3 point)
		{
			float num = rotation.X * 2f;
			float num2 = rotation.Y * 2f;
			float num3 = rotation.Z * 2f;
			float num4 = rotation.X * num;
			float num5 = rotation.Y * num2;
			float num6 = rotation.Z * num3;
			float num7 = rotation.X * num2;
			float num8 = rotation.X * num3;
			float num9 = rotation.Y * num3;
			float num10 = rotation.W * num;
			float num11 = rotation.W * num2;
			float num12 = rotation.W * num3;
			
			float x = (1f - (num5 + num6)) * point.X + (num7 - num12) * point.Y + (num8 + num11) * point.Z;
			float y = (num7 + num12) * point.X + (1f - (num4 + num6)) * point.Y + (num9 - num10) * point.Z;
			float z = (num8 - num11) * point.X + (num9 + num10) * point.Y + (1f - (num4 + num5)) * point.Z;
			return new Vector3(x, y, z);
		}

		private static bool IsEqualUsingDot(float dot)
		{
			return dot > 0.999999f;
		}

		public static bool operator ==(Quaternion lhs, Quaternion rhs)
		{
			return Quaternion.IsEqualUsingDot(Quaternion.Dot(lhs, rhs));
		}

		public static bool operator !=(Quaternion lhs, Quaternion rhs)
		{
			return !(lhs == rhs);
		}

		public static float Dot(Quaternion a, Quaternion b)
		{
			return a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W;
		}

		public static float Angle(Quaternion a, Quaternion b)
		{
			float num = Quaternion.Dot(a, b);
			return (!Quaternion.IsEqualUsingDot(num)) ? (Mathf.Acos(Mathf.Min(Mathf.Abs(num), 1f)) * 2f * 57.29578f) : 0f;
		}

		private static Vector3 Internal_MakePositive(Vector3 euler)
		{
			float num = -0.005729578f;
			float num2 = 360f + num;

			float newX = euler.X;
			float newY = euler.Y;
			float newZ = euler.Z;

			if (euler.X < num)
				newX += 360f;
			else if (euler.X > num2)
				newX -= 360f;

			if (euler.Y < num)
				newY += 360f;
			else if (euler.Y > num2)
				newY -= 360f;

			if (euler.Z < num)
				newZ += 360f;
			else if (euler.Z > num2)
				newZ -= 360f;

			return euler.Set(newX, newY, newZ);
		}

		public Vector3 eulerAngles
		{
			get
			{
				return Quaternion.Internal_MakePositive(Quaternion.Internal_ToEulerRad(this) * 57.29578f);
			}
			set
			{
				this = Quaternion.Internal_FromEulerRad(value * 0.0174532924f);
			}
		}

		public static Quaternion Euler(float x, float y, float z)
		{
			return Quaternion.Internal_FromEulerRad(new Vector3(x, y, z) * 0.0174532924f);
		}

		public static Quaternion Euler(Vector3 euler)
		{
			return Quaternion.Internal_FromEulerRad(euler * 0.0174532924f);
		}

		public void ToAngleAxis(out float angle, out Vector3 axis)
		{
			Quaternion.Internal_ToAxisAngleRad(this, out axis, out angle);
			angle *= 57.29578f;
		}

		public void SetFromToRotation(Vector3 fromDirection, Vector3 toDirection)
		{
			this = Quaternion.FromToRotation(fromDirection, toDirection);
		}

		public static Quaternion RotateTowards(Quaternion from, Quaternion to, float maxDegreesDelta)
		{
			float num = Quaternion.Angle(from, to);
			Quaternion result;
			if (num == 0f)
			{
				result = to;
			}
			else
			{
				result = Quaternion.SlerpUnclamped(from, to, Mathf.Min(1f, maxDegreesDelta / num));
			}
			return result;
		}

		public static Quaternion Normalize(Quaternion q)
		{
			float num = Mathf.Sqrt(Quaternion.Dot(q, q));
			Quaternion result;
			if (num < Mathf.Epsilon)
			{
				result = Quaternion.identity;
			}
			else
			{
				result = new Quaternion(q.X / num, q.Y / num, q.Z / num, q.W / num);
			}
			return result;
		}

		public void Normalize()
		{
			this = Quaternion.Normalize(this);
		}

		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode() << 2 ^ this.Z.GetHashCode() >> 2 ^ this.W.GetHashCode() >> 1;
		}

		public override bool Equals(object other)
		{
			return other is Quaternion && this.Equals((Quaternion)other);
		}

		public bool Equals(Quaternion other)
		{
			return this.X.Equals(other.X) && this.Y.Equals(other.Y) && this.Z.Equals(other.Z) && this.W.Equals(other.W);
		}

		public override string ToString()
		{
			return $"({X}, {Y}, {Z}, {W})";
		}
	}
}
*/