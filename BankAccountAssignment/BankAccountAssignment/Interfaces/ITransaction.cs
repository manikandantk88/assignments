using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountAssignment
{
    public interface ITransaction
    {
        void TransferAmount(Account ToAccount, int Amount);
    }
}
