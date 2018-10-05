using System;
using BankAccountAssignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
    [TestClass]
    public class CurrentAccountTest
    {
        [TestMethod]
        public void TestWithdrawal()
        {
            //Arrange
            var curAcc = new CurrentAccount("Mani", 5000);
            curAcc.OpenAccount();

            //Act
            curAcc.Withdrawal(1000);

            Assert.AreEqual(4000, curAcc.GetAccountDetails().Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(MinBalanceException))]
        public void TestWithdrawalMinBalance()
        {
            //Arrange
            var curAcc = new CurrentAccount("Mani", 5000);
            curAcc.OpenAccount();

            //Act
            curAcc.Withdrawal(5000);
        }

        [TestMethod]
        public void TestTransferAmount()
        {
            //Arrange
            var sbAcc = new SavingAccount("Vijay", 10000);
            var curAcc = new CurrentAccount("Mani", 5000);
            sbAcc.OpenAccount();
            curAcc.OpenAccount();

            //Act
            curAcc.TransferAmount(sbAcc, 2000);

            //Assert
            //Assert
            Assert.AreEqual(12000, sbAcc.GetAccountDetails().Balance);
            Assert.AreEqual(3000, curAcc.GetAccountDetails().Balance);
        }
    }
}
