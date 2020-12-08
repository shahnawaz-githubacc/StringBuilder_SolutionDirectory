using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringBuilder.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void PerformTestCase0()
        {
            int lengthOfInputString = 9;
            int costOfAddingACharacter = 4;
            int costOfCopyAppending = 5;
            int minimumCostExpected = 26;
            string inputString = "aabaacaba";

            StringBuilder stringBuilder = new StringBuilder(lengthOfInputString, costOfAddingACharacter, costOfCopyAppending);
            int minumumCostReturned = stringBuilder.ComputeMinimumCost(inputString);
            Assert.AreEqual(minimumCostExpected, minumumCostReturned);
        }

        [TestMethod]
        public void PerformTestCase1()
        {
            int lengthOfInputString = 9;
            int costOfAddingACharacter = 8;
            int costOfCopyAppending = 9;
            int minimumCostExpected = 42;
            string inputString = "bacbacacb";

            StringBuilder stringBuilder = new StringBuilder(lengthOfInputString, costOfAddingACharacter, costOfCopyAppending);
            int minumumCostReturned = stringBuilder.ComputeMinimumCost(inputString);
            Assert.AreEqual(minimumCostExpected, minumumCostReturned);
        }
    }
}
