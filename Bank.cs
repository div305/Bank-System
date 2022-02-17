using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Abstract_Transaction
{
    class Bank
    {
        private List<Account> accounts;
        private List<Transaction> _transactions;
        public Bank()
        {
            accounts = new List<Account>();
            _transactions = new List<Transaction>();
        }

        public List<Transaction> Tranactions
        {
            get { return _transactions; }
        }
        public void AddAccount(Account account)
        {
            accounts.Add(new Account(account._name, account.balance));
        }
        public Account GetAccount(string name)
        {
            Account gAccount = null;
            foreach (var value in accounts)
            {
                if (value._name == name)
                {
                    gAccount = value;
                }
            }
            return gAccount;
        }
        public void ExecuteTransation(Transaction _transaction)
        {
            _transaction.Execute();
            AddTransaction(_transaction);
        }
        public void RollBackTransation(Transaction transaction)
        {
            transaction.Rollback();
        }
        public void AddTransaction(Transaction _transaction)
        {
            _transactions.Add(_transaction);
        }
        public void PrintTransactionHistory()
        {
            foreach (Transaction _transaction in _transactions)
            {
                int index = _transactions.IndexOf(_transaction);
                Console.WriteLine("Transction Number: "+ index);
                _transaction.Print();
                Console.WriteLine("Transaction Date and Time - " + _transaction.DateStamp);
                Console.WriteLine();
            }
        }
    }
}