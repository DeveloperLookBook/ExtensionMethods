using ExtensionMethods;
using NUnit.Framework;

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
    }
}