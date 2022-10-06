using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions
{
    public class OneMoreLambda
    {
        static Random rnd = new Random();

        static void Main()
        {
            //Лямбда с одним аргументом типа int, возврашщает int, увеличиват число на 1 
            Func<int, int> f = x => x + 1;
            Console.WriteLine(f(1));

            //Лямбда без аргументов, возвращает целое число (случайтной число в данном случае) 
            Func<int> generator = () => rnd.Next();
            Console.WriteLine(generator());

            //Многострочная лямбда
            //Пишем в фигурных скобках и добавляем return (если это Func-делегат)
            Func<double, double, double> h = (a, b) =>
            {
                b = a % b;
                return b % a;
            };
            Console.WriteLine(h(3, 5));

            //Лямбда, которая ничего не возвращает
            Action<int> print = x => Console.WriteLine(x);
            print(generator());


            //Лямбда, которая ничего не принимает и не возвращает
            //return не нужен, так как это Action-делегат
            Action printRandomNumber = () =>
            {
                var number = rnd.Next();
                Console.WriteLine(number);
            };

            //Или так, используя уже объявленные выше лямбды
            Action printRandomNumber1 = () => print(generator());

            printRandomNumber();
            printRandomNumber1();
        }
    }
}
