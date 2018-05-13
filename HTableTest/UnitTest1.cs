using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTable;
using System.Collections.Generic;
namespace HashTableTests
{
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void ThreeElementsTest()
        {
            var table = new HashTable.HashTable(3);

            table.PutPair("один", 1);
            table.PutPair("два", 2);
            table.PutPair("три", 3);

            Assert.AreEqual(table.GetValueByKey("один"), 1);
            Assert.AreEqual(table.GetValueByKey("два"), 2);
            Assert.AreEqual(table.GetValueByKey("три"), 3);
        }

        [TestMethod]
        public void TwoEquialsElementsTest()
        {
            var t = new HashTable.HashTable(3);

            t.PutPair("один", 1);
            t.PutPair("один", 2);

            Assert.AreEqual(t.GetValueByKey("один"), 2);
        }

        [TestMethod]
        public void BigElementsTest()
        {
            var t = new HashTable.HashTable(10000);

            for (int i = 1; i < 10000; i++)
            {
                t.PutPair(i, i + 1);
            }

            Assert.AreEqual(t.GetValueByKey(45), 46);
        }

        [TestMethod]
        public void ElementsSearchTest()
        {
            var ht = new HashTable.HashTable(11000);

            for (int i = 0; i < 10000; i++)
            {
                ht.PutPair(i, i + "Один");
            }

            for (int i = 10000; i < 11000; i++)
            {
                Assert.AreEqual(ht.GetValueByKey(i), null);
            }
        }
    }
}