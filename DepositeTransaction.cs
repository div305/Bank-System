using System;
using System.Collections.Generic;
using System.Text;

namespace Abstract_Transaction
{
    class DepositeTransaction : Transaction
    {
        private Account _account;
        public bool Dsuccess = false;
        public DepositeTransaction(Account _account, decimal _amount) : base(_amount)
        {
            this._amount = _amount;
            this._account = _account;
        }
        public override void Print()
        {
            Console.WriteLine("Deposite of Amount: " + _amount);
            Console.WriteLine("Account: " + _account.getName());
            Console.WriteLine("Current Balance: " + _account.getBalance());
        }
        public override void Execute()
        {
            decimal _balanceD = _account.getBalance();
            base.Execute();
            if (_balanceD < 0 || _amount < 0)
            {
                throw new InvalidOperationException("Insufficient Funds in your Account");
            }                    
            else
            {
                _account.deposite(_amount);
                base.Executed = true;
                base.Success = true;
            }
        }
        public override void Rollback()
        {
            base.Rollback();
            if (base.Success == true && base.Reversed == false)
            {
                decimal _balanceR = _account.getBalance();
                _account.withdraw(_amount);
                Console.WriteLine("ACCOUNT: " + _account.getName());
                Console.WriteLine();
                base.Reversed = true;
            }
        }
    }
}
