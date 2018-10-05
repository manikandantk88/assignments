using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountAssignment
{
    public static class AccountHelper
    {
        static AccountHelper()
        {
            BRACH_CODE = 99; //Branch code must have two digits
            MIN_ACCOUNT_OPEN_BALANCE = 1000;
            MIN_BALANCE = 200;
            MAX_WITHDRAWAL_AMOUNT = 20000;
            SAVING_ACCOUNT_ROI = 3.5;
            CURRENT_ACCOUNT_ROI = 4.5;
        }

        public static Int64 GetUniqueNo()
        {
            var no = new StringBuilder();
            bool isUnique = false;
            Int64 result;
            do
            {
                for (int i = 0; i < 4; i++)
                {
                    no.Append(random.Next(101, 999).ToString());
                }
                result = Int64.Parse(no.ToString());
                isUnique = hashTable.Add(result);
            } while (isUnique == false);
            
            return result;
        }

        public static readonly int BRACH_CODE;
        public static readonly int MIN_ACCOUNT_OPEN_BALANCE;
        public static readonly int MIN_BALANCE;
        public static readonly int MAX_WITHDRAWAL_AMOUNT;
        public static readonly double SAVING_ACCOUNT_ROI;
        public static readonly double CURRENT_ACCOUNT_ROI;
        public const string SAVING_ACCOUNT = "Saving Account";
        public const string CURRENT_ACCONT = "Current Account";

        private static Random random = new Random();
        private static HashSet<Int64> hashTable = new HashSet<long>();
    }
}
