using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountAssignment
{
    public class MinBalanceException : Exception
    {
        public MinBalanceException(int MinimumBalance)
        {
            message = string.Format("Your account balance should be minimum Rs. {0}", MinimumBalance);
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
