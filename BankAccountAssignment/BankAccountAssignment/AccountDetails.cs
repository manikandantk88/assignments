using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountAssignment
{
    public class AccountDetails
    {
        public Int64 AccountNo { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public string TypeOfAccount { get; set; }
        public double RateOfInterest { get; set; }
    }
}
