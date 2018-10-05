using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountAssignment
{
    public interface IROI
    {
        string TypeOfAccount { get; }
        double GetRateOfInterest();
    }
}
