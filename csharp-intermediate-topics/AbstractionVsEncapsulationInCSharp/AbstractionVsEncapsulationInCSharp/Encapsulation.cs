namespace Encapsulation;

public class BankAccount(string accountNumber, decimal initialBalance = 0)
{
    public string AccountNumber { get; } = accountNumber;
    public decimal Balance { get; private set; } = initialBalance;

    public void Deposit(decimal amount)
    {
        if (amount <= 0) Console.WriteLine("Invalid amount for deposit.");
        else
        {
            Balance += amount;
            Console.WriteLine($"Deposit successful. New account balance: {Balance}");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > Balance) Console.WriteLine("Invalid amount for withdrawal or insufficient funds.");
        else
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawal successful. New account balance: {Balance}");
        }
    }
}
