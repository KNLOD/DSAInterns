using System;
using System.Linq;
using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DataStructuresTests
{
    [TestClass]
    public class ArrayListTests
    {
        [TestMethod]
        public void ArrayList_InitializesWithDefaultCapacity()
        {
            // Arrange
            int defaultCapacity = 4;

            // Act
            var arrayList = new ArrayList<int>();

            // Assert
            Assert.AreEqual(defaultCapacity, arrayList.Capacity);
        }

        [TestMethod]
        public void ArrayList_InitializesWithSpecifiedCapacity()
        {
            // Arrange
            int capacity = 10;

            // Act
            var arrayList = new ArrayList<int>(capacity);

            // Assert
            Assert.AreEqual(capacity, arrayList.Capacity);
        }

        [TestMethod]
        public void ArrayList_IndexOf_ReturnsIndexOfItem()
        {
            // Arrange
            var arrayList = new ArrayList<int> { 1, 2, 3 };
            int item = 2;

            // Act
            int index = arrayList.IndexOf(item);

            // Assert
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void ArrayList_Add_AddsItemToArray()
        {
            // Arrange
            var arrayList = new ArrayList<int>();
            int item = 5;

            // Act
            arrayList.Add(item);

            // Assert
            Assert.AreEqual(item, arrayList[0]);
            Assert.AreEqual(1, arrayList.Count);
        }

        [TestMethod]
        public void TestIndexOf()
        {
            ArrayList<int> list = new ArrayList<int>();
            list.Add(1);
            list.Add(2);
            Assert.AreEqual(1, list.IndexOf(2));
            Assert.AreEqual(-1, list.IndexOf(3));
        }

    }
}