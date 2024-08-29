using System;

namespace MaxFloatProject
{
    public static class MaxFloatProject
    {
        public static float Max(float a, float b)
        {
            if (float.IsNaN(a))
            {
                return b;
            }

            if (float.IsNaN(b))
            {
                // Bug! Fix: return a;
                return b;
            }

            return Math.Max(a, b);
        }
    }
}