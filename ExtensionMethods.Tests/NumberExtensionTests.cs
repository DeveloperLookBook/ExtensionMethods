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

        #region TEST DATA
        [TestCase(1 ,  0, ExpectedResult = true )]
        [TestCase(0 ,  1, ExpectedResult = false)]
        [TestCase(-2, -1, ExpectedResult = false)]
        #endregion
        public bool IsMore(int value, int limit)
        {
            return value.IsMore(limit);
        }

        #region TEST DATA
        [TestCase(1 ,  0, ExpectedResult = false)]
        [TestCase(0 ,  1, ExpectedResult = true)]
        [TestCase(0 ,  0, ExpectedResult = true)]
        [TestCase(-2, -1, ExpectedResult = true)]
        [TestCase(-1, -1, ExpectedResult = true)]
        #endregion
        public bool IsLessOrEqual(int value, int limit)
        {
            return value.IsLessOrEqual(limit);
        }

        #region TEST DATA
        [TestCase(1 ,  0, ExpectedResult = true )]
        [TestCase(0 ,  1, ExpectedResult = false)]
        [TestCase(0 ,  0, ExpectedResult = true )]
        [TestCase(-2, -1, ExpectedResult = false)]
        [TestCase(-1, -1, ExpectedResult = true )]
        #endregion
        public bool IsMoreOrEqual(int value, int limit)
        {
            return value.IsMoreOrEqual(limit);
        }

        #region TEST DATA
        [TestCase( 1,  1, ExpectedResult = true )]
        [TestCase( 0,  0, ExpectedResult = true )]
        [TestCase(-1, -1, ExpectedResult = true )]
        [TestCase(-2, -1, ExpectedResult = false)]
        [TestCase( 2,  1, ExpectedResult = false)]
        #endregion
        public bool IsEqual(int value, int limit)
        {
            return value.IsEqual(limit);
        }

        #region TEST DATA
        [TestCase( 1,  1, new int[] { 2, 3, 5 }, ExpectedResult = true )]
        [TestCase( 2,  1, new int[] { 2, 3, 5 }, ExpectedResult = true )]
        [TestCase( 3,  1, new int[] { 2, 3, 5 }, ExpectedResult = true )]
        [TestCase( 5,  1, new int[] { 2, 3, 5 }, ExpectedResult = true )]
        [TestCase( 0,  0, new int[] { 2, 3, 5 }, ExpectedResult = true )]
        [TestCase(-1, -1, new int[] { 2, 3, 5 }, ExpectedResult = true )]
        [TestCase(-2, -1, new int[] { 2, 3, 5 }, ExpectedResult = false)]
        [TestCase( 6,  1, new int[] { 2, 3, 5 }, ExpectedResult = false)]
        #endregion
        public bool IsEqual(int value, int limit, params int[] values)
        {
            return value.IsEqual(limit, values);
        }
    }
}
