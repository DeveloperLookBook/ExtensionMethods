﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ExtensionMethods
{
    public static class StringExtension
    {
        private static string EnglishLowercaseLetters   { get; } = "abcdefghijklmnopqrstuvwxyz";
        private static string EnglishUppercaseLetters   { get; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string EnglishLetters            { get; } = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static string UkrainianLowercaseLetters { get; } = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
        private static string UkrainianUppercaseLetters { get; } = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
        private static string UkrainianLetters          { get; } = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюяАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";

        private static string RussianLowercaseLetters   { get; } = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private static string RussianUppercaseLetters   { get; } = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private static string RussianLetters            { get; } = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        /// <summary>
        /// Checks if string is Null. Returns True if string is Null, or False if not
        /// </summary>
        public static bool   IsNull                 (this string value) => (value is null);

        /// <summary>
        /// Checks if string is not Null. Returns True if string is not Null, or False if it 
        /// is Null.
        /// </summary>
        public static bool   IsNotNull              (this string value) => !value.IsNull();

        /// <summary>
        /// Checks if string is Empty. Returns True if string is Empty, or False if it is not.
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   IsEmpty                (this string value)
        {
            if (value.IsNull()) throw new NullReferenceException();

            return (value == String.Empty);
        }

        /// <summary>
        /// Checks if string is not Empty. Returns True if string is not Empty, or False if it 
        /// is Empty.
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   IsNotEmpty             (this string value) => !value.IsEmpty();

        /// <summary>
        /// Checks if string consist from whit-spaces only. Returns True if string consist from 
        /// whit-spaces only, or False if it's not. (Returns false if string is empty.)
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   IsWhiteSpace           (this string value)
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
        public static bool   IsNotWhiteSpace        (this string value) => !value.IsWhiteSpace();

        /// <summary>
        /// Checks if string has length less than or equal to custom max length limit value.
        /// Returns True if length is less or equal to custom max length limit value, or 
        /// False if length is more.
        /// </summary>
        /// <param name="limit">Max length limit value.</param>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   HasLengthLessOrEqual   (this string value, int limit) => (value.Length <= limit);

        /// <summary>
        /// Checks if string has length more then or equal to custom min length limit value.
        /// Returns True if length is more or equal to custom min length limit value, or 
        /// False if length is less.
        /// </summary>
        /// <param name="limit">Min length limit value.</param>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   HasLengthMoreOrEqual   (this string value, int limit) => (value.Length >= limit);

        /// <summary>
        /// Checks if string has length less than custom min length limit value.
        /// Returns True if length is less than custom min length limit value, or 
        /// False if length is more or equal to custom limit value.
        /// </summary>
        /// <param name="limit">Max length limit value.</param>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   HasLengthLess          (this string value, int limit) => (value.Length < limit);

        /// <summary>
        /// Checks if string has length less than custom min length limit value.
        /// Returns True if length is less than custom min length limit value, or 
        /// False if length is more or equal to custom limit value.
        /// </summary>
        /// <param name="limit">Max length limit value.</param>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   HasLengthMore          (this string value, int limit) => (value.Length > limit);

        /// <summary>
        /// Checks if string length is equal to custom value.
        /// </summary>
        /// <param name="number">Custom value.</param>
        /// <returns>Returns True if string length is equal to custom value.</returns>
        public static bool   HasLengthEqual         (this string value, int number)
        {
            if (value.IsNull()) throw new NullReferenceException();

            return (value.Length == number);
        }

        /// <summary>
        /// Checks if string length is in the specified range. Returns True if length 
        /// is in the range, or False, if it is out of the range.
        /// </summary>
        /// <param name="min">Min length limit value.</param>
        /// <param name="max">Max length limit value.</param>
        public static bool   HasLengthInRange       (this string value, int min, int max) => value.HasLengthMoreOrEqual(min) && value.HasLengthLessOrEqual(max);

        /// <summary>
        /// Checks if string matches pattern. Returns True if string matches pattern, 
        /// or False, if it's not.
        /// </summary>
        /// <param name="pattern">Pattern of the regular expression.</param>
        /// <param name="options">Regular expression options.</param>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool   IsMatch                (this string value, string pattern, RegexOptions options = RegexOptions.Multiline)
        {
            if (value.IsNull()  ) throw new NullReferenceException();
            if (pattern.IsNull()) throw new ArgumentNullException (nameof(pattern));

            var input   = value;
            var regex   = new Regex(pattern, options);
            var isMatch = regex.IsMatch(input);

            return isMatch;
        }

        /// <summary>
        /// Checks if string matches pattern. Returns True if string matches pattern, 
        /// or False, if it's not.
        /// </summary>
        /// <param name="pattern">Pattern of the regular expression.</param>
        /// <param name="options">Regular expression options.</param>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool   IsNotMatch             (this string value, string pattern, RegexOptions options = RegexOptions.Multiline)
        {
            if (value.IsNull()  ) throw new NullReferenceException();
            if (pattern.IsNull()) throw new ArgumentNullException (nameof(pattern));
           
            return !value.IsMatch(pattern, options);
        }

        /// <summary>
        /// Checks if string is trimmed from the left side. Returns True if string is trimmed from 
        /// the left side, or False, if it's not.
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   IsTrimmedLeft          (this string value)
        {
            if (value.IsNull()) throw new NullReferenceException();

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

           /// <summary>
        /// Checks if string is trimmed from the right side. Returns True if string is trimmed from 
        /// the right side, or False, if it's not.
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   IsTrimmedRight         (this string value)
        {
            if (value.IsNull()) throw new NullReferenceException();

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

           /// <summary>
        /// Checks if string trimmed from the left and right side. Returns True if string 
        /// is trimmed from both sides, or False if it's not.
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   IsTrimmed              (this string value) => (value.IsTrimmedLeft() && value.IsTrimmedRight());

        /// <summary>
        /// Checks if all letters that are present in the string have uppercase format. 
        /// Returns true if all letters that are present in the string have uppercase 
        /// format, or false if they aren't (Returns True if string is empty).
        /// Example: "ABC, 123!".HasLowercase() will return True.
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   HasUppercase           (this string value)
        {
            if (value.IsNull()) { throw new NullReferenceException(nameof(value)); }

            var input       = value;
            var options     = RegexOptions.Multiline;
            var isUppercase = Regex.IsMatch(input, @"\A[\p{Lu}\p{M}\p{N}\p{P}\p{S}\p{Z}\p{C}]*\z", options);

            return isUppercase;
        }

        /// <summary>
        /// Checks if all letters that are present in the string have lowercase format. 
        /// Returns true if all letters that are present in the string have lowercase 
        /// format, or false if they aren't (Returns True if string is empty).
        /// Example: "abc, 123!".HasLowercase() will return True.
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   HasLowercase           (this string value)
        {
            if (value.IsNull()) { throw new NullReferenceException(nameof(value)); }

            var input       = value;
            var options     = RegexOptions.Multiline;
            var isUppercase = Regex.IsMatch(input, @"\A[\p{Ll}\p{M}\p{N}\p{P}\p{S}\p{Z}\p{C}]*\z", options);

            return isUppercase;
        }

        /// <summary>
        /// Converts the specified string to title case (except for words that are entirely
        /// in uppercase, which are considered to be acronyms).
        /// Example: String "TEST text." will be converted to "TEST Text.".
        /// </summary>
        /// <param name="culture">Culture information that will be used to create 
        /// new string with title-case format.</param>
        /// <returns>The specified string converted to title case.</returns>
        public static string ToTitleCase            (this string value, CultureInfo culture)
        {
            if (value   is null) throw new NullReferenceException(nameof(value  ));
            if (culture is null) throw new ArgumentNullException (nameof(culture));

            return culture.TextInfo.ToTitleCase(value);
        }

        /// <summary>
        /// Checks if the specified string has title case format.
        /// </summary>
        /// <param name="culture">Culture information that will be used to create 
        /// new string with title-case format.</param>
        /// <returns>Returns True if string has title case format.</returns>
        public static bool   HasTitleCase           (this string value, CultureInfo culture)
        {
            if (value   is null) throw new NullReferenceException(nameof(value  ));
            if (culture is null) throw new ArgumentNullException (nameof(culture));

            return (value == value.ToTitleCase(culture));
        }
                                                    
        public static bool   SentenceCased          (this string value) => value.IsMatch(@"\A[\p{Lu}].*\z");              
                                                                                                        
        public static bool   HasLetters             (this string value) => value.IsMatch(@"\p{L}" );
        public static bool   HasMarks               (this string value) => value.IsMatch(@"\p{M}" );
        public static bool   HasNumbers             (this string value) => value.IsMatch(@"\p{N}" );
        public static bool   HasPunctuation         (this string value) => value.IsMatch(@"\p{P}" );
        public static bool   HasSymbols             (this string value) => value.IsMatch(@"\p{S}" );
        public static bool   HasSeparators          (this string value) => value.IsMatch(@"\p{Z}" );
        public static bool   HasControls            (this string value) => value.IsMatch(@"\p{C}" );
                                                    
        public static bool   HasNoLetters           (this string value) => !value.HasLetters    ();
        public static bool   HasNoMarks             (this string value) => !value.HasMarks      ();
        public static bool   HasNoNumbers           (this string value) => !value.HasNumbers    ();
        public static bool   HasNoPunctuation       (this string value) => !value.HasPunctuation();
        public static bool   HasNoSymbols           (this string value) => !value.HasSymbols    ();
        public static bool   HasNoSeparators        (this string value) => !value.HasSeparators ();
        public static bool   HasNoControls          (this string value) => !value.HasControls   ();
        
        /// <summary>
        /// Checks if string contains English letters.
        /// </summary>
        /// <param name="value">String that should be checked.</param>
        /// <returns>Returns, True if string contains English letters, or False if
        /// doesn't.</returns>
        public static bool   HasEnglishLetters      (this string value)
        {
            if (value.IsNull()) throw new NullReferenceException();

            return value.IsMatch($@"[{EnglishLetters}]+");
        }

        /// <summary>
        /// Checks if string contains Ukrainian letters.
        /// </summary>
        /// <param name="value">String that should be checked.</param>
        /// <returns>Returns, True if string contains Ukrainian letters, or False if
        /// doesn't.</returns>
        public static bool   HasUkrainianLetters    (this string value)
        {
            if (value.IsNull()) throw new NullReferenceException();

            return value.IsMatch($@"[{UkrainianLetters}]");
        }

        /// <summary>
        /// Checks if string contains Russian letters.
        /// </summary>
        /// <param name="value">String that should be checked.</param>
        /// <returns>Returns, True if string contains Russian letters, or False if
        /// doesn't.</returns>
        public static bool   HasRussianLetters      (this string value)
        {
            if (value.IsNull()) throw new NullReferenceException();

            return value.IsMatch($@"[{RussianLetters}]+");
        }

        /// <summary>
        /// Checks if string doesn't contain English letters.
        /// </summary>
        /// <param name="value">String that should be checked.</param>
        /// <returns>Returns, True if string doesn't contain English letters, or 
        /// False if it does.</returns>
        public static bool   HasNoEnglishLetters    (this string value)
        {
            if (value.IsNull()) throw new NullReferenceException();

            return !value.HasEnglishLetters();
        }

        /// <summary>
        /// Checks if string doesn't contain Ukrainian letters.
        /// </summary>
        /// <param name="value">String that should be checked.</param>
        /// <returns>Returns, True if string doesn't contain Ukrainian letters, or 
        /// False if it does.</returns>
        public static bool   HasNoUkrainianLetters  (this string value)
        {
            if (value.IsNull()) throw new NullReferenceException();

            return !value.HasUkrainianLetters();
        }

        /// <summary>
        /// Checks if string doesn't contain Russian letters.
        /// </summary>
        /// <param name="value">String that should be checked.</param>
        /// <returns>Returns, True if string doesn't contain Russian letters, or 
        /// False if it does.</returns>
        public static bool   HasNoRussianLetters    (this string value)
        {
            if (value.IsNull()) throw new NullReferenceException();

            return !value.HasRussianLetters();
        }

        /// <summary>
        /// Counts words in the string.
        /// </summary>
        /// <returns>Return number of words in the string.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public static int    WordCount              (this string value)
        {
            if (value.IsNull()) { throw new NullReferenceException(nameof(value)); }

            var input = value;
            var pattern = @"\b\w+\b";
            var options = RegexOptions.Multiline;
            var number  = Regex.Matches(input, pattern, options).Count;

            return number;
        }

        /// <summary>
        /// Checks if word count is less than custom limit value. 
        /// </summary>
        /// <param name="limit">Word count limit.</param>
        /// <returns>Returns True if word count is less custom limit value, 
        /// if it's equal or more, returns False.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   HasWordCountLess       (this string value, int limit)
        {
            if (value.IsNull()) throw new NullReferenceException(nameof(value));

            return (value.WordCount() < limit);
        }

        /// <summary>
        /// Checks if word count is more than custom limit value. 
        /// </summary>
        /// <param name="limit">Word count limit.</param>
        /// <returns>Returns True if word count is more than custom limit value, 
        /// if it's equal or less, returns False.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   HasWordCountMore       (this string value, int limit)
        {
            if (value.IsNull()) throw new NullReferenceException(nameof(value));

            return (value.WordCount() > limit);
        }

        /// <summary>
        /// Checks if word count is less or equal to custom limit value. 
        /// </summary>
        /// <param name="limit">Word count limit.</param>
        /// <returns>Returns True if word count is less or equal to custom limit value, 
        /// if it's more, returns False.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   HasWordCountLessOrEqual(this string value, int limit)
        {
            if (value.IsNull()) throw new NullReferenceException(nameof(value));

            return (value.WordCount() <= limit);
        }

        /// <summary>
        /// Checks if word count is more or equal to custom limit value. 
        /// </summary>
        /// <param name="limit">Word count limit.</param>
        /// <returns>Returns True if word count is more or equal to custom limit value, 
        /// if it's less, returns False.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   HasWordCountMoreOrEqual(this string value, int limit)
        {
            if (value.IsNull()) throw new NullReferenceException(nameof(value));

            return (value.WordCount() >= limit);
        }

        /// <summary>
        /// Checks if word count is equal to custom limit value. 
        /// </summary>
        /// <param name="limit">Word count limit.</param>
        /// <returns>Returns True if word count is equal to custom limit value, 
        /// if it's not, returns False.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public static bool   HasWordCountEqual      (this string value, int limit)
        {
            if (value.IsNull()) throw new NullReferenceException(nameof(value));

            return (value.WordCount() == limit);
        }


        /// <summary>
        /// Escape string.
        /// </summary>
        /// <remarks>
        /// Escape: \, *, +, ?, |, {, }, [, ], (, ), ^, $,., # and white space.
        /// </remarks>
        /// <param name="value">String that should be checked.</param>
        /// <returns>Escaped string.</returns>
        public static string Escape                 (this string value) => Regex.Replace(value, @"[*+?|{}\[\]()^$.#\\]", @"\$&", RegexOptions.Multiline);
    }
}
