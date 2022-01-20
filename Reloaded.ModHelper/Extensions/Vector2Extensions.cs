using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension Methods for <see cref="Vector2"/>
    /// </summary>
    public static class Vector2Extensions
    {
        /*public static float GetAngle(this Vector2 from, Vector2 to)
        {
			float num = (float)Math.Sqrt((double)(from.sqrMagnitude * to.sqrMagnitude));
			bool flag = num < 1E-15f;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				float num2 = Mathf.Clamp(Vector2.Dot(from, to) / num, -1f, 1f);
				result = (float)Math.Acos((double)num2) * 57.29578f;
			}
			return result;
		}*/
    }
}
