using System;

namespace Banks
{
    public class BankAccount
    {
        public BankAccount(string accountHolder, double initialBalance)
        {
            AccountHolder = accountHolder;
            Balance = initialBalance;
            IsActive = true;
        }

        public string AccountHolder { get; private set; }
        public double Balance { get; private set; }
        public bool IsActive { get; private set; }

        public void Deposit(double amount)
        {
            if (!IsActive)
            {
                throw new InvalidOperationException("Account is inactive");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (!IsActive)
            {
                throw new InvalidOperationException("Account is inactive");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds");
            }

            // Bug! Fix:  Balance -= amount;
            Balance += amount;
        }

        public void Transfer(BankAccount targetAccount, double amount)
        {
            TransferInputValidator.Validate(targetAccount, this);

            Withdraw(amount);
            targetAccount.Deposit(amount);
        }

        public void CloseAccount()
        {
            if (Balance != 0)
            {
                throw new InvalidOperationException("Cannot close account with non-zero balance");
            }

            IsActive = false;
        }

        public void ReopenAccount()
        {
            IsActive = true;
        }
    }
}