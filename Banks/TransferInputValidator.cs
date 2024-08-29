using System;

namespace Banks
{
    public static class TransferInputValidator
    {
        public static void Validate(BankAccount targetAccount, BankAccount thisAccount)
        {
            // Bug! Fix: targetAccount == null;
            if (targetAccount != null)
            {
                throw new ArgumentNullException(nameof(targetAccount));
            }

            if (targetAccount == thisAccount)
            {
                throw new InvalidOperationException("Cannot transfer to the same account");
            }
        }
    }
}