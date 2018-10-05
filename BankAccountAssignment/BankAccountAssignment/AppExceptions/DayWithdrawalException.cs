using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountAssignment
{
    public class DayWithdrawalException : Exception
    {
        public DayWithdrawalException(int MaxAmountPerDay)
        {
            message = string.Format("You can withdraw maximum Rs.{0} per day", MaxAmountPerDay);
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
