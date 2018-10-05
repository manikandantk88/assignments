using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountAssignment
{
    public abstract class Account
    {
        protected Int64 AccountNo { get; private set; }
        protected abstract string Name { get; set; }
        protected abstract int Balance { get; set; }

        public virtual void OpenAccount()
        {
            IsActive();

            if (Balance < AccountHelper.MIN_ACCOUNT_OPEN_BALANCE)
                throw new AccountOpenBalanceException(AccountHelper.MIN_ACCOUNT_OPEN_BALANCE);

            AccountNo = AccountHelper.GetUniqueNo();
        }

        public virtual void RemoveAccount()
        {
            if (Balance != 0)
                throw new AccountCloseBalanceException(Balance);
        }

        public virtual int CloseAccount()
        {
            int balance = Balance;
            Balance = 0;
            isClosed = true;
            return balance;
        }

        public virtual void Deposit(int Amount)
        {
            IsActive();
            Balance = Balance + Amount;
        }

        public abstract void Withdrawal(int Amount);
        public abstract AccountDetails GetAccountDetails();

        protected void CheckBalance(int WithdrwalAmount)
        {
            if (Balance < WithdrwalAmount)
                throw new InSufficentBalanceException(Balance, WithdrwalAmount);
        }

        protected void IsActive()
        {
            if (true == isClosed)
                throw new InvalidOperationException("Account is closed");
        }

        private bool isClosed;
    }
}
