using System;
using System.Text.RegularExpressions;

namespace ExtensionMethods
{
    public static class StringExtension
    {
        /// <summary>
        /// Checks if string is Null. Returns True if string is Null, or False if not
        /// </summary>
        public static bool   IsNull              (this string value) => (value is null);

        /// <summary>
        /// Checks if string is not Null. Returns True if string is not Null, or False if it 
        /// is Null.
        /// </summary>
        public static bool   IsNotNull           (this string value) => !value.IsNull();

        /// <summary>
        /// Checks if string is Empty. Returns True if string is Empty, or False if it is not.
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   IsEmpty             (this string value)
        {
            if (value.IsNull()) throw new NullReferenceException();

            return (value == String.Empty);
        }

        /// <summary>
        /// Checks if string is not Empty. Returns True if string is not Empty, or False if it 
        /// is Empty.
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   IsNotEmpty          (this string value) => !value.IsEmpty();

        /// <summary>
        /// Checks if string consist from whit-spaces only. Returns True if string consist from 
        /// whit-spaces only, or False if it's not. (Returns false if string is empty.)
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        public static bool IsWhiteSpace(this string value)
        {
            try
            {
                return (Regex.IsMatch(value, @"\A\s+\z"));
            }
            catch (ArgumentNullException)
            {
                // Throw is string value is Null.
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Checks if string doesn't consist from whit-spaces only. Returns True if string 
        /// doesn't consist from  whit-spaces only, or False if it does. 
        /// (Returns true if string is empty.)
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   IsNotWhiteSpace     (this string value) => !value.IsWhiteSpace();

        /// <summary>
        /// Checks if string has length less or equal to custom max length limit value.
        /// Returns True if length is less or equal to custom max length limit value, or 
        /// False if length is more.
        /// </summary>
        /// <param name="limit">Max length limit value.</param>
        /// <exception cref="NullReferenceException"></exception>
        public static bool HasLengthLessOrEqual(this string value, int limit)
        {
            if (value.IsNull()) throw new NullReferenceException();

            return (value.Length <= limit);
        }

        /// <summary>
        /// Checks if string has length more or equal to custom min length limit value.
        /// Returns True if length is more or equal to custom min length limit value, or 
        /// False if length is less.
        /// </summary>
        /// <param name="limit">Min length limit value.</param>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   HasLengthMoreOrEqual(this string value, int limit)
        {
            if (value.IsNull()) throw new NullReferenceException();

            return (value.Length >= limit);
        }

        public static bool   HasLengthLessThan   (this string value, int limit) => (value.Length <  limit);
        public static bool   HasLengthMoreThan   (this string value, int limit) => (value.Length >  limit);
        public static bool   HasLengthInRange    (this string value, int min, int max) => value.HasLengthMoreOrEqual(min) && value.HasLengthLessOrEqual(max);

        public static bool   IsMatch             (this string value, string pattern, RegexOptions options = RegexOptions.Multiline)
        {
            if (value.IsNull()  ) throw new ArgumentNullException(nameof(value  ));
            if (pattern.IsNull()) throw new ArgumentNullException(nameof(pattern));

            var input   = value;
            var regex   = new Regex(pattern, options);
            var isMatch = regex.IsMatch(input);

            return isMatch;
        }

        public static bool   TrimedLeft          (this string value)
        {
            var isTrimmedLeft = false;

            if (value.IsEmpty())
            {
                isTrimmedLeft = true;
            }
            else
            {
                var input = value;
                var patternt = @"\A[\P{Z}].*\z";
                var options = RegexOptions.Multiline;
                var regex = new Regex(patternt, options);

                isTrimmedLeft = regex.IsMatch(input);
            }

            return isTrimmedLeft;
        }                                             
        public static bool   TrimedRight         (this string value)
        {
            var isTrimmedRight = false;

            if (value.IsEmpty())
            {
                isTrimmedRight = true;
            }
            else
            {
                var input    = value;
                var patternt = @"\A.*?[\P{Z}]\z";
                var options  = RegexOptions.Multiline;
                var regex    = new Regex(patternt, options);

                isTrimmedRight = regex.IsMatch(input);
            }

            return isTrimmedRight;
        }
        public static bool   Trimed              (this string value) => (value.TrimedLeft() && value.TrimedRight());
                             
                             
        public static bool   SentenceCased       (this string value) => value.IsMatch(@"\A[\p{Lu}].*\z");                             
                      
        
        public static bool   HasNoLetters        (this string value) => !value.IsMatch(@"\p{L}" );
        public static bool   HasNoMarks          (this string value) => !value.IsMatch(@"\p{M}" );
        public static bool   HasNoNumbers        (this string value) => !value.IsMatch(@"\p{N}" );
        public static bool   HasNoPunctuation    (this string value) => !value.IsMatch(@"\p{P}" );
        public static bool   HasNoSymbols        (this string value) => !value.IsMatch(@"\p{S}" );
        public static bool   HasNoSeparators     (this string value) => !value.IsMatch(@"\p{Z}" );
        public static bool   HasNoControls       (this string value) => !value.IsMatch(@"\p{C}" ); 
        
        public static bool   HasNoLatinCharacters(this string value) => value.IsMatch (@"a-zA-Z");     
                             
                             
        public static bool   HasLetters          (this string value) => value.IsMatch(@"\p{L}" );
        public static bool   HasMarks            (this string value) => value.IsMatch(@"\p{M}" );
        public static bool   HasNumbers          (this string value) => value.IsMatch(@"\p{N}" );
        public static bool   HasPunctuation      (this string value) => value.IsMatch(@"\p{P}" );
        public static bool   HasSymbols          (this string value) => value.IsMatch(@"\p{S}" );
        public static bool   HasSeparators       (this string value) => value.IsMatch(@"\p{Z}" );
        public static bool   HasControls         (this string value) => value.IsMatch(@"\p{C}" );

        public static bool   HasLatinCharacters  (this string value) => !HasNoLatinCharacters(value);

        /// <summary>
        /// Escape string.
        /// </summary>
        /// <remarks>
        /// Escape: \, *, +, ?, |, {, }, [, ], (, ), ^, $,., # and white space.
        /// </remarks>
        /// <param name="value">String that should be checked.</param>
        /// <returns>Escaped string.</returns>
        public static string Escape              (this string value) => Regex.Replace(value, @"[*+?|{}\[\]()^$.#\\]", @"\$&", RegexOptions.Multiline);
    }
}
