﻿using System;
using System.Text.RegularExpressions;

namespace ExtensionMethods
{
    public static class StringExtension
    {
        public static bool   IsNull              (this string value) => (value is null);
        public static bool   IsNotNull           (this string value) => !value.IsNull();
        public static bool   IsEmpty             (this string value) => (value == String.Empty);
        public static bool   IsNotEmpty          (this string value) => !value.IsNotEmpty();
        public static bool   IsWhiteSpace        (this string value) => (Regex.IsMatch(value, @"\A\s*\z"));
        public static bool   IsNotWhiteSpace     (this string value) => !value.IsWhiteSpace();

        public static bool   HasMaxLength        (this string value, int limit) => (value.Length <= limit);
        public static bool   HasMinLength        (this string value, int limit) => (value.Length >= limit);
        public static bool   HasLengthLessThan   (this string value, int limit) => (value.Length <  limit);
        public static bool   HasLengthMoreThan   (this string value, int limit) => (value.Length >  limit);
        public static bool   HasLengthInRange    (this string value, int min, int max) => value.HasMinLength(min) && value.HasMaxLength(max);

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
