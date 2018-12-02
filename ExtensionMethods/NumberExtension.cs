using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    public static class NumberExtension
    {
        /// <summary>
        /// Checks if number is less than specified value.
        /// </summary>
        /// <param name="limit">Number value.</param>
        /// <returns>Returns True if number is less than specified value.</returns>
        public static bool IsLess       <T>(this T number, T limit) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            return (number.CompareTo(limit) < 0);
        }
        public static bool IsMore       <T>(this T number, T limit) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            return (number.CompareTo(limit) > 0);
        }
        public static bool IsLessOrEqual<T>(this T number, T limit) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            return (number.CompareTo(limit) <= 0);
        }
        public static bool IsMoreOrEqual<T>(this T number, T limit) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            return (number.CompareTo(limit) >= 0);
        }
        public static bool IsEqual      <T>(this T number, T value) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            return (number.CompareTo(value) == 0);
        }
        public static bool IsEqual      <T>(this T number, T value, params T[] values) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
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
        public static bool IsNotEqual   <T>(this T number, T value) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            return !number.IsEqual(value);
        }
        public static bool IsNotEqual   <T>(this T number, T value, params T[] values) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            return !number.IsEqual(value, values);
        }
        public static bool IsInRange    <T>(this T number, T min, T max) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            return (number.IsMoreOrEqual(min) && number.IsLessOrEqual(max));
        }
        public static bool IsNotInRange <T>(this T number, T min, T max) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            return (number.IsLess(min) || number.IsMore(max));
        }
    }
}
