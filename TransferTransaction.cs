using System;
using System.Collections.Generic;
using System.Text;

namespace Abstract_Transaction
{
    class TransferTransaction : Transaction
    {
        private Account fromAccount;
        private Account toAccount;
        private DepositeTransaction _deposite;
        private WithdrawTransaction _withdraw;
        public TransferTransaction(Account fromAccount, Account toAccount, decimal _amount) : base(_amount)
        {
            this._amount = _amount;
            this.fromAccount = fromAccount;
            this.toAccount = toAccount;          
            _withdraw = new WithdrawTransaction(fromAccount, _amount);
            _deposite = new DepositeTransaction(toAccount, _amount);
        }
        public override void Print()
        {
            Console.WriteLine("Transferred $" + _amount + " from " + fromAccount.getName() + " Account " + " to " + toAccount.getName() + " account");                                    
        }
        public override void Execute()
        {
            decimal _balance = fromAccount.getBalance();
            decimal _balance2 = toAccount.getBalance();
            base.Execute();
            if (_balance < _amount)
            {
                throw new InvalidOperationException("Insufficient Funds in Account to transfer");
            }
            else
            {
                _withdraw.Execute();
                Console.WriteLine("Balance in " + fromAccount.getName() + " Account: " + fromAccount.getBalance());
                _withdraw.Wsuccess = true;
            }
            if (_withdraw.Wsuccess == true)
            {
                _deposite.Execute();
                Console.WriteLine("Balance in " + toAccount.getName() + " Account: " + toAccount.getBalance());
                _deposite.Dsuccess = true;
                base.Executed = true;
                base.Success = true;
            }
            if (_deposite.Dsuccess == false)
            {
                _withdraw.Rollback();
            }
        }
        public override void Rollback()
        {
            base.Rollback();
            if (base.Reversed == false && Success == true)
            {
                decimal _balance = fromAccount.getBalance();
                decimal _balance2 = toAccount.getBalance();

                if (_balance2 < _amount)
                {
                    throw new InvalidOperationException("Insufficient Funds in Account to transfer");
                }
                _deposite.Rollback();
                _withdraw.Rollback();
                base.Reversed = true;
            }                        
        }
    }
}
