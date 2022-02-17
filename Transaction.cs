using System;
using System.Collections.Generic;
using System.Text;

namespace Abstract_Transaction
{
    abstract class Transaction
    {
        protected decimal _amount;
        protected bool _success;
        private bool _executed;
        private bool _reversed;
        private DateTime _dateStamp;
        public bool Success { get => this._success; set => this._success = value; }
        public bool Executed { get => this._executed; set => this._executed = value; }
        public bool Reversed { get => this._reversed; set => this._reversed = value; }
        public DateTime DateStamp { get => _dateStamp; }

        public Transaction(decimal _amount)
        {
            this._amount = _amount;
        }
        public virtual void Print()
        {
            Execute();
        }
        public void RPrint()
        {
            Rollback();
        }
        public virtual void Execute()
        {
            if (_executed == true && _success == true)
            {
                throw new InvalidOperationException("Already executed");
            }
            _dateStamp = DateTime.Now;
        }
        public virtual void Rollback()
        {
            if (_reversed == true)
            {
                throw new InvalidOperationException("Already Reversed");
            }
            else if(_success == false)
            {
                throw new InvalidOperationException("Transaction has not been processed");
            }
            _dateStamp = DateTime.Now;
        }
    }
}
