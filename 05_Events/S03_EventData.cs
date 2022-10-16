using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventData
{
    // delegate now has two arguments: sender - the object that is raised the event
    // and e - event data
    public delegate void AccountHandler(BankAccount sender, AccountEventArgs e);
    
    // EventArgs class to keep data about event (message and amount of money) 
    public class AccountEventArgs
    {
        // Сообщение //Message
        public string Message { get; }
        // Сумма, на которую изменился счет // Amount to change a balance
        public int Amount { get; }

        public string Owner { get; }
        public AccountEventArgs(string owner,string message, int amount)
        {
            Message = message;
            Amount = amount;
            Owner = owner;
        }
    }

    public class BankAccount
    {
        // сумма на счете
        // amount of money on Account
        public int Balance { get; private set; }
        // в конструкторе устанавливаем начальную сумму на счете
        // constructor sets the initial amount of money

        // account owner
        public string Owner { get; private set; }

        // event
        public event AccountHandler? Notify;
        public BankAccount(string owner, int amount)
        {
            Owner = owner;
            Balance = amount;
        }

        // добавление средств на счет
        // adding funds to an account
        public void Deposit(int amount)
        {
            Balance += amount;
            Notify(this, new AccountEventArgs(Owner, $"{amount} BYN  were deposited in the account.",amount));

        }
        // списание средств со счета
        // withdrawal of funds from the account
        public void Withdraw(int amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Notify(this, new AccountEventArgs(Owner,$"{amount} BYN  was withdrawn from the account.",amount));
            }
            else Notify(this, new AccountEventArgs(Owner,$"The account has insufficient funds to withdraw {amount}",amount));

        }

    }

    public class Program
    {

        // метод-обработик события
        // event handler
        static void NotifyClient(BankAccount sender, AccountEventArgs e)
        {
            Console.WriteLine($"Account Owner: {e.Owner}");
            Console.WriteLine($"Transaction: {e.Amount} BYN");
            Console.WriteLine(e.Message);
            Console.WriteLine($"Current Balance: {sender.Balance}");
        }
        static void MainX()
        {
            BankAccount account1 = new BankAccount("Bob",100); //initial balance - 100
            BankAccount account2 = new BankAccount("Alisa", 100); //initial balance - 100
            // назначаем обработчика событию Notify
            // adding event handler to the Notify event
            account1.Notify += NotifyClient;
            account2.Notify += NotifyClient;
            account1.Deposit(20);    // добавляем на счет 20 //deposit with 20
            account2.Withdraw(70);   // пытаемся снять со счета 70 // withdraw 70     
        }
    }
}
