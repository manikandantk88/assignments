using System;
using System.Collections.Generic;
using BankAccountAssignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
    [TestClass]
    public class UniqueAccNoTest
    {
        [TestMethod]
        public void TestUniqueAccountNo()
        {
            //Arrange
            HashSet<Int64> accoutNoHashTable = new HashSet<Int64>();
            List<Int64> duplicates = new List<long>();

            //Act
            for (int i = 0; i < 1000000; i++)
            {
                var accNo = AccountHelper.GetUniqueNo();
                var result = accoutNoHashTable.Add(accNo);
                if (false == result)
                    duplicates.Add(accNo);
            }

            //Assert
            Assert.AreEqual(0, duplicates.Count, "Duplicates are there");
        }
    }
}
