using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibraryAdo
{
    public class SBAccount
    {
        public int AccountNumber;
        public String CustomerName;
        public String CustomerAddress;
        public decimal CurrentBalance;


        public SBAccount(int accno, string cname, string cadd, decimal cbal)
        {
            this.AccountNumber = accno;
            this.CustomerName = cname;
            this.CustomerAddress = cadd;
            this.CurrentBalance = cbal;
        }

        public override string ToString()
        {
            return "\nAccount number: " + AccountNumber +
                "\nCustomerName: " + CustomerName +
                "\nCustomerAddress: " + CustomerAddress +
                "\nCurrentBalance: " + CurrentBalance +
                "\n";
        }
    }
}
