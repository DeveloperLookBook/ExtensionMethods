using ExtensionMethods;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    class NumberExtensionTests
    {
        #region TEST DATA
        [TestCase(1 ,  0, ExpectedResult = false)]
        [TestCase(0 ,  1, ExpectedResult = true )]
        [TestCase(-2, -1, ExpectedResult = true )]
        #endregion
        public bool IsLess(int value, int limit)
        {
            return value.IsLess(limit);
        }
    }
}
