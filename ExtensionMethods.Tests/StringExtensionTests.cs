using ExtensionMethods;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace Tests
{
    public class StringExtensionTests
    {
        #region TEST DATA
        [TestCase(""          , ExpectedResult = false)]
        [TestCase(" "         , ExpectedResult = false)]
        [TestCase("0123456789", ExpectedResult = false)]
        [TestCase("test text" , ExpectedResult = false)]
        [TestCase(null        , ExpectedResult = true )]
        #endregion
        public bool IsNull(string value)
        {
            return value.IsNull();
        }

        #region TEST DATA
        [TestCase(""          , ExpectedResult = true )]
        [TestCase(" "         , ExpectedResult = true )]
        [TestCase("0123456789", ExpectedResult = true )]
        [TestCase("test text" , ExpectedResult = true )]
        [TestCase(null        , ExpectedResult = false)]
        #endregion
        public bool IsNotNull(string value)
        {
            return value.IsNotNull();
        }

        #region TEST DATA
        [TestCase(""  , ExpectedResult = true )]
        [TestCase(" " , ExpectedResult = false)]
        [TestCase("1" , ExpectedResult = false)]
        [TestCase("a" , ExpectedResult = false)]
        [TestCase(null, ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object IsEmpty(string value)
        {
            try
            {
                return value.IsEmpty();
            }
            catch(NullReferenceException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase(""  , ExpectedResult = false)]
        [TestCase(" " , ExpectedResult = true )]
        [TestCase("1" , ExpectedResult = true )]
        [TestCase("a" , ExpectedResult = true )]
        [TestCase(null, ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object IsNotEmpty(string value)
        {
            try
            {
                return value.IsNotEmpty();
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase(""  , ExpectedResult = false)]
        [TestCase(" " , ExpectedResult = true )]
        [TestCase("a" , ExpectedResult = false)]
        [TestCase("1" , ExpectedResult = false)]
        [TestCase("-" , ExpectedResult = false)]
        [TestCase(null, ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object IsWhiteSpace(string value)
        {
            try
            {
                return value.IsWhiteSpace();
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase(""  , ExpectedResult = true )]
        [TestCase(" " , ExpectedResult = false)]
        [TestCase("a" , ExpectedResult = true )]
        [TestCase("1" , ExpectedResult = true )]
        [TestCase("-" , ExpectedResult = true )]
        [TestCase("\n", ExpectedResult = false)]
        [TestCase("\t", ExpectedResult = false)]
        [TestCase(null, ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object IsNotWhiteSpace(string value)
        {
            try
            {
                return value.IsNotWhiteSpace();
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase(""   , 2, ExpectedResult = true )]
        [TestCase(" "  , 2, ExpectedResult = true )]
        [TestCase("a"  , 2, ExpectedResult = true )]
        [TestCase("ab" , 2, ExpectedResult = true )]
        [TestCase("abc", 2, ExpectedResult = false)]
        [TestCase(null , 2, ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object HasLengthLessOrEqual(string value, int limit)
        {
            try
            {
                return value.HasLengthLessOrEqual(limit);
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase(""   , 2, ExpectedResult = false)]
        [TestCase(" "  , 2, ExpectedResult = false)]
        [TestCase("a"  , 2, ExpectedResult = false)]
        [TestCase("ab" , 2, ExpectedResult = true )]
        [TestCase("abc", 2, ExpectedResult = true )]
        [TestCase(null , 2, ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object HasLengthMoreOrEqual(string value, int limit)
        {
            try
            {
                return value.HasLengthMoreOrEqual(limit);
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase(""   , 3, ExpectedResult = true )]
        [TestCase(" "  , 3, ExpectedResult = true )]
        [TestCase("a"  , 3, ExpectedResult = true )]
        [TestCase("ab" , 3, ExpectedResult = true )]
        [TestCase("abc", 3, ExpectedResult = false)]
        [TestCase(null , 3, ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object HasLengthLess(string value, int limit)
        {
            try
            {
                return value.HasLengthLess(limit);
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase(""   , 2, ExpectedResult = false)]
        [TestCase(" "  , 2, ExpectedResult = false)]
        [TestCase("a"  , 2, ExpectedResult = false)]
        [TestCase("ab" , 2, ExpectedResult = false)]
        [TestCase("abc", 2, ExpectedResult = true )]
        [TestCase(null , 2, ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object HasLengthMore(string value, int limit)
        {
            try
            {
                return value.HasLengthMore(limit);
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase(""   , 2, ExpectedResult = false)]
        [TestCase(" "  , 2, ExpectedResult = false)]
        [TestCase("a"  , 2, ExpectedResult = false)]
        [TestCase("ab" , 2, ExpectedResult = true )]
        [TestCase("abc", 2, ExpectedResult = false)]
        [TestCase(null , 2, ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object HasLengthEqual(string value, int limit)
        {
            try
            {
                return value.HasLengthEqual(limit);
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase("a"  , 2, 3, ExpectedResult = false)]
        [TestCase("ab" , 2, 3, ExpectedResult = true )]
        [TestCase("abc", 2, 3, ExpectedResult = true )]
        [TestCase(""   , 2, 3, ExpectedResult = false)]
        [TestCase(null , 2, 3, ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object HasLengthInRange(string value, int min, int max)
        {
            try
            {
                return value.HasLengthInRange(min, max);
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase("abc", "abc", ExpectedResult = true )]
        [TestCase("123", "123", ExpectedResult = true )]
        [TestCase("-.,", "-.,", ExpectedResult = true )]
        [TestCase("abc", "123", ExpectedResult = false)]
        [TestCase("123", "abc", ExpectedResult = false)]
        [TestCase(""   , "abc", ExpectedResult = false)]
        [TestCase(""   , "123", ExpectedResult = false)]
        [TestCase(""   , "-.,", ExpectedResult = false)]
        [TestCase(null , "abc", ExpectedResult = typeof(NullReferenceException))]
        [TestCase(null , null , ExpectedResult = typeof(NullReferenceException))]
        [TestCase(""   , null , ExpectedResult = typeof(ArgumentNullException ))]

        [TestCase("abc", "abc", RegexOptions.Multiline, ExpectedResult = true )]
        [TestCase("123", "123", RegexOptions.Multiline, ExpectedResult = true )]
        [TestCase("-.,", "-.,", RegexOptions.Multiline, ExpectedResult = true )]
        [TestCase("-.,", "-.,", RegexOptions.Multiline, ExpectedResult = true )]
        [TestCase("abc", "123", RegexOptions.Multiline, ExpectedResult = false)]
        [TestCase("123", "abc", RegexOptions.Multiline, ExpectedResult = false)]
        [TestCase(""   , "abc", RegexOptions.Multiline, ExpectedResult = false)]
        [TestCase(""   , "123", RegexOptions.Multiline, ExpectedResult = false)]
        [TestCase(""   , "-.,", RegexOptions.Multiline, ExpectedResult = false)]
        [TestCase(null , "abc", RegexOptions.Multiline, ExpectedResult = typeof(NullReferenceException     ))]
        [TestCase(null , null , RegexOptions.Multiline, ExpectedResult = typeof(NullReferenceException     ))]
        [TestCase(""   , null , RegexOptions.Multiline, ExpectedResult = typeof(ArgumentNullException      ))]
        [TestCase(""   , ""   , 1000                  , ExpectedResult = typeof(ArgumentOutOfRangeException))]
        #endregion
        public object IsMatch(string value, string pattern, RegexOptions options = RegexOptions.Multiline)
        {
            try
            {
                return value.IsMatch(pattern, options);
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
            catch(ArgumentNullException exc)
            {
                return exc.GetType();
            }
            catch(ArgumentOutOfRangeException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase("abc", "abc", ExpectedResult = false)]
        [TestCase("123", "123", ExpectedResult = false)]
        [TestCase("-.,", "-.,", ExpectedResult = false)]
        [TestCase("abc", "123", ExpectedResult = true )]
        [TestCase("123", "abc", ExpectedResult = true )]
        [TestCase(""   , "abc", ExpectedResult = true )]
        [TestCase(""   , "123", ExpectedResult = true )]
        [TestCase(""   , "-.,", ExpectedResult = true )]
        [TestCase(null , "abc", ExpectedResult = typeof(NullReferenceException))]
        [TestCase(null , null , ExpectedResult = typeof(NullReferenceException))]
        [TestCase(""   , null , ExpectedResult = typeof(ArgumentNullException ))]

        [TestCase("abc", "abc", RegexOptions.Multiline, ExpectedResult = false)]
        [TestCase("123", "123", RegexOptions.Multiline, ExpectedResult = false)]
        [TestCase("-.,", "-.,", RegexOptions.Multiline, ExpectedResult = false)]
        [TestCase("-.,", "-.,", RegexOptions.Multiline, ExpectedResult = false)]
        [TestCase("abc", "123", RegexOptions.Multiline, ExpectedResult = true )]
        [TestCase("123", "abc", RegexOptions.Multiline, ExpectedResult = true )]
        [TestCase(""   , "abc", RegexOptions.Multiline, ExpectedResult = true )]
        [TestCase(""   , "123", RegexOptions.Multiline, ExpectedResult = true )]
        [TestCase(""   , "-.,", RegexOptions.Multiline, ExpectedResult = true )]
        [TestCase(null , "abc", RegexOptions.Multiline, ExpectedResult = typeof(NullReferenceException     ))]
        [TestCase(null , null , RegexOptions.Multiline, ExpectedResult = typeof(NullReferenceException     ))]
        [TestCase(""   , null , RegexOptions.Multiline, ExpectedResult = typeof(ArgumentNullException      ))]
        [TestCase(""   , ""   , 1000                  , ExpectedResult = typeof(ArgumentOutOfRangeException))]
        #endregion
        public object IsNotMatch(string value, string pattern, RegexOptions options = RegexOptions.Multiline)
        {
            try
            {
                return value.IsNotMatch(pattern, options);
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
            catch(ArgumentNullException exc)
            {
                return exc.GetType();
            }
            catch(ArgumentOutOfRangeException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase(""     , ExpectedResult = true )]
        [TestCase("abc"  , ExpectedResult = true )]
        [TestCase("a b c", ExpectedResult = true )]
        [TestCase("123"  , ExpectedResult = true )]
        [TestCase("1 2 3", ExpectedResult = true )]
        [TestCase("-.!"  , ExpectedResult = true )]
        [TestCase("- . !", ExpectedResult = true )]
        [TestCase("   "  , ExpectedResult = false)]
        [TestCase(" abc" , ExpectedResult = false)]
        [TestCase(" 123" , ExpectedResult = false)]
        [TestCase(" -.!" , ExpectedResult = false)]
        [TestCase(null   , ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object IsTrimmedLeft(string value)
        {
            try
            {
                return value.IsTrimmedLeft();
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase(""     , ExpectedResult = true )]
        [TestCase("abc"  , ExpectedResult = true )]
        [TestCase("a b c", ExpectedResult = true )]
        [TestCase("123"  , ExpectedResult = true )]
        [TestCase("1 2 3", ExpectedResult = true )]
        [TestCase("-.!"  , ExpectedResult = true )]
        [TestCase("- . !", ExpectedResult = true )]
        [TestCase("   "  , ExpectedResult = false)]
        [TestCase("abc " , ExpectedResult = false)]
        [TestCase("123 " , ExpectedResult = false)]
        [TestCase("-.! " , ExpectedResult = false)]
        [TestCase(null   , ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object IsTrimmedRight(string value)
        {
            try
            {
                return value.IsTrimmedRight();
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase(""     , ExpectedResult = true )]
        [TestCase("abc"  , ExpectedResult = true )]
        [TestCase("a b c", ExpectedResult = true )]
        [TestCase("123"  , ExpectedResult = true )]
        [TestCase("1 2 3", ExpectedResult = true )]
        [TestCase("-.!"  , ExpectedResult = true )]
        [TestCase("- . !", ExpectedResult = true )]
        [TestCase("   "  , ExpectedResult = false)]
        [TestCase("abc " , ExpectedResult = false)]
        [TestCase("123 " , ExpectedResult = false)]
        [TestCase("-.! " , ExpectedResult = false)]
        [TestCase(" abc" , ExpectedResult = false)]
        [TestCase(" 123" , ExpectedResult = false)]
        [TestCase(" -.!" , ExpectedResult = false)]
        [TestCase(" abc ", ExpectedResult = false)]
        [TestCase(" 123 ", ExpectedResult = false)]
        [TestCase(" -.! ", ExpectedResult = false)]
        [TestCase(null   , ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object IsTrimmed(string value)
        {
            try
            {
                return value.IsTrimmed();
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase(""   , ExpectedResult = true )]
        [TestCase("ABC", ExpectedResult = true )]
        [TestCase("123", ExpectedResult = true )]
        [TestCase(",.!", ExpectedResult = true )]
        [TestCase("   ", ExpectedResult = true )]
        [TestCase("A12", ExpectedResult = true )]
        [TestCase("1A2", ExpectedResult = true )]
        [TestCase("12A", ExpectedResult = true )]
        [TestCase("A!!", ExpectedResult = true )]
        [TestCase("!A!", ExpectedResult = true )]
        [TestCase("!!A", ExpectedResult = true )]
        [TestCase("A  ", ExpectedResult = true )]
        [TestCase(" A ", ExpectedResult = true )]
        [TestCase("  A", ExpectedResult = true )]
        [TestCase("abc", ExpectedResult = false)]
        [TestCase("Abc", ExpectedResult = false)]
        [TestCase("aBc", ExpectedResult = false)]
        [TestCase("abC", ExpectedResult = false)]
        [TestCase("a12", ExpectedResult = false)]
        [TestCase("1a2", ExpectedResult = false)]
        [TestCase("12a", ExpectedResult = false)]
        [TestCase("a!!", ExpectedResult = false)]
        [TestCase("!a!", ExpectedResult = false)]
        [TestCase("!!a", ExpectedResult = false)]
        [TestCase("a  ", ExpectedResult = false)]
        [TestCase(" a ", ExpectedResult = false)]
        [TestCase("  a", ExpectedResult = false)]
        [TestCase(null , ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object HasUppercase(string value)
        {
            try
            {
                return value.HasUppercase();
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase(""   , ExpectedResult = true )]
        [TestCase("abc", ExpectedResult = true )]
        [TestCase("123", ExpectedResult = true )]
        [TestCase(",.!", ExpectedResult = true )]
        [TestCase("   ", ExpectedResult = true )]
        [TestCase("a12", ExpectedResult = true )]
        [TestCase("1a2", ExpectedResult = true )]
        [TestCase("12a", ExpectedResult = true )]
        [TestCase("a!!", ExpectedResult = true )]
        [TestCase("!a!", ExpectedResult = true )]
        [TestCase("!!a", ExpectedResult = true )]
        [TestCase("a  ", ExpectedResult = true )]
        [TestCase(" a ", ExpectedResult = true )]
        [TestCase("  a", ExpectedResult = true )]
        [TestCase("ABC", ExpectedResult = false)]
        [TestCase("aBC", ExpectedResult = false)]
        [TestCase("AbC", ExpectedResult = false)]
        [TestCase("ABc", ExpectedResult = false)]
        [TestCase("A12", ExpectedResult = false)]
        [TestCase("1A2", ExpectedResult = false)]
        [TestCase("12A", ExpectedResult = false)]
        [TestCase("A!!", ExpectedResult = false)]
        [TestCase("!A!", ExpectedResult = false)]
        [TestCase("!!A", ExpectedResult = false)]
        [TestCase("A  ", ExpectedResult = false)]
        [TestCase(" A ", ExpectedResult = false)]
        [TestCase("  A", ExpectedResult = false)]
        [TestCase(null , ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object HasLowercase(string value)
        {
            try
            {
                return value.HasLowercase();
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase(""     , ExpectedResult = 0)]
        [TestCase(" "    , ExpectedResult = 0)]
        [TestCase("  "   , ExpectedResult = 0)]
        [TestCase("   "  , ExpectedResult = 0)]
        [TestCase("a"    , ExpectedResult = 1)]
        [TestCase("a b"  , ExpectedResult = 2)]
        [TestCase("a b c", ExpectedResult = 3)]
        [TestCase(null   , ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object WordCount(string value)
        {
            try
            {
                return value.WordCount();
            }
            catch (NullReferenceException)
            {
                return typeof(NullReferenceException);
            }
        }

        #region TEST DATA
        [TestCase("     ", 2, ExpectedResult = true )]
        [TestCase(""     , 2, ExpectedResult = true )]
        [TestCase("a"    , 2, ExpectedResult = true )]
        [TestCase("a b"  , 2, ExpectedResult = false)]
        [TestCase("a b c", 2, ExpectedResult = false)]
        [TestCase(null   , 2, ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object IsWordCountLess(string value, int limit)
        {
            try
            {
                return value.HasWordCountLess(limit);
            }
            catch (NullReferenceException)
            {
                return typeof(NullReferenceException);
            }
        }

        #region TEST DATA
        [TestCase("     ", 2, ExpectedResult = false)]
        [TestCase(""     , 2, ExpectedResult = false)]
        [TestCase("a"    , 2, ExpectedResult = false)]
        [TestCase("a b"  , 2, ExpectedResult = false)]
        [TestCase("a b c", 2, ExpectedResult = true )]
        [TestCase(null   , 2, ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object IsWordCountMore(string value, int limit)
        {
            try
            {
                return value.HasWordCountMore(limit);
            }
            catch (NullReferenceException)
            {
                return typeof(NullReferenceException);
            }
        }


        #region TEST DATA
        [TestCase("     ", 2, ExpectedResult = true )]
        [TestCase(""     , 2, ExpectedResult = true )]
        [TestCase("a"    , 2, ExpectedResult = true )]
        [TestCase("a b"  , 2, ExpectedResult = true )]
        [TestCase("a b c", 2, ExpectedResult = false)]
        [TestCase(null   , 2, ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object IsWordCountLessOrEqual(string value, int limit)
        {
            try
            {
                return value.HasWordCountLessOrEqual(limit);
            }
            catch (NullReferenceException)
            {
                return typeof(NullReferenceException);
            }
        }

        #region TEST DATA
        [TestCase("     ", 2, ExpectedResult = false)]
        [TestCase(""     , 2, ExpectedResult = false)]
        [TestCase("a"    , 2, ExpectedResult = false)]
        [TestCase("a b"  , 2, ExpectedResult = true )]
        [TestCase("a b c", 2, ExpectedResult = true )]
        [TestCase(null   , 2, ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object IsWordCountMoreOrEqual(string value, int limit)
        {
            try
            {
                return value.HasWordCountMoreOrEqual(limit);
            }
            catch (NullReferenceException)
            {
                return typeof(NullReferenceException);
            }
        }

        #region TEST DATA
        [TestCase("     ", 2, ExpectedResult = false)]
        [TestCase(""     , 2, ExpectedResult = false)]
        [TestCase("a"    , 2, ExpectedResult = false)]
        [TestCase("a b"  , 2, ExpectedResult = true )]
        [TestCase("a b c", 2, ExpectedResult = false)]
        [TestCase(null   , 2, ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object IsWordCountEqual(string value, int limit)
        {
            try
            {
                return value.HasWordCountEqual(limit);
            }
            catch (NullReferenceException)
            {
                return typeof(NullReferenceException);
            }
        }
    }
}