using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountAssignment
{
    public class CurrentAccount : Account, IROI, ITransaction
    {
        public CurrentAccount(string Name, int AccOpenBalance)
        {
            name = Name;
            balance = AccOpenBalance;
            minBalanceRequired = AccountHelper.MIN_BALANCE;
            rateOfInterest = AccountHelper.CURRENT_ACCOUNT_ROI;
        }

        public int MinBalanceRequired
        {
            get
            {
                return minBalanceRequired;
            }
        }

        protected override string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        protected override int Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }

        public string TypeOfAccount
        {
            get
            {
                return AccountHelper.CURRENT_ACCONT;
            }
        }

        public override void Withdrawal(int WithdrawalAmount)
        {
            IsActive();
            CheckBalance(WithdrawalAmount);
            var balance = Balance - WithdrawalAmount;
            if (balance < MinBalanceRequired)
                throw new MinBalanceException(MinBalanceRequired);
            Balance = balance;
        }

        public double GetRateOfInterest()
        {
            return rateOfInterest;
        }

        public void TransferAmount(Account ToAccount, int Amount)
        {
            IsActive();
            Withdrawal(Amount);
            ToAccount.Deposit(Amount);
        }

        public override AccountDetails GetAccountDetails()
        {
            return new AccountDetails()
            {
                AccountNo = base.AccountNo,
                Name = this.Name,
                Balance = this.Balance,
                TypeOfAccount = this.TypeOfAccount,
                RateOfInterest = GetRateOfInterest()
            };
        }

        private string name;
        private int balance;
        private readonly int minBalanceRequired;
        private readonly double rateOfInterest;
    }
}
