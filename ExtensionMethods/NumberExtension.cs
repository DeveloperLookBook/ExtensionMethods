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
        /// <param name="limit">Numeric value.</param>
        /// <returns>Returns True if number is less than specified value.</returns>
        public static bool IsLess       <T>(this T number, T limit) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            return (number.CompareTo(limit) < 0);
        }

        /// <summary>
        /// Checks if number is more than specified value.
        /// </summary>
        /// <param name="limit">Numeric value.</param>
        /// <returns>Returns True if number is more than specified value.</returns>
        public static bool IsMore       <T>(this T number, T limit) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            return (number.CompareTo(limit) > 0);
        }

        /// <summary>
        /// Checks if number is less or equal to specified value.
        /// </summary>
        /// <param name="limit">Numeric value.</param>
        /// <returns>Returns True if number is less or equal to specified value.</returns>
        public static bool IsLessOrEqual<T>(this T number, T limit) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            return (number.CompareTo(limit) <= 0);
        }

        /// <summary>
        /// Checks if number is more or equal to specified value.
        /// </summary>
        /// <param name="limit">Numeric value.</param>
        /// <returns>Returns True if number is more or equal to specified value.</returns>
        public static bool IsMoreOrEqual<T>(this T number, T limit) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            return (number.CompareTo(limit) >= 0);
        }

        /// <summary>
        /// Checks if number is equal to specified value.
        /// </summary>
        /// <param name="limit">Numeric value.</param>
        /// <returns>Returns True if number is equal to specified value.</returns>
        public static bool IsEqual      <T>(this T number, T value) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            return (number.CompareTo(value) == 0);
        }

        /// <summary>
        /// Checks if number is equal to one of the specified values.
        /// </summary>
        /// <param name="limit">Numeric value.</param>
        /// <returns>Returns True if number is equal to one of the specified values.</returns>
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

        /// <summary>
        /// Checks if number is not equal to specified value.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <returns>Returns True if number is not equal to specified values.</returns>
        public static bool IsNotEqual   <T>(this T number, T value) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            return !number.IsEqual(value);
        }

        /// <summary>
        /// Checks if number is not equal to one of the specified values.
        /// </summary>
        /// <param name="limit">Numeric value.</param>
        /// <returns>Returns True if number is not equal to one of the specified values.</returns>
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
