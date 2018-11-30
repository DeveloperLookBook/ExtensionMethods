using ExtensionMethods;
using NUnit.Framework;
using System;

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
    }
}