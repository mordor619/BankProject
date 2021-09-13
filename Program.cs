using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BankLibraryAdo
{
    class Program
    {

        static void Main(string[] args)
        {

            BankRepository rep = new BankRepository();

            DisplayScreen();

            int choice = Convert.ToInt32(Console.ReadLine());

            while (choice != 7)
            {

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Creating new Account...\n");

                        Console.WriteLine("Enter details: \n");

                        int accno = Convert.ToInt32(Console.ReadLine());

                        string cname = Console.ReadLine();

                        string cadd = Console.ReadLine();

                        decimal cbal = Convert.ToDecimal(Console.ReadLine());

                        SBAccount acc = new SBAccount(accno, cname, cadd, cbal);

                        rep.NewAccount(acc);

                        Console.WriteLine("\nSuccess!\n");

                        break;

                    case 2:
                        Console.WriteLine("Fetching details...");

                        Console.WriteLine("Enter account number: \n");

                        int accnoSearch = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            SqlDataReader dr = rep.GetAccountDetails(accnoSearch);
                            Console.WriteLine("\n");

                           
                            
                                while (dr.Read()) //looping number of Rows
                                {
                                    for (int i = 0; i < dr.FieldCount; i++) //number of columns
                                    {
                                        Console.Write(dr[i] + "     ");
                                    }

                                }
                            Console.WriteLine("\n");
                            

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }



                        break;

                    case 3:
                        Console.WriteLine("Fetching all accounts...");

                        SqlDataReader dr1 = rep.GetAllAccounts();

                        Console.WriteLine("\n");

                        while (dr1.Read()) //looping number of Rows
                        {
                            for (int i = 0; i < dr1.FieldCount; i++) //number of columns
                            {
                                Console.Write(dr1[i] + "     ");
                            }
                            Console.WriteLine("\n");

                        }
                        

                        break;

                    case 4:
                        Console.WriteLine("Depositing amount...");

                        Console.WriteLine("\nEnter account number: ");

                        int accDep = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nEnter amount: ");

                        int accDepAmt = Convert.ToInt32(Console.ReadLine());

                        rep.DepositAmount(accDep, accDepAmt);

                       

                        break;

                    case 5:
                        Console.WriteLine("Withdrawing amount...");

                        Console.WriteLine("\nEnter account number: ");

                        int accWit = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nEnter amount: ");

                        int accWitAmt = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            rep.WithdrawAmount(accWit, accWitAmt);
                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }



                        break;

                    case 6:
                        Console.WriteLine("Getting transactions...");

                        Console.WriteLine("Enter account number: ");

                        int acctran = Convert.ToInt32(Console.ReadLine());

                        SqlDataReader dr2 = rep.GetTransactions(acctran);

                        Console.WriteLine("\n");

                        if (!dr2.HasRows)
                        {
                            Console.WriteLine("No transactions found!\n");
                        }


                        while (dr2.Read()) //looping number of Rows
                        {
                            for (int i = 0; i < dr2.FieldCount; i++) //number of columns
                            {
                                Console.Write(dr2[i] + "     ");
                            }
                            Console.WriteLine("\n");

                        }



                        break;

                    case 7:
                        break;

                    default:
                        Console.WriteLine("Enter valid choice!\n");
                        break;
                }

                DisplayScreen();

                choice = Convert.ToInt32(Console.ReadLine());


            }


        }

        private static void DisplayScreen()
        {
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("\nWelcome to our bank!\n\n");

            Console.WriteLine("Select an option: \n");

            Console.WriteLine("1. Create new account\n");

            Console.WriteLine("2. Get account details\n");

            Console.WriteLine("3. Get all accounts\n");

            Console.WriteLine("4. Deposit amount\n");

            Console.WriteLine("5. Withdraw amount\n");

            Console.WriteLine("6. Get all transactions for your account\n");

            Console.WriteLine("7. Exit\n");


        }
    }
}
