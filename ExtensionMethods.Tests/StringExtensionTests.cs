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
        [TestCase("a"  , ExpectedResult = true )]
        [TestCase("ab" , ExpectedResult = true )]
        [TestCase("abc", ExpectedResult = false)]
        [TestCase(""   , ExpectedResult = true )]
        [TestCase(null , ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object HasLengthLessOrEqual(string value)
        {
            try
            {
                return value.HasLengthLessOrEqual(2);
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase("a"  , ExpectedResult = false)]
        [TestCase("ab" , ExpectedResult = true )]
        [TestCase("abc", ExpectedResult = true )]
        [TestCase(""   , ExpectedResult = false)]
        [TestCase(null , ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object HasLengthMoreOrEqual(string value)
        {
            try
            {
                return value.HasLengthMoreOrEqual(2);
            }
            catch (NullReferenceException exc)
            {
                return exc.GetType();
            }
        }

        #region TEST DATA
        [TestCase("a"  , ExpectedResult = true )]
        [TestCase("ab" , ExpectedResult = true )]
        [TestCase("abc", ExpectedResult = false)]
        [TestCase(""   , ExpectedResult = true )]
        [TestCase(null , ExpectedResult = typeof(NullReferenceException))]
        #endregion
        public object HasLengthLess(string value)
        {
            try
            {
                return value.HasLengthLess(3);
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
        [TestCase(null , "abc", RegexOptions.Multiline, ExpectedResult = typeof(NullReferenceException))]
        [TestCase(null , null , RegexOptions.Multiline, ExpectedResult = typeof(NullReferenceException))]
        [TestCase(""   , null , RegexOptions.Multiline, ExpectedResult = typeof(ArgumentNullException ))]
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
        }
    }
}