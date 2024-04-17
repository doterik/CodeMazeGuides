#pragma warning disable SA1309 // Field names should not begin with underscore.

namespace AccessModifiersInCsharp;

public class BankAccount
{
    private int _balance;

    public int GetBalance() => _balance;

    public void Deposit(int amount) => _balance += amount;

    public void Withdraw(int amount)
    {
        if (_balance >= amount) _balance -= amount;
    }
}
