using System;
using System.Collections.Generic;
using System.Text;

namespace Abstract_Transaction
{
    class Account
    {
        private decimal _balance;
        private String name;

        public string _name
        {   
            get { return name; }
            set { name = value; }
        }

        public decimal balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public Account(String _name, decimal _balance)
        {
            this._balance = _balance;
            this._name = _name;
        }
        public String getName()
        {
            return this._name;
        }
        public decimal getBalance()
        {
            return this._balance;
        }
        
        public void deposite(decimal amount)
        {
            if (amount > 0)
            {
                this._balance += amount;
                Console.WriteLine("Deposite of Amount: " + amount + "\nCurrent Balance: " + this._balance);

            }
            else
            {
                Console.WriteLine("Deposite of Amount: " + amount);
                Console.WriteLine(amount > 0);
                Console.WriteLine("You cant deposite a Negative Amount");
            }
        }
        public void withdraw(decimal amount)
        {

            if (amount > 0 && this._balance > 0 && amount <= this._balance)
            {
                this._balance -= amount;
                Console.WriteLine("Withdraw of Amount: " + amount + "\nCurrent Balance: " + this._balance);

            }
            else if (amount < 0)
            {
                Console.WriteLine("Withdraw of Amount: " + amount);
                Console.WriteLine(amount > 0);
                Console.WriteLine("You cant withdraw a Negative Amount");
            }
            else if (this._balance == 0)
            {
                Console.WriteLine("Withdraw of Amount: " + amount);
                Console.WriteLine(this._balance > 0);
                Console.WriteLine("Current Balance: " + this._balance);
                Console.WriteLine("You dont have enough Balance");
            }
            else if (amount > 0 && this._balance > 0 && amount > this._balance)
            {
                Console.WriteLine("Withdraw of Amount: " + amount);
                Console.WriteLine(this._balance < 0);
                Console.WriteLine("Current Balance: " + this._balance);
                Console.WriteLine("You dont have enough Balance");
            }
        }
        public void transfer(decimal amount, Account fromAccount, Account toAccount)
        {
            if (amount > 0 && this._balance > 0 && amount <= this._balance)
            {
                decimal _balance = fromAccount.getBalance();
                decimal _balance2 = toAccount.getBalance();
                fromAccount.withdraw(amount);
                Console.WriteLine("Balance in " + fromAccount.getName() + " Account: " + fromAccount.getBalance());
                toAccount.deposite(amount);
                Console.WriteLine("Balance in " + toAccount.getName() + " Account: " + toAccount.getBalance());
            }
        }
        public void print()
        {
            Console.WriteLine("Account Name: " + getName() + "\nCurrent balance: " + getBalance());
            Console.WriteLine();
        }
    }
}
