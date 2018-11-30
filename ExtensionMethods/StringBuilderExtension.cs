using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtensionMethods
{
    public static class StringBuilderExtension
    {
        public static bool   IsNull              (this StringBuilder value) => (value is null);
        public static bool   IsNotNull           (this StringBuilder value) => !value.IsNull();
        public static bool   IsEmpty             (this StringBuilder value) => (value.Length == 0);
        public static bool   IsNotEmpty          (this StringBuilder value) => !value.IsNotEmpty();
        public static bool   IsWhiteSpace        (this StringBuilder value) => (Regex.IsMatch(value.ToString(), @"\A\s*\z"));
        public static bool   IsNotWhiteSpace     (this StringBuilder value) => !value.IsWhiteSpace();

        public static bool   HasMaxLength        (this StringBuilder value, int limit) => (value.Length <= limit);
        public static bool   HasMinLength        (this StringBuilder value, int limit) => (value.Length >= limit);
        public static bool   HasLengthLessThan   (this StringBuilder value, int limit) => (value.Length <  limit);
        public static bool   HasLengthMoreThan   (this StringBuilder value, int limit) => (value.Length >  limit);
        public static bool   HasLengthInRange    (this StringBuilder value, int min, int max) => value.HasMinLength(min) && value.HasMaxLength(max);

        public static bool   IsMatch             (this StringBuilder value, string pattern, RegexOptions options)
        {
            if (value.IsNull()  ) throw new ArgumentNullException(nameof(value  ));
            if (pattern.IsNull()) throw new ArgumentNullException(nameof(pattern));

            var input   = value;
            var regex   = new Regex(pattern, options);
            var isMatch = regex.IsMatch(input.ToString());

            return isMatch;
        }
        public static bool   IsMatch             (this StringBuilder value, string pattern) => IsMatch(value, pattern, RegexOptions.Multiline);

        public static bool   TrimedLeft          (this StringBuilder value)
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
        public static bool   TrimedRight         (this StringBuilder value)
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
        public static bool   Trimed              (this StringBuilder value) => (value.TrimedLeft() && value.TrimedRight());
                             
                             
        public static bool   SentenceCased       (this StringBuilder value) => value.IsMatch(@"\A[\p{Lu}].*\z");
                             
                             
        public static bool   HasNoLetters        (this StringBuilder value) => !value.IsMatch(@"\p{L}" );
        public static bool   HasNoMarks          (this StringBuilder value) => !value.IsMatch(@"\p{M}" );
        public static bool   HasNoNumbers        (this StringBuilder value) => !value.IsMatch(@"\p{N}" );
        public static bool   HasNoPunctuation    (this StringBuilder value) => !value.IsMatch(@"\p{P}" );
        public static bool   HasNoSymbols        (this StringBuilder value) => !value.IsMatch(@"\p{S}" );
        public static bool   HasNoSeparators     (this StringBuilder value) => !value.IsMatch(@"\p{Z}" );
        public static bool   HasNoControls       (this StringBuilder value) => !value.IsMatch(@"\p{C}" ); 
        
        public static bool   HasNoLatinCharacters(this StringBuilder value) => value.IsMatch (@"a-zA-Z");     
                             
        
        public static bool   HasLetters          (this StringBuilder value) => value.IsMatch(@"\p{L}" );
        public static bool   HasMarks            (this StringBuilder value) => value.IsMatch(@"\p{M}" );
        public static bool   HasNumbers          (this StringBuilder value) => value.IsMatch(@"\p{N}" );
        public static bool   HasPunctuation      (this StringBuilder value) => value.IsMatch(@"\p{P}" );
        public static bool   HasSymbols          (this StringBuilder value) => value.IsMatch(@"\p{S}" );
        public static bool   HasSeparators       (this StringBuilder value) => value.IsMatch(@"\p{Z}" );
        public static bool   HasControls         (this StringBuilder value) => value.IsMatch(@"\p{C}" );

        public static bool   HasLatinCharacters  (this StringBuilder value) => !HasNoLatinCharacters(value);

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
