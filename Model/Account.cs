using System;

namespace DIO.Bank
{
    public class Account
    {
        private TypeAccount typeAccount { get; set; }        
        public double balance { get; set; }
        public double credit { get; set; }
        private string name { get; set; }

        public Account(TypeAccount typeAccount, double balance, double credit, string name)
        {
            this.typeAccount = typeAccount;
            this.balance = balance;
            this.credit = credit;
            this.name = name;
        }

        public bool ToWithdraw(double valueWithdraw)
        {
            if(this.balance - valueWithdraw < (this.credit *-1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.balance -= valueWithdraw;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.name, this.balance);

            return true;
        }

        public void ToDeposit(double valueDeposit)
        {
            this.balance += valueDeposit;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.name, this.balance);
        }

        public void ToTransfer(double valueTransfer, Account accountDestination)
        {
            if(this.ToWithdraw(valueTransfer))
            {
                accountDestination.ToDeposit(valueTransfer);
            }
        }

        public override string ToString()
        {
            string ret = "";
            ret += "TypeAccount " + this.typeAccount + " | ";
            ret += "Name " + this.name + " | ";
            ret += "Balance " + this.balance + " | ";
            ret += "Credit " + this.credit;
            return ret;
        }

        
    }
}