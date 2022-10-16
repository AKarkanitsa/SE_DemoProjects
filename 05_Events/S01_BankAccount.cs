using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events01
{
    public delegate void AccountHandler(string message); 
    public class BankAccount
    {
        // сумма на счете
        // amount of money on Account
        public int Balance { get; private set; }
        // в конструкторе устанавливаем начальную сумму на счете
        // constructor sets the initial amount of money
        public BankAccount(int amount) => Balance = amount;
       
        // добавление средств на счет
        // adding funds to an account
        public void Deposit(int amount)
        {
            Balance += amount;
            Notify($"{amount} BYN  were deposited in the account. Current Balance: {Balance} BYN");

        }
        
        // списание средств со счета
        // withdrawal of funds from the account
        public void Withdraw(int amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Notify($"{amount} BYN  was withdrawn from the account. Current Balance: {Balance} BYN");
            }
            else Notify($"The account has insufficient funds. Current balance is {Balance} BYN.");

        }

        // event
        public event AccountHandler? Notify;

    }

    public class Program
    {
        // event handler
        static void BalanceHasChanged(string message)
        {
            Console.WriteLine(message);
        }
        static void MainX()
        {
            BankAccount account = new BankAccount(100); //initial balance - 100
            account.Notify += BalanceHasChanged;
            Console.WriteLine($"Current Balance: {account.Balance}");
            account.Deposit(20);    // добавляем на счет 20 //deposit with 20
            account.Withdraw(70);   // пытаемся снять со счета 70 // withdraw 70
            account.Withdraw(180);  // пытаемся снять со счета 180 // withdraw with 180         
        }
    }
}
