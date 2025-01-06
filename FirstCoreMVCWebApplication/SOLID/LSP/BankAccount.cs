namespace FirstCoreMVCWebApplication.SOLID.LSP
{
    public abstract class BankAccount
    {
        protected double balance;
        public virtual void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine($"Deposit: {amount} total amount: {balance}");
        }

        public abstract void WithDraw(double amount);
        public double GetBalance()
        {
            return balance;
        }
    }

    public class RegularAccount : BankAccount
    {
        public override void WithDraw(double amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Withdraw {amount} balance {balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }
    }

    public class FixTermDepositAccount : BankAccount
    {
        private bool termEnded = false;

        public override void WithDraw(double amount)
        {
            if (!termEnded)
            {
                Console.WriteLine("Can not with draaw amount");
            }
            else if (balance >= amount)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("In sufficient balance");
            }
        }
    }
}
