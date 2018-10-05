using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountAssignment
{
    public class SavingAccount : Account, IROI, ITransaction
    {
        public SavingAccount(string Name, int AccOpenBalance)
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException("Name");

            name = Name;
            balance = AccOpenBalance;
            maxAmountPerDay = AccountHelper.MAX_WITHDRAWAL_AMOUNT;
            rateOfInterest = AccountHelper.SAVING_ACCOUNT_ROI;
        }

        public int MaxAmountPerDay
        {
            get
            {
                return maxAmountPerDay;
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
                return AccountHelper.SAVING_ACCOUNT;
            }
        }

        public override void Withdrawal(int WithdrawalAmount)
        {
            IsActive();
            CheckBalance(WithdrawalAmount);
            if (WithdrawalAmount > MaxAmountPerDay)
                throw new DayWithdrawalException(MaxAmountPerDay);
            Balance = Balance - WithdrawalAmount;
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
        private readonly int maxAmountPerDay;
        private readonly double rateOfInterest;
    }
}
