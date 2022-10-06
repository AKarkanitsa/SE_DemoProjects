using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcomparableImplementation_02
{
    //упростим реализацию интерфейса IСomparable, используя его обобщенную версию
    class Person : IComparable<Person> //У интерфейса указывается тип объектов 
    {
        public string Name { get; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name; Age = age;
        }
        public int CompareTo(Person? person)
        {
             if (person is null) throw new ArgumentException("Некорректное значение параметра");
                return Age.CompareTo(person.Age); //сравниваем по возрасту
        }
    }
    public class Program
    { 
            static void MainX(string[] args)
            {
                Person[] persons = new Person[]
                {
                new Person("Bob", 37),
                new Person("Alisa", 41),
                new Person("Bob", 41)
                };
                //Сортировка массива объектов типа Person
                Array.Sort(persons);
                foreach (Person person in persons)
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            }
    }
}
