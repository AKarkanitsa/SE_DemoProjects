using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovariantInterface
{
    class Message
    {
        public virtual string Text { get; set; }
        public Message(string text) => Text = text;
    }
    class EmailMessage : Message
    {
        public string From { get; set; } //отправитель
        public string To { get; set; }   //получатель
        public override string Text 
        {
            get
            {
                return $"From: {From}\nTo: {To}\nEmail: {base.Text}";
            }
        } 
        public EmailMessage(string from, string to, string text) : base(text)
        {
            From = from;
            To = to;
        }
    }

    //Ковариантный интерфейс IMessenger определяет метод WriteMessage() для создания сообщения
    //Параметр интерфейса определяется с ключевым словом out и представляет тип объекта,
    //который возвращается из интерфейса.
    //На момент определения интерфейса мы не знаем, объект какого типа будет возвращаться методом.
    interface IMessenger<out T>
    {
        T WriteMessage(string from, string to, string text);
    }

    //Класс EmailMessenger реализует IMessenger интерфейс и возвращает из метода WriteMessage()
    //объект EmailMessage.
    class EmailMessenger : IMessenger<EmailMessage>
    {
        //Метод возвращает объект типа EmailMessage
        public EmailMessage WriteMessage(string from, string to, string text)
        {
            return new EmailMessage(from, to, text);
        }
    }

    //Класс ChatMessenger реализует IMessenger интерфейс и возвращает из метода WriteMessage()
    //объект Message.
    class ChatMessenger : IMessenger<Message>
    {
        //А здесь метод возваращает объект типа Message
        public Message WriteMessage(string from, string to, string text)
        {
            return new Message($"From: all  \nTo: all \nMessage: {text}");
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            IMessenger<Message> gmail = new EmailMessenger();
            Message message = gmail.WriteMessage("user_1@gmail,com", "user_2@gmail.com","Hello User!");
            Console.WriteLine(message.Text);
            
            Console.WriteLine("===============================");
            
            IMessenger<Message> viber = new ChatMessenger();
            message = viber.WriteMessage("","","Hello everyone!");
            Console.WriteLine(message.Text);

            Console.WriteLine("===============================");

            //или так
            SendMessage(gmail, "user_1@gmail,com", "user_2@gmail.com", "Hello User!");
            Console.WriteLine("===============================");
            SendMessage(viber, "user_1@gmail,com", "user_2@gmail.com", "Hello everyone!");
        }

        //метод примет в качестве параметра любой мессенждер, реализующий интерфейс IMessenger
        static void SendMessage(IMessenger<Message> messenger,string from, string to, string text)
        {
            Message message = messenger.WriteMessage(from, to, text);
            Console.WriteLine(message.Text);
        }
    }
}
