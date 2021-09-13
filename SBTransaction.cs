using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibraryAdo
{
    public class SBTransaction
    {
        public int TransactionId;
        public DateTime TransactionDate;
        public int AccountNumber;
        public decimal Amount;
        public String TransactionType;


        public SBTransaction(DateTime tdate, int accno, decimal amt, string ttype)
        {
            this.TransactionDate = tdate;
            this.AccountNumber = accno;
            this.Amount = amt;
            this.TransactionType = ttype;
        }

        public override string ToString()
        {
            return "\nTransactionId: " + TransactionId +
                "\nTransactionDate: " + TransactionDate +
                "\nAccountNumber: " + AccountNumber +
                "\nAmount: " + Amount +
                "\nTransactionType: " + TransactionType +
                "\n";
        }
    }
}
