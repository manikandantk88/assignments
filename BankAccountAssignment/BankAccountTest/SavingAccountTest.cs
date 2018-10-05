using System;
using BankAccountAssignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
    [TestClass]
    public class SavingAccountTest
    {
        [TestMethod]
        public void TestOpenAccount()
        {
            //Arrange
            var sbAcc = new SavingAccount("Mani", 10000);

            //Act
            sbAcc.OpenAccount();
            var accDetails = sbAcc.GetAccountDetails();

            //Assert
            Assert.AreEqual("Mani", accDetails.Name);
            Assert.AreEqual(10000, accDetails.Balance);

        }

        [TestMethod]
        [ExpectedException(typeof(AccountOpenBalanceException))]
        public void TestOpenAccountCheckBalance()
        {
            //Arrange
            var sbAcc = new SavingAccount("Mani", 500);

            //Act
            sbAcc.OpenAccount();
        }

        [TestMethod]
        public void TestDeposit()
        {
            //Arrange
            var sbAcc = new SavingAccount("Mani", 2000);

            //Act
            sbAcc.OpenAccount();
            sbAcc.Deposit(500);
            var accDetails = sbAcc.GetAccountDetails();

            //Assert
            Assert.AreEqual(2500, accDetails.Balance);
        }


        [TestMethod]
        public void TestCloseAccount()
        {
            //Arrange
            var sbAcc = new SavingAccount("Mani", 2000);

            //Act
            sbAcc.OpenAccount();
            sbAcc.Deposit(3000);
            int closedBlance = sbAcc.CloseAccount();
            var accDetails = sbAcc.GetAccountDetails();
            
            //Assert
            Assert.AreEqual(0, accDetails.Balance);
            Assert.AreEqual(5000, closedBlance);
        }

        [TestMethod]
        public void TestRemoveAccountAfterClosingAccount()
        {
            //Arrange
            var sbAcc = new SavingAccount("Mani", 2000);

            //Act
            sbAcc.OpenAccount();
            sbAcc.Deposit(3000);
            int closedBlance = sbAcc.CloseAccount();
            sbAcc.RemoveAccount();

            //Assert
            Assert.AreEqual(5000, closedBlance);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountCloseBalanceException))]
        public void TestRemoveAccountBeforeClosingAccount()
        {
            //Arrange
            var sbAcc = new SavingAccount("Mani", 2000);

            //Act
            sbAcc.OpenAccount();
            sbAcc.Deposit(3000);
            sbAcc.RemoveAccount();
        }

        [TestMethod]
        public void TestWithdrawal()
        {
            //Arrange
            var sbAcc = new SavingAccount("Mani", 2000);

            //Act
            sbAcc.OpenAccount();
            sbAcc.Deposit(3000);
            sbAcc.Withdrawal(1000);
            var accDetails = sbAcc.GetAccountDetails();

            //Assert
            Assert.AreEqual(4000, accDetails.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(InSufficentBalanceException))]
        public void TestWithdrawalInsufficientBalance()
        {
            //Arrange
            var sbAcc = new SavingAccount("Mani", 2000);

            //Act
            sbAcc.OpenAccount();
            sbAcc.Deposit(3000);
            sbAcc.Withdrawal(10000);
        }

        [TestMethod]
        public void TestTransferAmount()
        {
            //Arrange
            var sbAcc = new SavingAccount("Mani", 40000);
            var toAcc = new SavingAccount("Test", 5000);

            //Act
            sbAcc.OpenAccount();
            sbAcc.TransferAmount(toAcc, 1000);

            //Assert
            Assert.AreEqual(39000, sbAcc.GetAccountDetails().Balance);
            Assert.AreEqual(6000, toAcc.GetAccountDetails().Balance);
        }
    }
}
