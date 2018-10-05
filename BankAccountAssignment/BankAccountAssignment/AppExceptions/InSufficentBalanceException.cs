using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountAssignment
{
    public class InSufficentBalanceException : Exception
    {
        public InSufficentBalanceException(int Balance, int WithdrawalAmount)
        {
            message = string.Format("You are trying to withdraw Rs. {0} against your account balance Rs. {1}", WithdrawalAmount, Balance);
        }
        
        public override string Message
        {
            get
            {
                return message;
            }
        }

        private string message;
    }
}
