using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    public static class IntExtension
    {
        public static bool IsLess       (this int number, int limit) => (number <  limit);
        public static bool IsMore       (this int number, int limit) => (number >  limit);
        public static bool IsLessOrEqual(this int number, int limit) => (number <= limit);
        public static bool IsMoreOrEqual(this int number, int limit) => (number >= limit);
        public static bool IsEqual      (this int number, int value) => (number == value);
        public static bool IsEqual      (this int number, int value, params int[] values)
        {
            var isEqual = false;

            if (number.IsEqual(value))
            {
                isEqual = true;
            }
            else
            {
                foreach (var v in values)
                {
                    if (number.IsEqual(v))
                    {
                        isEqual = true;
                        break;
                    }
                }
            }

            return isEqual;
        }
        public static bool IsNotEqual   (this int number, int value) => !number.IsEqual(value);
        public static bool IsNotEqual   (this int number, int value, params int [] values) => !number.IsEqual(value, values);
        public static bool IsInRange    (this int number, int min, int max) => ((number >= min) && (number <= max));
        public static bool IsNotInRange (this int number, int min, int max) => ((number <  min) || (number >  max));
        public static bool IsEven       (this int number) => (number % 2 == 0);
        public static bool IsOdd        (this int number) => !number.IsEven();
        public static bool IsPositive   (this int number) => (number >= 0);
        public static bool IsNegative   (this int number) => (number <  0);
    }
}
