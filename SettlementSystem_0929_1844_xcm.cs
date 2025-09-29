// 代码生成时间: 2025-09-29 18:44:06
using System;
using System.Collections.Generic;

namespace SettlementSystem
{
    public class Transaction
    {
        public decimal Amount { get; }
        public string FromAccount { get; }
        public string ToAccount { get; }
        public DateTime TransactionDate { get; }

        public Transaction(decimal amount, string fromAccount, string toAccount, DateTime transactionDate)
        {
            Amount = amount;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            TransactionDate = transactionDate;
        }
    }

    public class Account
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }

        public Account(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public bool Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            Balance += amount;
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds");
            }

            Balance -= amount;
            return true;
        }
    }

    public class SettlementSystem
    {
        private Dictionary<string, Account> accounts = new Dictionary<string, Account>();

        public SettlementSystem()
        {
            // Initialize accounts or load from a database
        }

        public bool AddAccount(string accountNumber, decimal initialBalance)
        {
            if (string.IsNullOrWhiteSpace(accountNumber) || initialBalance < 0)
            {
                throw new ArgumentException("Invalid account number or initial balance");
            }

            if (accounts.ContainsKey(accountNumber))
            {
                throw new InvalidOperationException("Account already exists");
            }

            accounts.Add(accountNumber, new Account(accountNumber, initialBalance));
            return true;
        }

        public bool ProcessTransaction(Transaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("Transaction cannot be null");
            }

            if (!accounts.TryGetValue(transaction.FromAccount, out var fromAccount))
            {
                throw new KeyNotFoundException("Sender account not found");
            }

            if (!accounts.TryGetValue(transaction.ToAccount, out var toAccount))
            {
                throw new KeyNotFoundException("Receiver account not found");
            }

            try
            {
                fromAccount.Withdraw(transaction.Amount);
                toAccount.Deposit(transaction.Amount);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Transaction failed: {ex.Message}");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Transaction failed: {ex.Message}");
                return false;
            }

            return true;
        }
    }
}
