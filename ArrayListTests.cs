using System;
using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayListlib_Tests
{
    [TestClass]
    public class ArrayList_Tests
    {
        [TestMethod]
        public void AddingItemsOneByOne()
        {
            var list = new ArrayList<int>();

            int itemCount = 1000;

            for (int i = 0; i < itemCount; i++)
            {
                list.Add(i);
            }

            int trueCount = 0;
            int previousItem = int.MinValue;

            foreach (var item in list)
            {
                if (previousItem > item) Assert.Fail();
                previousItem = item;
                trueCount++;
            }

            Assert.IsTrue(list.Count == itemCount
                            && list.Count == trueCount);
        }
        [TestMethod]
        public void AddRange_MultipleElements_ShouldAddToArrayList()
        {
            var list = new ArrayList<int>();
            const int EXPECTED_COUNT = 3;
            list.AddRange(new int[] { 1, 2, 3 });

            Assert.AreEqual(EXPECTED_COUNT, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);

        }
        [TestMethod]
        public void Remove_ExistingElement_ShouldRemoveFromArrayList()
        {
            var list = new ArrayList<int>();
            list.Add(42);
            list.Remove(42);

            Assert.AreEqual(0, list.Count);
            try { var x = list[0]; throw new AssertFailedException(); }
            catch (System.ArgumentOutOfRangeException) { }
        }

        [TestMethod]
        public void Clear_ShouldRemoveAllElements()
        {
            var list = new ArrayList<int>();
            list.AddRange(new int[] { 1, 2, 3 });
            list.Clear();


            Assert.AreEqual(0, list.Count);
            try { var x = list[0]; throw new AssertFailedException(); }
            catch (System.ArgumentOutOfRangeException) { }
        }

        [TestMethod]
        public void Contains_ExistingElement_ShouldReturnTrue()
        {
            var list = new ArrayList<int>();
            list.Add(42);

            Assert.IsTrue(list.Contains(42));
        }
    }
}