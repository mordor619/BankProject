using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoBankLibraryConn;
using System.Data.SqlClient;

namespace BankLibraryAdo
{
    public class BankRepository : IBankRepository
    {

        public static BankConn bankConn = new BankConn();
        public static SqlDataReader dr;


        public void DepositAmount(int accno, decimal amt)
        {
            string msg = bankConn.DepositMoney(accno, amt);

            SBTransaction sbTran = new SBTransaction(DateTime.Now, accno, amt, "Internet Banking");

            string msg1 = bankConn.AddTransaction(sbTran);
            Console.WriteLine("\nTransaction success!");

        }

        public SqlDataReader GetAccountDetails(int accno)
        {

            dr = bankConn.GetParticularData(accno);

            if(!dr.HasRows)
            {
                throw new AccountNumberNotFoundException(accno);
            }
            
            return dr;

            
        }

        public SqlDataReader GetAllAccounts()
        {
            dr = bankConn.GetAllData();

            return dr;
        }

        public SqlDataReader GetTransactions(int accno)
        {
            dr = bankConn.GetParticularTran(accno);

            return dr;
        }

        public void NewAccount(SBAccount acc)
        {

            string msg = bankConn.AddAccount(acc);
            
        }

        public void WithdrawAmount(int accno, decimal amt)
        {

            string msg = bankConn.WithdrawMoney(accno, amt);

            if (msg.Equals("Balance insufficient!"))
            {
                throw new LowBalanceException("\nInsufficient Balance!\n");
            }

            SBTransaction sbTran = new SBTransaction(DateTime.Now, accno, amt, "Internet Banking");

            string msg1 = bankConn.AddTransaction(sbTran);

            
            Console.WriteLine("\nTransaction success!");
            

        }

    }



    public class AccountNumberNotFoundException : Exception
    {
        public AccountNumberNotFoundException()
        {
        }

        public AccountNumberNotFoundException(int accno)
            : base(String.Format("Invalid account number: {0}", accno))
        {
        }

    }

    public class LowBalanceException : Exception
    {
        public LowBalanceException()
        {
        }

        public LowBalanceException(string message)
            : base(message)
        {
        }

    }




}
