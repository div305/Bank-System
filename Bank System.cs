using System;

namespace Abstract_Transaction
{

    enum MenuOption
    {
        Withdraw = 3,
        Deposite = 2,
        Transfer = 4,
        AddAccount = 1,
        Quit = 8,
        Print = 7,
        PrintTransactions = 5,
        Rollback = 6
    }
    class BankSystem
    {
        public static void ReadUserOption(Bank div)
        {
            Console.WriteLine();
            Console.WriteLine("*************************");
            Console.WriteLine("1. " + MenuOption.AddAccount);
            Console.WriteLine("2. " + MenuOption.Deposite);
            Console.WriteLine("3. " + MenuOption.Withdraw);
            Console.WriteLine("4. " + MenuOption.Transfer);
            Console.WriteLine("5. " + MenuOption.PrintTransactions);
            Console.WriteLine("6. " + MenuOption.Rollback);
            Console.WriteLine("7. " + MenuOption.Print);
            Console.WriteLine("8. " + MenuOption.Quit);
            int number;
            do
            {
                Console.WriteLine("Enter number between 1 to 8: ");
                number = Convert.ToInt32(Console.ReadLine());

            } while ((number > (int)MenuOption.Withdraw || number < (int)MenuOption.Withdraw) && (number > (int)MenuOption.Deposite || number < (int)MenuOption.Deposite) && (number > (int)MenuOption.Transfer || number < (int)MenuOption.Transfer) && (number > (int)MenuOption.Quit || number < (int)MenuOption.Quit) && (number > (int)MenuOption.AddAccount || number < (int)MenuOption.AddAccount) && (number > (int)MenuOption.Print || number < (int)MenuOption.Print) && (number > (int)MenuOption.PrintTransactions || number < (int)MenuOption.PrintTransactions) && (number > (int)MenuOption.Rollback || number < (int)MenuOption.Rollback));
            int Choice = Convert.ToInt32(number);
            switch (Choice)
            {
                case 1:
                    doAddAcc(div);
                    break;
                case 2:
                    doDeposite(div);
                    break;
                case 3:
                    doWithdraw(div);
                    break;
                case 4:
                    doTransfer(div);
                    break;
                case 5:
                    PrintTransactions(div);
                    break;
                case 6:
                    DoRollback(div);
                    break;
                case 7:
                    doPrint(div);
                    break;
                case 8:
                    doQuit();
                    break;
            }
        }
        private static Account FindAccount(Bank div)
        {
            Console.WriteLine("Enter the name of the Account");
            string _Findname = Console.ReadLine().ToString();
            Account fAccount = div.GetAccount(_Findname);
            if (fAccount == null)
            {
                Console.WriteLine("Account not found");
            }
            return fAccount;
        }
        public static void doDeposite(Bank div)
        {
            Account dAccount = FindAccount(div);
            if (dAccount == null)
            {
                Console.WriteLine("Can't move ahead");
            }
            else
            {
                Console.WriteLine("How much would you like to Deposite?: ");
                int amount = Convert.ToInt32(Console.ReadLine());
                DepositeTransaction DipositeT = new DepositeTransaction(dAccount, amount);
                div.ExecuteTransation(DipositeT);
            }
            ReadUserOption(div);
        }
        public static void doWithdraw(Bank div)
        {
            Account wAccount = FindAccount(div);
            if (wAccount == null)
            {
                Console.WriteLine("Can't move ahead");
            }
            else
            {
                Console.WriteLine("How much would you like to withdraw?: ");
                int amount = Convert.ToInt32(Console.ReadLine());
                WithdrawTransaction WithdrawT = new WithdrawTransaction(wAccount, amount);
                div.ExecuteTransation(WithdrawT);
            }
            ReadUserOption(div);
        }
        public static void doTransfer(Bank div)
        {
            Console.WriteLine("Provide the name of the account you want to transfer from? ");
            Account tAccount = FindAccount(div);
            Console.WriteLine("Provide the name of the account you want to transfer the amount? ");
            Account tAccount2 = FindAccount(div);
            if (tAccount == null || tAccount2 == null)
            {
                Console.WriteLine("Can't move ahead");
            }
            else
            {
                Console.WriteLine("How much would you like to transfer?: ");
                int amount = Convert.ToInt32(Console.ReadLine());
                TransferTransaction TransferT = new TransferTransaction(tAccount, tAccount2, amount);
                div.ExecuteTransation(TransferT);
            }
            ReadUserOption(div);
        }
        public static void doAddAcc(Bank div)
        {
            
            Console.WriteLine("Enter Name Of account");
            string _accountName = Console.ReadLine().ToString();
            Console.WriteLine("Enter Amount Of account");
            decimal _accountAmount = Convert.ToDecimal(Console.ReadLine());
            Account divAccount = new Account(_accountName, _accountAmount);
            div.AddAccount(divAccount);
            ReadUserOption(div);
        }
        public static void doQuit()
        {
            Console.WriteLine("Good Byee");
        }
        public static void doPrint(Bank div)
        {
            Account dAccount = FindAccount(div);
            Console.WriteLine("NAME: " + dAccount.getName() + "\nBALANCE: " + dAccount.getBalance());
            ReadUserOption(div);
        }
        public static void PrintTransactions(Bank div)
        {            
            div.PrintTransactionHistory();
            ReadUserOption(div);
        }
        public static void DoRollback(Bank div)
        {
            div.PrintTransactionHistory();
            Console.WriteLine("Enter the Transaction number you want to rollback");
            int index = Convert.ToInt32(Console.ReadLine());
            Transaction tTransaction = div.Tranactions[index];
            tTransaction.RPrint();
            ReadUserOption(div);
        }
        static void Main(string[] args)
        {
            try
            {
                Bank div = new Bank();
                BankSystem.ReadUserOption(div);
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.GetType().ToString() + ": " + exception.Message);
            }
        }
    }

}
