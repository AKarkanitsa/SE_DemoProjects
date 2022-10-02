using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeCasting
{
    public class Person
    {
    }

    public class Client : Person
    {
    }

    public class Employee : Person
    {
    }

    class Program
    {
        public static void MainX()
        {
            Client client = new Client();
            Person person = new Person();
            Employee employee = new Employee();

            Console.WriteLine(client is Person);
            Console.WriteLine(person is Person);
            Console.WriteLine(client is Client);
            Console.WriteLine(person is Client);
            Console.WriteLine(employee is Client);


            Person clientAsPerson = client;
            Console.WriteLine(clientAsPerson is Client);
            Client correctClient1 = clientAsPerson as Client;
            Client correctClient2 = (Client)clientAsPerson;

            Client incorrentClient1 = person as Client; // = null
            Client incorrectClient2 = (Client)person; //вознинкнет исключение, т.к. person не является Client

            //Client incorrectClient3 = (Client)employee; // синтаксически невозможно

        }
    }

}
