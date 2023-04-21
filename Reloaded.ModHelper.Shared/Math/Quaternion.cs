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
        public float x { get; private set; }

		/// <summary>
		/// 
		/// </summary>
        public float y { get; private set; }

		/// <summary>
		/// 
		/// </summary>
        public float z { get; private set; }

		/// <summary>
		/// 
		/// </summary>
        public float W { get; private set; }

		/// <summary>
		/// 
		/// </summary>
        public Quaternion NewNormalized
		{
			get => Quaternion.NewNormalized(this);
		}

        #endregion

        private static readonly Quaternion identityQuaternion = new Quaternion(0f, 0f, 0f, 1f);
		public const float kEpsilon = 1E-06f;


		public Quaternion(float x, float y, float z, float w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.W = w;
		}

		public static Quaternion FromToRotation(Vector3f fromDirection, Vector3f toDirection)
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

		private static Quaternion Internal_FromEulerRad(Vector3f euler)
		{
			Quaternion result;
			Quaternion.Internal_FromEulerRad_Injected(ref euler, out result);
			return result;
		}

		private static Vector3f Internal_ToEulerRad(Quaternion rotation)
		{
			Vector3f result;
			Quaternion.Internal_ToEulerRad_Injected(ref rotation, out result);
			return result;
		}

		private static void Internal_ToAxisAngleRad(Quaternion q, out Vector3f axis, out float angle)
		{
			Quaternion.Internal_ToAxisAngleRad_Injected(ref q, out axis, out angle);
		}

		public static Quaternion AngleAxis(float angle, Vector3f axis)
		{
			Quaternion result;
			Quaternion.AngleAxis_Injected(angle, ref axis, out result);
			return result;
		}

		public static Quaternion LookRotation(Vector3f forward, Vector3f upwards)
		{
			Quaternion result;
			Quaternion.LookRotation_Injected(ref forward, ref upwards, out result);
			return result;
		}

		public static Quaternion LookRotation(Vector3f forward)
		{
			return Quaternion.LookRotation(forward, Vector3f.Up);
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
						return this.x;
					case 1:
						return this.y;
					case 2:
						return this.z;
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
						this.x = value;
						break;
					case 1:
						this.y = value;
						break;
					case 2:
						this.z = value;
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
			this.x = newX;
			this.y = newY;
			this.z = newZ;
			this.W = newW;
		}

		public void SetLookRotation(Vector3f view)
		{
			Vector3f up = Vector3f.Up;
			this.SetLookRotation(view, up);
		}

		public void SetLookRotation(Vector3f view, Vector3f up)
		{
			this = Quaternion.LookRotation(view, up);
		}

		public static Quaternion operator *(Quaternion lhs, Quaternion rhs)
		{
			return new Quaternion(lhs.W * rhs.x + lhs.x * rhs.W + lhs.y * rhs.z - lhs.z * rhs.y, lhs.W * rhs.y + lhs.y * rhs.W + lhs.z * rhs.x - lhs.x * rhs.z, lhs.W * rhs.z + lhs.z * rhs.W + lhs.x * rhs.y - lhs.y * rhs.x, lhs.W * rhs.W - lhs.x * rhs.x - lhs.y * rhs.y - lhs.z * rhs.z);
		}

		public static Vector3f operator *(Quaternion rotation, Vector3f point)
		{
			float num = rotation.x * 2f;
			float num2 = rotation.y * 2f;
			float num3 = rotation.z * 2f;
			float num4 = rotation.x * num;
			float num5 = rotation.y * num2;
			float num6 = rotation.z * num3;
			float num7 = rotation.x * num2;
			float num8 = rotation.x * num3;
			float num9 = rotation.y * num3;
			float num10 = rotation.W * num;
			float num11 = rotation.W * num2;
			float num12 = rotation.W * num3;
			
			float x = (1f - (num5 + num6)) * point.x + (num7 - num12) * point.y + (num8 + num11) * point.z;
			float y = (num7 + num12) * point.x + (1f - (num4 + num6)) * point.y + (num9 - num10) * point.z;
			float z = (num8 - num11) * point.x + (num9 + num10) * point.y + (1f - (num4 + num5)) * point.z;
			return new Vector3f(x, y, z);
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
			return a.x * b.x + a.y * b.y + a.z * b.z + a.W * b.W;
		}

		public static float Angle(Quaternion a, Quaternion b)
		{
			float num = Quaternion.Dot(a, b);
			return (!Quaternion.IsEqualUsingDot(num)) ? (Mathf.Acos(Mathf.Min(Mathf.Abs(num), 1f)) * 2f * 57.29578f) : 0f;
		}

		private static Vector3f Internal_MakePositive(Vector3f euler)
		{
			float num = -0.005729578f;
			float num2 = 360f + num;

			float newX = euler.x;
			float newY = euler.y;
			float newZ = euler.z;

			if (euler.x < num)
				newX += 360f;
			else if (euler.x > num2)
				newX -= 360f;

			if (euler.y < num)
				newY += 360f;
			else if (euler.y > num2)
				newY -= 360f;

			if (euler.z < num)
				newZ += 360f;
			else if (euler.z > num2)
				newZ -= 360f;

			return euler.Set(newX, newY, newZ);
		}

		public Vector3f eulerAngles
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
			return Quaternion.Internal_FromEulerRad(new Vector3f(x, y, z) * 0.0174532924f);
		}

		public static Quaternion Euler(Vector3f euler)
		{
			return Quaternion.Internal_FromEulerRad(euler * 0.0174532924f);
		}

		public void ToAngleAxis(out float angle, out Vector3f axis)
		{
			Quaternion.Internal_ToAxisAngleRad(this, out axis, out angle);
			angle *= 57.29578f;
		}

		public void SetFromToRotation(Vector3f fromDirection, Vector3f toDirection)
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

		public static Quaternion NewNormalized(Quaternion q)
		{
			float num = Mathf.Sqrt(Quaternion.Dot(q, q));
			Quaternion result;
			if (num < Mathf.Epsilon)
			{
				result = Quaternion.identity;
			}
			else
			{
				result = new Quaternion(q.x / num, q.y / num, q.z / num, q.W / num);
			}
			return result;
		}

		public void NewNormalized()
		{
			this = Quaternion.NewNormalized(this);
		}

		public override int GetHashCode()
		{
			return this.x.GetHashCode() ^ this.y.GetHashCode() << 2 ^ this.z.GetHashCode() >> 2 ^ this.W.GetHashCode() >> 1;
		}

		public override bool Equals(object other)
		{
			return other is Quaternion && this.Equals((Quaternion)other);
		}

		public bool Equals(Quaternion other)
		{
			return this.x.Equals(other.x) && this.y.Equals(other.y) && this.z.Equals(other.z) && this.W.Equals(other.W);
		}

		public override string ToString()
		{
			return $"({x}, {y}, {z}, {W})";
		}
	}
}
*/