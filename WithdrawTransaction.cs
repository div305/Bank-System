using System;
using System.Collections.Generic;
using System.Text;

namespace Abstract_Transaction
{
    class WithdrawTransaction : Transaction
    {
        private Account _account;
        public bool Wsuccess = false;
        public WithdrawTransaction(Account _account, decimal _amount) : base (_amount)
        {
            this._amount = _amount;
            this._account = _account;            
        }
        public override void Print()
        {
            Console.WriteLine("Withdraw of Amount: " + _amount);
            Console.WriteLine("Account: " + _account.getName());
            Console.WriteLine("Current Balance: " + _account.getBalance());
        }
        public override void Execute()
        {
            base.Execute();
            decimal _balanceW = _account.getBalance();
            if (_balanceW < _amount)
            {
                throw new InvalidOperationException("Insufficient Funds in your Account");
            }
            else
            {
                _account.withdraw(_amount);
                base.Success = true;
                base.Executed = true;
            }
        }
        public override void Rollback()
        {
            base.Rollback();
            if (base.Success == true && base.Reversed == false)
            {
                decimal _balanceR = _account.getBalance();
                _account.deposite(_amount);
                Console.WriteLine("ACCOUNT: " + _account.getName());
                Console.WriteLine();
                base.Reversed = true;
            }
        }
    }
}
