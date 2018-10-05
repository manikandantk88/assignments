using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountAssignment
{
    public class AccountCloseBalanceException : Exception
    {
        public AccountCloseBalanceException(int Balance)
        {
            message = string.Format("You can't close account when you have balance Rs.{0}. Please raise close account request", Balance);
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
