using System;
using Xunit;

namespace Banks.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void Deposit_PositiveAmount_IncreasesBalance()
        {
            var account = new BankAccount("John Doe", 100);
            account.Deposit(50);
            Assert.Equal(150, account.Balance);
        }

        [Fact]
        public void Deposit_NegativeAmount_ThrowsArgumentException()
        {
            var account = new BankAccount("John Doe", 100);
            Assert.Throws<ArgumentException>(() => account.Deposit(-10));
        }

        [Fact]
        public void Withdraw_PositiveAmount_DecreasesBalance()
        {
            var account = new BankAccount("John Doe", 100);
            account.Withdraw(40);
            Assert.Equal(60, account.Balance);
        }

        [Fact]
        public void Withdraw_ExceedingAmount_ThrowsInvalidOperationException()
        {
            var account = new BankAccount("John Doe", 100);
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(150));
        }

        [Fact]
        public void Withdraw_NegativeAmount_ThrowsArgumentException()
        {
            var account = new BankAccount("John Doe", 100);
            Assert.Throws<ArgumentException>(() => account.Withdraw(-20));
        }

        [Fact]
        public void Transfer_ValidAmount_UpdatesBothAccounts()
        {
            var source = new BankAccount("John Doe", 100);
            var target = new BankAccount("Jane Doe", 50);
            source.Transfer(target, 30);
            Assert.Equal(70, source.Balance);
            Assert.Equal(80, target.Balance);
        }

        [Fact]
        public void Transfer_ToSameAccount_ThrowsInvalidOperationException()
        {
            var account = new BankAccount("John Doe", 100);
            Assert.Throws<InvalidOperationException>(() => account.Transfer(account, 30));
        }

        [Fact]
        public void Transfer_NullTarget_ThrowsArgumentNullException()
        {
            var account = new BankAccount("John Doe", 100);
            Assert.Throws<ArgumentNullException>(() => account.Transfer(null, 30));
        }

        [Fact]
        public void CloseAccount_WithZeroBalance_DeactivatesAccount()
        {
            var account = new BankAccount("John Doe", 0);
            account.CloseAccount();
            Assert.False(account.IsActive);
        }

        [Fact]
        public void CloseAccount_WithNonZeroBalance_ThrowsInvalidOperationException()
        {
            var account = new BankAccount("John Doe", 100);
            Assert.Throws<InvalidOperationException>(() => account.CloseAccount());
        }

        [Fact]
        public void ReopenAccount_ReactivatesAccount()
        {
            var account = new BankAccount("John Doe", 0);
            account.CloseAccount();
            account.ReopenAccount();
            Assert.True(account.IsActive);
        }

        [Fact]
        public void Withdraw_InactiveAccount_ThrowsInvalidOperationException()
        {
            var account = new BankAccount("John Doe", 0);
            account.CloseAccount();
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(10));
        }

        [Fact]
        public void Deposit_InactiveAccount_ThrowsInvalidOperationException()
        {
            var account = new BankAccount("John Doe", 0);
            account.CloseAccount();
            Assert.Throws<InvalidOperationException>(() => account.Deposit(10));
        }

        [Fact]
        public void MultipleOperations_ValidSequence()
        {
            var account = new BankAccount("John Doe", 100);
            account.Deposit(50);
            account.Withdraw(30);
            Assert.Equal(120, account.Balance);
        }

        [Fact]
        public void MultipleTransfers_ValidOperations()
        {
            var account1 = new BankAccount("John Doe", 200);
            var account2 = new BankAccount("Jane Doe", 150);
            account1.Transfer(account2, 50);
            account2.Transfer(account1, 30);
            Assert.Equal(180, account1.Balance);
            Assert.Equal(170, account2.Balance);
        }

        [Theory]
        [InlineData(100, 1, 101)]
        [InlineData(200, 50, 250)]
        [InlineData(0, 10, 10)]
        public void Deposit_VariousAmounts_UpdatesBalance(double initialBalance, double depositAmount, double expected)
        {
            var account = new BankAccount("John Doe", initialBalance);
            account.Deposit(depositAmount);
            Assert.Equal(expected, account.Balance);
        }

        [Theory]
        [InlineData(200, 100, 100)]
        [InlineData(150, 50, 100)]
        [InlineData(75, 25, 50)]
        public void Withdraw_VariousAmounts_UpdatesBalance(double initialBalance, double withdrawAmount,
            double expected)
        {
            var account = new BankAccount("John Doe", initialBalance);
            account.Withdraw(withdrawAmount);
            Assert.Equal(expected, account.Balance);
        }

        [Fact]
        public void CloseAccount_ThrowsErrorIfActiveWithNonZeroBalance()
        {
            var account = new BankAccount("Alice", 500);
            Assert.Throws<InvalidOperationException>(() => account.CloseAccount());
        }

        [Fact]
        public void Transfer_CorrectlyCalculatesBalancesAfterOperations()
        {
            var source = new BankAccount("Source", 400);
            var destination = new BankAccount("Destination", 100);
            source.Transfer(destination, 50);
            Assert.Equal(350, source.Balance);
            Assert.Equal(150, destination.Balance);
        }

        [Fact]
        public void CloseAccount_ReopenAndUseSuccessfully()
        {
            var account = new BankAccount("Inactive", 0);
            account.CloseAccount();
            account.ReopenAccount();
            account.Deposit(100);
            Assert.Equal(100, account.Balance);
            Assert.True(account.IsActive);
        }
    }
}