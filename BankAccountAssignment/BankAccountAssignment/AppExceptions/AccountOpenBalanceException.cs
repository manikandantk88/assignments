using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountAssignment
{
    public class AccountOpenBalanceException : Exception
    {
        public AccountOpenBalanceException(int MinimumAmount) 
        {
            message = string.Format("Account opening balance should be minimum Rs.{0}", MinimumAmount);
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
