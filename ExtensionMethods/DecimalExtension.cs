using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    public static class DecimalExtension
    {
        public static bool IsLess       (this double number, double limit) => (number <  limit);
        public static bool IsMore       (this double number, double limit) => (number >  limit);
        public static bool IsLessOrEqual(this double number, double limit) => (number <= limit);
        public static bool IsMoreOrEqual(this double number, double limit) => (number >= limit);
        public static bool IsEqual      (this double number, double value) => (number == value);
        public static bool IsEqual      (this double number, double value, params int[] values)
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
        public static bool IsNotEqual   (this double number, double value) => !number.IsEqual(value);
        public static bool IsNotEqual   (this double number, double value, params int [] values) => !number.IsEqual(value, values);
        public static bool IsInRange    (this double number, double min, int max) => ((number >= min) && (number <= max));
        public static bool IsNotInRange (this double number, double min, int max) => ((number <  min) || (number >  max));
        public static bool IsEven       (this double number) => (number % 2 == 0);
        public static bool IsOdd        (this double number) => !number.IsEven();
        public static bool IsPositive   (this double number) => (number >= 0);
        public static bool IsNegative   (this double number) => (number <  0);
    }
}
