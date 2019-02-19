using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smath = System.Math;

namespace NeuralOwl.Back.CsgoExternal.Math
{
    public struct Vector3
    {
        public float x, y, z;

        #region Init
        public Vector3(float x, float y = 0, float z = 0)
        {
            this.x = x; this.y = y; this.z = z;
        }
        #endregion

        #region Properties
        public float magnitude { get => (float)smath.Sqrt(x*x + y*y + z*z); }
        #endregion

        #region Override
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", x, y, z);
        }
        #endregion

        #region Operators
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        #endregion

        #region Methods
        public static double Distance(Vector3 v1, Vector3 v2) => smath.Sqrt(Math3.FastSqr(v2.x - v1.x) + Math3.FastSqr(v2.y - v1.y) + Math3.FastSqr(v2.z - v1.z));
        #endregion
    }
    public struct Vector2
    {
        public float x, y;

        #region Init
        public Vector2(float x, float y = 0)
        {
            this.x = x; this.y = y;
        }
        #endregion

        #region Properties
        public float magnitude { get => (float)smath.Sqrt(x * x + y * y); }
        #endregion

        #region Override
        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
        #endregion

        #region Operators
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }
        public static Vector2 operator *(float v, Vector2 vec)
        {
            return new Vector2(vec.x * v, vec.y * v);
        }
        public static bool operator ==(Vector2 vec1, Vector2 vec2)
        {
            return vec1.x == vec2.x && vec1.y == vec2.y;
        }
        public static bool operator !=(Vector2 vec1, Vector2 vec2)
        {
            return vec1.x != vec2.x || vec1.y != vec2.y;
        }
        #endregion
    }

    public static class Math3
    {
        public const float RADPI = 57.295779513082f;

        public static float FastSqr(float a) => a * a; 

        public static Vector2 CalcAngle(Vector3 vec1, Vector3 vec2)
        {
            var angles = new Vector2();
            Vector3 delta = new Vector3(vec1.x - vec2.x, vec1.y - vec2.y, vec1.z - vec2.z);
            double hyp = smath.Sqrt(delta.x * delta.x + delta.y * delta.y);

            angles.y = (float)smath.Atan(delta.y / delta.x) * RADPI;
            angles.x = (float)smath.Atan2(delta.z, hyp) * RADPI;

            if (delta.x >= 0)
                angles.y += 180f;
            if (angles.y > 180f)
                angles.y -= 360f;

            return angles;
        }

        public static double AngleBetweenVec2(Vector2 vec1, Vector2 vec2)
        {
            Vector2 delta = vec2 - vec1;
            var angle = smath.Sqrt(FastSqr(delta.x) + FastSqr(delta.y));
            if (angle > 180f)
                angle = 360 - angle;
            return angle;
        }

        public static float Slerp(float angle1, float angle2, float time)
        {
            angle1 += 180f;
            angle2 += 180f;
            float difference = smath.Abs(angle2 - angle1);
            if (difference > 180)
            {
                if (angle2 > angle1)
                    angle1 += 360;
                else
                    angle2 += 360;
            }
            float result = (angle1 + ((angle2 - angle1) * time));
            if (result >= 0 && result <= 360)
                return result - 180f;
            return (result % 360) - 180f;
        }

        public static Vector2 Slerp(Vector2 angle1, Vector2 angle2, float time)
        {
            return new Vector2(Slerp(angle1.x, angle2.x, time), Slerp(angle1.y, angle2.y, time));
        }

        public static Vector3 Slerp(Vector3 angle1, Vector3 angle2, float time)
        {
            return new Vector3(Slerp(angle1.x, angle2.x, time), Slerp(angle1.y, angle2.y, time), Slerp(angle1.z, angle2.z, time));
        }

        public static double GetDistanceFov (float fov, float distance)
        {
            return smath.Sin(fov / 180f * smath.PI) * distance;
        }
    }
}
