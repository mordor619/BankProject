using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BankLibraryAdo
{
    interface IBankRepository
    {
        void NewAccount(SBAccount acc);

        SqlDataReader GetAccountDetails(int accno);

        SqlDataReader GetAllAccounts();

        void DepositAmount(int accno, decimal amt);

        void WithdrawAmount(int accno, decimal amt);

        SqlDataReader GetTransactions(int accno);
    }
}
